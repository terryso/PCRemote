using System.Windows.Forms;

namespace PCRemote.UI
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class CustomCommands : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

        //Required by the Windows Form Designer
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomCommands));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dtCustomCommads = new System.Windows.Forms.DataGridView();
            this.command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnRemoveCommand = new System.Windows.Forms.Button();
            this.btnAddCommand = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomCommads)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dtCustomCommads);
            this.GroupBox1.Location = new System.Drawing.Point(4, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(416, 242);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "命令列表";
            // 
            // dtCustomCommads
            // 
            this.dtCustomCommads.AllowUserToAddRows = false;
            this.dtCustomCommads.AllowUserToDeleteRows = false;
            this.dtCustomCommads.AllowUserToOrderColumns = true;
            this.dtCustomCommads.AllowUserToResizeRows = false;
            this.dtCustomCommads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCustomCommads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.command,
            this.file});
            this.dtCustomCommads.Location = new System.Drawing.Point(8, 15);
            this.dtCustomCommads.Name = "dtCustomCommads";
            this.dtCustomCommads.RowTemplate.Height = 23;
            this.dtCustomCommads.Size = new System.Drawing.Size(402, 221);
            this.dtCustomCommads.TabIndex = 1;
            // 
            // command
            // 
            this.command.DataPropertyName = "CommandName";
            this.command.HeaderText = "命令";
            this.command.Name = "command";
            this.command.ReadOnly = true;
            // 
            // file
            // 
            this.file.DataPropertyName = "File";
            this.file.HeaderText = "文件";
            this.file.Name = "file";
            this.file.ReadOnly = true;
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(56, 39);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(270, 21);
            this.txtFileName.TabIndex = 10;
            // 
            // btnRemoveCommand
            // 
            this.btnRemoveCommand.Location = new System.Drawing.Point(213, 323);
            this.btnRemoveCommand.Name = "btnRemoveCommand";
            this.btnRemoveCommand.Size = new System.Drawing.Size(201, 48);
            this.btnRemoveCommand.TabIndex = 9;
            this.btnRemoveCommand.Text = "移除选中";
            this.btnRemoveCommand.UseVisualStyleBackColor = true;
            this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveCommand_Click);
            // 
            // btnAddCommand
            // 
            this.btnAddCommand.Location = new System.Drawing.Point(12, 323);
            this.btnAddCommand.Name = "btnAddCommand";
            this.btnAddCommand.Size = new System.Drawing.Size(195, 48);
            this.btnAddCommand.TabIndex = 8;
            this.btnAddCommand.Text = "新增";
            this.btnAddCommand.UseVisualStyleBackColor = true;
            this.btnAddCommand.Click += new System.EventHandler(this.btnAddCommand_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(332, 39);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(74, 21);
            this.btnFile.TabIndex = 6;
            this.btnFile.Text = "浏览...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(56, 14);
            this.txtCommand.MaxLength = 20;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(350, 21);
            this.txtCommand.TabIndex = 5;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "命令：";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label2);
            this.GroupBox2.Controls.Add(this.txtFileName);
            this.GroupBox2.Controls.Add(this.btnFile);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.txtCommand);
            this.GroupBox2.Location = new System.Drawing.Point(4, 250);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(416, 67);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "新增命令";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "文件：";
            // 
            // CustomCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 379);
            this.Controls.Add(this.btnRemoveCommand);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btnAddCommand);
            this.Controls.Add(this.GroupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomCommands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义命令";
            this.Load += new System.EventHandler(this.CustomCommands_Load);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomCommads)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox txtCommand;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.DataGridView dtCustomCommads;
		internal System.Windows.Forms.Button btnRemoveCommand;
		internal System.Windows.Forms.Button btnAddCommand;
		internal System.Windows.Forms.Button btnFile;
        internal System.Windows.Forms.TextBox txtFileName;
		internal System.Windows.Forms.GroupBox GroupBox2;
        private System.ComponentModel.IContainer components;
        internal Label label2;
        private DataGridViewTextBoxColumn command;
        private DataGridViewTextBoxColumn file;
	}
	
}
