using System;
using System.Windows.Forms;
using PCRemote.DataAccess;
using PCRemote.DataAccess.Repositories;

namespace PCRemote.UI
{
	public partial class CustomCommands
	{
	    readonly ICommandRepository _repo;

		public CustomCommands()
		{
			InitializeComponent();

		    _repo = new CommandRepository(Global.ConnectionString);
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static CustomCommands defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static CustomCommands Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new CustomCommands();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
		#endregion
		private void btnFile_Click(Object sender, EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			txtFileName.Text = "";
			openDialog.Filter = "可执行文件或音乐|*.COM;*.EXE;*.BAT;*.CMD;*.VBS;*.BAT;*.AHK;*.PY;*.wpl;*.m3u;*.mp3;*.wma;*.wav;*.xspf;*.html;*.txt|所有文件|*.*";
			openDialog.Title = "选择你想要执行的文件:";
			openDialog.ShowDialog();
			if (openDialog.FileName != "")
			{
				txtFileName.Text = openDialog.FileName;
			}
			else
			{
				txtFileName.Text = "文件路径...";
			}
			openDialog.Dispose();
		}
		
		private void btnAddCommand_Click(Object sender, EventArgs e)
		{		
			if (txtCommand.Text.Trim() == "" || txtFileName.Text.Trim() == "")
			{
				MessageBox.Show("请输入命令和文件路径。");
				txtCommand.Focus();
			}
			else
			{
                string[] preDefinedCommand = {"shutdown", "logoff", "restart", "physical memory", "virtual memory", "screenshot", "camera",
                                              "os", "ip", "lock", "standby", "hibernate", "screenshot", "play", "pause", "next", "previous",
                                              "getprocesslist", "getfile", "message", "help", "abortshutdown", "lock",
                                              "volmute", "cancelvolmute", "volinc", "voldec", "darkscreen", 
                                             "关机", "终止关机", "重启", "注销", "静音", "取消静音", "加大音量", "减小音量", "关闭显示器",
                                             "截图", "屏幕截图", "播放", "暂停", "下一首", "上一首", "拍照", "锁屏"};
				int i;
				for (i = 0; i <= preDefinedCommand.Length - 1; i++)
				{
					if (txtCommand.Text.Trim().ToLower() == preDefinedCommand[i])
					{
						MessageBox.Show("你输入的命令与系统预定义的命令有冲突，请换一个命令。");
						txtCommand.Focus();
						return;
					}
				}

			    var splitCommand = txtCommand.Text.Trim().Split(' ');
				
				if (splitCommand.Length > 1)
				{
					MessageBox.Show("你输入的命令格式有误");
					txtCommand.Focus();
					return;
				}
				
				InsertCommand(txtCommand.Text.Trim().ToLower(), txtFileName.Text.Trim());
				DisplayCustomCommand();
				txtCommand.Text = "";
				txtFileName.Text = "";
			}
		}
		
		private void CustomCommands_Load(Object sender, EventArgs e)
		{
			DisplayCustomCommand();
		}
		
		public void DisplayCustomCommand()
		{		
			try
			{
			    var commands = _repo.FindAll();
				dtCustomCommads.DataSource = commands;
				dtCustomCommads.Refresh();
				dtCustomCommads.RowHeadersVisible = false;
				dtCustomCommads.Columns[0].Width = 185;
				dtCustomCommads.Columns[1].Width = 250;
			}
			catch (Exception ex)
			{
			    MessageBox.Show(ex.Message);
			}
		}
	
		
		public void InsertCommand(string commandName, string file)
		{
		    try
		    {
                new PCRemoteDB();
		        var command = _repo.FindOne(commandName.ToLower());
                if(command == null)
                {
                    command = new Command
                    {
                        CommandName = commandName.ToLower(),
                        File = file
                    };
                    _repo.Save(command);
                }
                else
                {
                    command.File = file;
                    _repo.Update(command);
                }
            }
		    catch (Exception ex)
		    {
		        MessageBox.Show(ex.Message);
		    }
		}
		
		private void btnRemoveCommand_Click(Object sender, EventArgs e)
		{
			if (dtCustomCommads.RowCount != 0)
			{
				if (dtCustomCommads.CurrentCell.Value.ToString() != "")
				{
					DeleteCommand(dtCustomCommads.CurrentRow.Cells[0].Value.ToString());
				}
				DisplayCustomCommand();
			}
		}
		
		public void DeleteCommand(string command)
		{
		    try
		    {
		        _repo.Delete(command.ToLower());
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show(ex.Message);
		    }
		}
	}
}
