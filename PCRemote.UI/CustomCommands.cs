using System;
using System.Windows.Forms;
using PCRemote.Core;
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
			var openDialog = new OpenFileDialog();
			txtFileName.Text = "";
			openDialog.Filter = @"��ִ���ļ�������|*.COM;*.EXE;*.BAT;*.CMD;*.VBS;*.BAT;*.AHK;*.PY;*.wpl;*.m3u;*.mp3;*.wma;*.wav;*.xspf;*.html;*.txt|�����ļ�|*.*";
			openDialog.Title = @"ѡ������Ҫִ�е��ļ�:";
			openDialog.ShowDialog();
			if (openDialog.FileName != "")
			{
				txtFileName.Text = openDialog.FileName;
			}
			else
			{
				txtFileName.Text = @"�ļ�·��...";
			}
			openDialog.Dispose();
		}
		
		private void btnAddCommand_Click(Object sender, EventArgs e)
		{		
			if (txtCommand.Text.Trim() == "" || txtFileName.Text.Trim() == "")
			{
				MessageBox.Show(@"������������ļ�·����");
				txtCommand.Focus();
			}
			else
			{
                string[] preDefinedCommand = {"shutdown", "logoff", "restart", "physical memory", "virtual memory", "screenshot", "camera",
                                              "os", "ip", "lock", "standby", "hibernate", "screenshot", "play", "pause", "next", "previous",
                                              "getprocesslist", "getfile", "message", "help", "abortshutdown", "lock",
                                              "volmute", "cancelvolmute", "volinc", "voldec", "darkscreen", 
                                             "�ػ�", "��ֹ�ػ�", "����", "ע��", "����", "ȡ������", "�Ӵ�����", "��С����", "�ر���ʾ��",
                                             "��ͼ", "��Ļ��ͼ", "����", "��ͣ", "��һ��", "��һ��", "����", "����"};
				int i;
				for (i = 0; i <= preDefinedCommand.Length - 1; i++)
				{
					if (txtCommand.Text.Trim().ToLower() == preDefinedCommand[i])
					{
						MessageBox.Show(@"�������������ϵͳԤ����������г�ͻ���뻻һ�����");
						txtCommand.Focus();
						return;
					}
				}

			    var splitCommand = txtCommand.Text.Trim().Split(' ');
				
				if (splitCommand.Length > 1)
				{
					MessageBox.Show(@"������������ʽ����");
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

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
	}
}
