using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using PCRemote.Core;
using PCRemote.Core.Utilities;
using PCRemote.UI.Properties;
using Weibo;
using Weibo.Contracts;
using Weibo.Entities;

namespace PCRemote.UI
{
    public partial class Main : Form
    {
        IWeiboClient _client;
        User _currentUser;
        public string WorkingFolder;

        public Main()
        {
            InitializeComponent();
        }

        private void tmrPCRemote_Tick(object sender, EventArgs e)
        {
            tmrPCRemote.Enabled = false;
            if (this.ShowInTaskbar)
            {
                return;
            }

            NotifyIcon.Text = "正在检查是否有新的微博...";
            DebugPrintHelper("当前状态：正在检查是否有新的微博...");
            
            //todo: 检查用户账号是否合法
            try
            {
                _client = new NormalWeiboClient(Settings.Default.Username, Settings.Default.Password, ResultFormat.json);
                _currentUser = _client.VerifyCredentials();
            }
            catch (Exception ex)
            {
                DebugPrintHelper("错误：用户登录失败。请检查设置的用户名和密码。");
                tmrPCRemote.Enabled = true;
            }
            
            //todo: 检查新微博
            try
            {
                var status = _client.GetUserWeibos(_currentUser.ScreenName)[0];
                if(status.Id.ToString().Trim() != Settings.Default.LastID.Trim())
                {
                    Settings.Default.LastID = status.Id.ToString().Trim();
                    Settings.Default.Save();

                    //todo: 把最新的一条微博的命令部分拆出来
                    string command = status.Text.Split(new string[] { "$$" }, StringSplitOptions.None)[0];
                    while (command.EndsWith(" "))
                    {
                        command = command.Remove(command.Length - 1, 1);
                    }
                    DebugPrintHelper("新发布的命令为: \"" + command + "\"");
                    tmrPCRemote.Interval = 7000;

                    //todo: 解释命令
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
            NotifyIcon.Text = "PC遥控器已经激活，正在等待新的命令...";
            DebugPrintHelper("当前状态：PC遥控器已经激活，正在等待新的命令...");
        }

        private void ProcessCommand(string command, long weiboId)
        {
            NotifyIcon.Text = "正在处理命令...";
            DebugPrintHelper("当前状态：处理命令中...");



            ICommand commandHandler;
            switch (command)
            {
                case "关机":
                    SendComment(weiboId, Resource.ShutdownCommand_Comment);
                    commandHandler = new ShutdownCommand();
                    break;;
                case "终止关机":
                    SendComment(weiboId, Resource.AbortShutdownCommand_Comment);
                    commandHandler = new AbortShutdownCommand();
                    break;
                case "重启":
                    SendComment(weiboId, Resource.RestartCommand_Comment);
                    commandHandler = new RestartCommand();
                    break;
                case "静音":
                    SendComment(weiboId, Resource.VolMuteCommand_Comment);
                    commandHandler = new VolMuteCommand(this);
                    break;
                case "取消静音":
                    SendComment(weiboId, Resource.VolUnMuteCommand_Comment);
                    commandHandler = new VolMuteCommand(this);
                    break;
                case "加大音量":
                    SendComment(weiboId, Resource.VolIncCommand_Comment);
                    commandHandler = new VolIncCommand(this);
                    break;
                case "减小音量":
                    SendComment(weiboId, Resource.VolDecCommand_Comment);
                    commandHandler = new VolDecCommand(this);
                    break;
                case "关闭显示器":
                    SendComment(weiboId, "#PC遥控器#已经帮您关闭您的显示器。");
                    commandHandler = new DarkScreenCommand();
                    break;
                case "屏幕截图":
                    SendComment(weiboId, "#PC遥控器#正在上传你的屏幕截图，一会将会出现在你的最新微博中。");
                    commandHandler = new ScreenshotCommand(_client);
                    break;
                case "播放":
                    SendComment(weiboId, "#PC遥控器#正在为您播放当前的多媒体文件。");
                    commandHandler = new MediaCommand(MediaKey.PlayPause);
                    break;
                case "暂停":
                    SendComment(weiboId, "#PC遥控器#已经帮您暂停播放当前的多媒体文件。");
                    commandHandler = new MediaCommand(MediaKey.PlayPause);
                    break;
                case "下一首":
                    SendComment(weiboId, "#PC遥控器#正在为您播放下一个多媒体文件。");
                    commandHandler = new MediaCommand(MediaKey.Next);
                    break;
                case "上一首":
                    SendComment(weiboId, "#PC遥控器#正在为您播放上一个多媒体文件。");
                    commandHandler = new MediaCommand(MediaKey.Previous);
                    break;
                case "拍照":
                    SendComment(weiboId, "#PC遥控器#正在上传你的WebCam抓拍，一会将会出现在你的最新微博中。");
                    commandHandler = new PhotoCommand(_client, this);
                    break;
                default:
                    commandHandler = null;
                    break;
            }

            if(commandHandler != null)
                commandHandler.Execute();
        }

        private void SendComment(long weiboId, string message)
        {
            NotifyIcon.Text = "正在发送微博...";
            try
            {
                _client = new NormalWeiboClient(Settings.Default.Username, Settings.Default.Password, ResultFormat.json);
                _client.Comment(weiboId.ToString(), string.Empty, message + "有问题请@四眼蒙面侠 " + DateTime.Now.Ticks);
            }
            catch (Exception ex)
            {
                DebugPrintHelper(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotifyIcon.Text = "检查和保存设置中...";
            DebugPrintHelper("当前状态：检查和保存设置中...");

            //todo: 检查用户输入
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("请输入用户名");
                txtUsername.Focus();
                return;
            }

            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请输入密码");
                txtPassword.Focus();
                return;
            }

            btnSave.Text = "请耐心等待...";
            this.Refresh();

            try
            {
                _client = new NormalWeiboClient(txtUsername.Text, txtPassword.Text, ResultFormat.json);
                _client.VerifyCredentials();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //todo: 保存用户设置
            Settings.Default.Username = txtUsername.Text;
            Settings.Default.Password = txtPassword.Text;

            Settings.Default.Save();

            //todo: 最小化主窗口并在任务栏显示
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.tmrPCRemote.Enabled = true;
            this.btnSave.Text = "保 存";
            NotifyIcon.Text = "PC遥控器已经激活，正在等待新的命令...";
            DebugPrintHelper("当前状态：PC遥控器已经激活，正在等待新的命令...");
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
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

        #endregion

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
            MessageBox.Show("此功能正在开发中...");
        }

        private void settingToolStrip_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoStart.Checked == true)
            {
                Settings.Default.AutomaticStart = true;
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                regKey.SetValue(Application.ProductName, Application.ExecutablePath);
                regKey.Close();
            }
            else
            {
                Settings.Default.AutomaticStart = false;
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                regKey.DeleteValue(Application.ProductName);
                regKey.Close();
            }

            Settings.Default.Save();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Settings.Default.Username) || string.IsNullOrEmpty(Settings.Default.Password))
                return;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            txtUsername.Text = Settings.Default.Username;
            txtPassword.Text = Settings.Default.Password;
            chkAutoStart.Checked = Settings.Default.AutomaticStart;

            DebugPrintHelper("---");
            DebugPrintHelper("---");
            DebugPrintHelper("程序正在启动...");
            WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DebugPrintHelper("Workingfolder: " + WorkingFolder);

            tmrPCRemote.Enabled = true;
            NotifyIcon.Text = "PC遥控器已经激活，正在等待新的命令...";
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
    }
}
