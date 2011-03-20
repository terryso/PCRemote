namespace PCRemote.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tmrPCRemote = new System.Windows.Forms.Timer(this.components);
            this.RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTooStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.settingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.customCommandMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecommend = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomePage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSkill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.helpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupAccount = new System.Windows.Forms.GroupBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.menuSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.RightMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.groupAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(73, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(155, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密  码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(155, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(174, 61);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tmrPCRemote
            // 
            this.tmrPCRemote.Interval = 7000;
            this.tmrPCRemote.Tick += new System.EventHandler(this.tmrPCRemote_Tick);
            // 
            // RightMenu
            // 
            this.RightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStrip,
            this.exitTooStrip});
            this.RightMenu.Name = "RightMenu";
            this.RightMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // settingToolStrip
            // 
            this.settingToolStrip.Name = "settingToolStrip";
            this.settingToolStrip.Size = new System.Drawing.Size(100, 22);
            this.settingToolStrip.Text = "设置";
            this.settingToolStrip.Click += new System.EventHandler(this.settingToolStrip_Click);
            // 
            // exitTooStrip
            // 
            this.exitTooStrip.Name = "exitTooStrip";
            this.exitTooStrip.Size = new System.Drawing.Size(100, 22);
            this.exitTooStrip.Text = "退出";
            this.exitTooStrip.Click += new System.EventHandler(this.exitTooStrip_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "应用正在启动...";
            this.NotifyIcon.BalloonTipTitle = "微博遥控器状态：";
            this.NotifyIcon.ContextMenuStrip = this.RightMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Starting...";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingMenu,
            this.menuHelp});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(299, 25);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // settingMenu
            // 
            this.settingMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customCommandMenu,
            this.settingSeparator,
            this.exitMenu});
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(59, 21);
            this.settingMenu.Text = "设置(&S)";
            // 
            // customCommandMenu
            // 
            this.customCommandMenu.Name = "customCommandMenu";
            this.customCommandMenu.Size = new System.Drawing.Size(136, 22);
            this.customCommandMenu.Text = "自定义命令";
            this.customCommandMenu.Click += new System.EventHandler(this.customCommandMenu_Click);
            // 
            // settingSeparator
            // 
            this.settingSeparator.Name = "settingSeparator";
            this.settingSeparator.Size = new System.Drawing.Size(133, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(136, 22);
            this.exitMenu.Text = "退出(&X)";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSupport,
            this.menuRecommend,
            this.menuHomePage,
            this.menuSkill,
            this.menuCommand,
            this.helpSeparator,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(61, 21);
            this.menuHelp.Text = "帮助(&H)";
            // 
            // menuRecommend
            // 
            this.menuRecommend.Name = "menuRecommend";
            this.menuRecommend.Size = new System.Drawing.Size(152, 22);
            this.menuRecommend.Text = "推荐给粉丝(&R)";
            this.menuRecommend.Click += new System.EventHandler(this.menuRecommend_Click);
            // 
            // menuHomePage
            // 
            this.menuHomePage.Name = "menuHomePage";
            this.menuHomePage.Size = new System.Drawing.Size(152, 22);
            this.menuHomePage.Text = "产品主页(&P)";
            this.menuHomePage.Click += new System.EventHandler(this.menuHomePage_Click);
            // 
            // menuSkill
            // 
            this.menuSkill.Name = "menuSkill";
            this.menuSkill.Size = new System.Drawing.Size(152, 22);
            this.menuSkill.Text = "使用技巧(&K)";
            this.menuSkill.Click += new System.EventHandler(this.menuSkill_Click);
            // 
            // menuCommand
            // 
            this.menuCommand.Name = "menuCommand";
            this.menuCommand.Size = new System.Drawing.Size(152, 22);
            this.menuCommand.Text = "命令列表(&C)";
            this.menuCommand.Click += new System.EventHandler(this.menuCommand_Click);
            // 
            // helpSeparator
            // 
            this.helpSeparator.Name = "helpSeparator";
            this.helpSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(152, 22);
            this.menuAbout.Text = "关于(&A)";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // groupAccount
            // 
            this.groupAccount.Controls.Add(this.chkAutoStart);
            this.groupAccount.Controls.Add(this.label1);
            this.groupAccount.Controls.Add(this.label2);
            this.groupAccount.Controls.Add(this.txtUsername);
            this.groupAccount.Controls.Add(this.txtPassword);
            this.groupAccount.Location = new System.Drawing.Point(21, 42);
            this.groupAccount.Name = "groupAccount";
            this.groupAccount.Size = new System.Drawing.Size(258, 130);
            this.groupAccount.TabIndex = 5;
            this.groupAccount.TabStop = false;
            this.groupAccount.Text = "新浪微博账号设置";
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(73, 97);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(96, 16);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "开机自动登录";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // menuSupport
            // 
            this.menuSupport.Name = "menuSupport";
            this.menuSupport.Size = new System.Drawing.Size(152, 22);
            this.menuSupport.Text = "捐助(&J)";
            this.menuSupport.Click += new System.EventHandler(this.menuSupport_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 264);
            this.ContextMenuStrip = this.RightMenu;
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.groupAccount);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC遥控器";
            this.Load += new System.EventHandler(this.Main_Load);
            this.RightMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.groupAccount.ResumeLayout(false);
            this.groupAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer tmrPCRemote;
        private System.Windows.Forms.ContextMenuStrip RightMenu;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.GroupBox groupAccount;
        internal System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem settingMenu;
        private System.Windows.Forms.ToolStripMenuItem customCommandMenu;
        private System.Windows.Forms.ToolStripSeparator settingSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem settingToolStrip;
        private System.Windows.Forms.ToolStripMenuItem exitTooStrip;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuCommand;
        private System.Windows.Forms.ToolStripSeparator helpSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuSkill;
        private System.Windows.Forms.ToolStripMenuItem menuHomePage;
        private System.Windows.Forms.ToolStripMenuItem menuRecommend;
        private System.Windows.Forms.ToolStripMenuItem menuSupport;
    }
}

