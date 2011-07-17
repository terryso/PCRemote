using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using PCRemote.Core;
using PCRemote.Core.Configuration;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.DataAccess.Repositories;
using PCRemote.UI.Factories;
using PCRemote.UI.Properties;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Factories;

namespace PCRemote.UI
{
    public partial class Main : Form
    {
        IWeiboService _service;
        ICommandRepository _repo;
        public string WorkingFolder;
        private RequestToken _requestToken;
        IDictionary<string, ICommand> _commands;

        public Main()
        {
            InitializeComponent();
            ddlWeibo.SelectedIndex = 0;

            _commands = CommandConfiguration.GetConfig().Commands;

        }

        private void tmrPCRemote_Tick(object sender, EventArgs e)
        {
            tmrPCRemote.Enabled = false;
            if (ShowInTaskbar)
            {
                return;
            }

            NotifyIcon.Text = @"正在检查是否有新的微博...";
            DebugPrintHelper("当前状态：正在检查是否有新的微博...");
            
            //检查用户账号是否合法
            try
            {
                _service = WeiboServiceFactory.CreateInstance();
                _service.VerifyCredentials();
            }
            catch (Exception ex)
            {
                DebugPrintHelper("错误：用户登录失败。\n" + ex.Message);
                tmrPCRemote.Enabled = true;
            }
            
            //检查新微博
            try
            {
                var status = _service.GetMyFirstWeibo();
                if(status.Id.Trim() != Settings.Default.LastID.Trim())
                {
                    Settings.Default.LastID = status.Id.Trim();
                    Settings.Default.Save();

                    //把最新的一条微博的命令部分拆出来
                    var command = status.Text.Split(new[] { "$$" }, StringSplitOptions.None)[0];
                    while (command.EndsWith(" "))
                    {
                        command = command.Remove(command.Length - 1, 1);
                    }
                    DebugPrintHelper("新发布的命令为: \"" + command + "\"");
                    tmrPCRemote.Interval = 7000;

                    //解释命令
                    ProcessCommand(command, status.Id);
                }
                else
                {
                    if (tmrPCRemote.Interval == 7000)
                    {
                        tmrPCRemote.Interval = 8000;
                    }
                    else if (tmrPCRemote.Interval == 8000)
                    {
                        tmrPCRemote.Interval = 9000;
                    }
                    else if (tmrPCRemote.Interval == 9000)
                    {
                        tmrPCRemote.Interval = 10000;
                    }
                    else if (tmrPCRemote.Interval == 10000)
                    {
                        tmrPCRemote.Interval = 16000;
                    }
                    else
                    {
                        tmrPCRemote.Interval = 16000;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugPrintHelper(ex.Message);
                tmrPCRemote.Interval = 16000;
                tmrPCRemote.Enabled = true;
                return;
            }

            tmrPCRemote.Enabled = true;
            NotifyIcon.Text = @"PC遥控器已经激活，正在等待新的命令...";
            DebugPrintHelper("当前状态：PC遥控器已经激活，正在等待新的命令...");
        }

        private void ProcessCommand(string command, string weiboId)
        {
            NotifyIcon.Text = @"正在处理命令...";
            DebugPrintHelper("当前状态：处理命令中...");

            ICommand commandHandler;

            if(_commands.ContainsKey(command))
            {
                commandHandler = _commands[command];
                var context = new CommandContext
                {
                    WeiboId = weiboId,
                    WeiboService = _service,
                    Handle = Handle
                };

                commandHandler.Execute(context);
            }
            else
            {
                RunCustomCommands(weiboId, command);
            }
        }

        private void RunCustomCommands(string weiboId, string command)
        {
            var splitCommand = command.Split(' ')[0];

            NotifyIcon.Text = @"检查自定义命令...";
            DebugPrintHelper("当前状态：检查自定义命令...");

            try
            {

                _repo = new CommandRepository(Global.ConnectionString);
                var cmd = _repo.FindOne(splitCommand.ToLower());

                if(cmd != null && !string.IsNullOrEmpty(cmd.File))
                {
                    SendComment(weiboId, string.Format("#PC遥控器#正在为您执行您的自定义命令: {0}。", command));

                    var optionsCommand = command.Remove(0, splitCommand.Length);
                    while (optionsCommand.StartsWith(" "))
                    {
                        optionsCommand = optionsCommand.Remove(0, 1);
                    }
                    DebugPrintHelper(string.Format("当前执行的自定义命令为: \"{0} {1}\"", cmd.File, optionsCommand));
                    Process.Start(cmd.File, optionsCommand);

                    SendComment(weiboId, "#PC遥控器#执行自定义命令完成。");
                }
            }
            catch (Exception ex)
            {
                DebugPrintHelper(ex.Message);
                SendComment(weiboId, "执行自定义命令出错。请过一会重试。");
            }
        }

        private void SendComment(string weiboId, string message)
        {
            NotifyIcon.Text = @"正在发送微博...";
            try
            {
                _service = WeiboServiceFactory.CreateInstance();

                var weiboType = Settings.Default.WeiboType.ToLower();
                switch (weiboType)
                {
                    case "新浪微博":
                        _service.SendComment(weiboId, message + "有问题请@四眼蒙面侠 " + DateTime.Now.Ticks);
                        break;
                    case "腾讯微博":
                        _service.SendComment(weiboId, message + "有问题请@suchuanyi " + DateTime.Now.Ticks);
                        break;
                }
            }
            catch (Exception ex)
            {
                DebugPrintHelper(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotifyIcon.Text = @"检查和保存设置中...";
            DebugPrintHelper("当前状态：检查和保存设置中...");

            var pin = txtPin.Text.Trim();
            if(!string.IsNullOrEmpty(pin))
            {
                AccessToken accessToken;
                try
                {
                    accessToken = _requestToken.ToAccessToken(pin);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    UnlockAccountSetup();
                    return;
                }

                //保存用户设置
                Settings.Default.AccessToken = accessToken.Token;
                Settings.Default.AccessTokenSecret = accessToken.Secret;

                Settings.Default.Save();
            }

            if (string.IsNullOrEmpty(Settings.Default.AccessToken) || string.IsNullOrEmpty(Settings.Default.AccessTokenSecret))
            {
                UnlockAccountSetup();
                MessageBox.Show(@"请先使用微博账号登录");
                return;
            }

            try
            {
                _service = WeiboServiceFactory.CreateInstance();
                _service.VerifyCredentials();

                LockAccountSetup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UnlockAccountSetup();
                return;
            }

            //最小化主窗口并在任务栏显示
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            tmrPCRemote.Enabled = true;
            btnSave.Text = @"保 存";
            NotifyIcon.Text = @"PC遥控器已经激活，正在等待新的命令...";
            DebugPrintHelper("当前状态：PC遥控器已经激活，正在等待新的命令...");
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitTooStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customCommandMenu_Click(object sender, EventArgs e)
        {
            DebugPrintHelper("打开自定义命令窗口");
            CustomCommands.Default.ShowDialog();
            CustomCommands.Default.Focus();
        }

        private void settingToolStrip_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoStart.Checked)
            {
                try
                {
                    Settings.Default.AutomaticStart = true;
                    RegistryKey regKey;
                    regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    regKey.SetValue(Application.ProductName, Application.ExecutablePath);
                    regKey.Close();
                }
                catch (Exception ex)
                {
                    chkAutoStart.Checked = false;
                    DebugPrintHelper(ex.Message);
                }
            }
            else
            {
                try
                {
                    Settings.Default.AutomaticStart = false;
                    RegistryKey regKey;
                    regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    regKey.DeleteValue(Application.ProductName);
                    regKey.Close();
                }
                catch (Exception ex)
                {
                    chkAutoStart.Checked = true;
                    DebugPrintHelper(ex.Message);
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Settings.Default.AccessToken) || string.IsNullOrEmpty(Settings.Default.AccessTokenSecret))
            {
                UnlockAccountSetup();
                return;
            }

            if (!string.IsNullOrEmpty(Settings.Default.WeiboType))
                ddlWeibo.Text = Settings.Default.WeiboType;

            try
            {
                _service = WeiboServiceFactory.CreateInstance();
                _service.VerifyCredentials();

                LockAccountSetup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UnlockAccountSetup();
                return;
            }

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            chkAutoStart.Checked = Settings.Default.AutomaticStart;

            DebugPrintHelper("---");
            DebugPrintHelper("---");
            DebugPrintHelper("程序正在启动...");
            WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DebugPrintHelper("Workingfolder: " + WorkingFolder);

            tmrPCRemote.Enabled = true;
            NotifyIcon.Text = @"PC遥控器已经激活，正在等待新的命令...";
            DebugPrintHelper("当前状态：PC遥控器已经激活，正在等待新的命令...");
        }

        private void menuCommand_Click(object sender, EventArgs e)
        {
            Process.Start("http://suchuanyi.sinaapp.com/?page_id=26");
        }

        private void menuSkill_Click(object sender, EventArgs e)
        {
            Process.Start("http://suchuanyi.sinaapp.com/?p=9");
        }

        private void menuHomePage_Click(object sender, EventArgs e)
        {
            Process.Start("http://suchuanyi.sinaapp.com");
        }

        private void menuRecommend_Click(object sender, EventArgs e)
        {
            new Recommend().Show();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void menuSupport_Click(object sender, EventArgs e)
        {
            Process.Start("http://suchuanyi.sinaapp.com/?page_id=38");
        }

        private void menuLogoff_Click(object sender, EventArgs e)
        {
            Settings.Default.AccessToken = string.Empty;
            Settings.Default.AccessTokenSecret = string.Empty;
            Settings.Default.WeiboType = string.Empty;

            Settings.Default.Save();

            UnlockAccountSetup();
        }

        private void btnGetPin_Click(object sender, EventArgs e)
        {
            var weiboType = ddlWeibo.Text;
            var consumer = ConsumerFactory.GetConsumer(weiboType);

            _requestToken = consumer.GetRequestToken();
            var authorizeUri = _requestToken.GetNormalizedAuthorizeUri();

            Process.Start(authorizeUri);

            Settings.Default.WeiboType = ddlWeibo.Text;
            Settings.Default.Save();
        }

        #region Helper

        public void DebugPrintHelper(string printString)
        {
            try
            {
                Debug.WriteLine(printString.Trim());
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\PCRemoteDebug.txt"))
                {
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\PCRemoteDebug.txt", DateTime.Now.ToString().Trim() + "    " + printString.Trim() + "\r\n");
                }
            }
            catch (Exception)
            {
            }
        }

        void UnlockAccountSetup()
        {
            ddlWeibo.Enabled = true;
            txtPin.Enabled = true;
            btnGetPin.Enabled = true;

            txtPin.Text = string.Empty;
        }

        void LockAccountSetup()
        {
            ddlWeibo.Enabled = false;
            txtPin.Enabled = false;
            btnGetPin.Enabled = false;

            txtPin.Text = string.Empty;
        }

        #endregion
    }
}
