﻿namespace PCRemote.UI
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tmrPCRemote = new System.Windows.Forms.Timer(this.components);
            this.RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTooStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.settingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.customCommandMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.settingSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecommend = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomePage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSkill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.helpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupAccount = new System.Windows.Forms.GroupBox();
            this.chkClear = new System.Windows.Forms.CheckBox();
            this.btnGetPin = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.ddlWeibo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.groupEmail = new System.Windows.Forms.GroupBox();
            this.chkSendPhotoByEmail = new System.Windows.Forms.CheckBox();
            this.txtMyEmailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtDownloadPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tmrClear = new System.Windows.Forms.Timer(this.components);
            this.RightMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.groupAccount.SuspendLayout();
            this.groupEmail.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(258, 66);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tmrPCRemote
            // 
            this.tmrPCRemote.Interval = 60000;
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
            this.menuLogoff,
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
            // menuLogoff
            // 
            this.menuLogoff.Name = "menuLogoff";
            this.menuLogoff.Size = new System.Drawing.Size(136, 22);
            this.menuLogoff.Text = "注销(&L)";
            this.menuLogoff.Click += new System.EventHandler(this.menuLogoff_Click);
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
            // menuSupport
            // 
            this.menuSupport.Name = "menuSupport";
            this.menuSupport.Size = new System.Drawing.Size(152, 22);
            this.menuSupport.Text = "捐助(&J)";
            this.menuSupport.Click += new System.EventHandler(this.menuSupport_Click);
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
            this.groupAccount.Controls.Add(this.chkClear);
            this.groupAccount.Controls.Add(this.btnGetPin);
            this.groupAccount.Controls.Add(this.txtPin);
            this.groupAccount.Controls.Add(this.ddlWeibo);
            this.groupAccount.Controls.Add(this.label2);
            this.groupAccount.Controls.Add(this.label1);
            this.groupAccount.Controls.Add(this.chkAutoStart);
            this.groupAccount.Location = new System.Drawing.Point(21, 46);
            this.groupAccount.Name = "groupAccount";
            this.groupAccount.Size = new System.Drawing.Size(258, 151);
            this.groupAccount.TabIndex = 5;
            this.groupAccount.TabStop = false;
            this.groupAccount.Text = "微博账号设置";
            // 
            // chkClear
            // 
            this.chkClear.AutoSize = true;
            this.chkClear.Checked = true;
            this.chkClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClear.Enabled = false;
            this.chkClear.Location = new System.Drawing.Point(80, 122);
            this.chkClear.Name = "chkClear";
            this.chkClear.Size = new System.Drawing.Size(98, 17);
            this.chkClear.TabIndex = 8;
            this.chkClear.Text = "启用声控命令";
            this.chkClear.UseVisualStyleBackColor = true;
            // 
            // btnGetPin
            // 
            this.btnGetPin.Location = new System.Drawing.Point(174, 68);
            this.btnGetPin.Name = "btnGetPin";
            this.btnGetPin.Size = new System.Drawing.Size(75, 25);
            this.btnGetPin.TabIndex = 7;
            this.btnGetPin.Text = "获取授权码";
            this.btnGetPin.UseVisualStyleBackColor = true;
            this.btnGetPin.Click += new System.EventHandler(this.btnGetPin_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(68, 68);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(100, 20);
            this.txtPin.TabIndex = 6;
            // 
            // ddlWeibo
            // 
            this.ddlWeibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlWeibo.FormattingEnabled = true;
            this.ddlWeibo.Items.AddRange(new object[] {
            "新浪微博",
            "腾讯微博"});
            this.ddlWeibo.Location = new System.Drawing.Point(68, 36);
            this.ddlWeibo.Name = "ddlWeibo";
            this.ddlWeibo.Size = new System.Drawing.Size(100, 21);
            this.ddlWeibo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "授权码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "微  博：";
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(80, 99);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(98, 17);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "开机自动登录";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // groupEmail
            // 
            this.groupEmail.Controls.Add(this.chkSendPhotoByEmail);
            this.groupEmail.Controls.Add(this.txtMyEmailAddress);
            this.groupEmail.Controls.Add(this.label3);
            this.groupEmail.Location = new System.Drawing.Point(21, 212);
            this.groupEmail.Name = "groupEmail";
            this.groupEmail.Size = new System.Drawing.Size(258, 104);
            this.groupEmail.TabIndex = 6;
            this.groupEmail.TabStop = false;
            this.groupEmail.Text = "邮箱设置";
            // 
            // chkSendPhotoByEmail
            // 
            this.chkSendPhotoByEmail.AutoSize = true;
            this.chkSendPhotoByEmail.Location = new System.Drawing.Point(54, 69);
            this.chkSendPhotoByEmail.Name = "chkSendPhotoByEmail";
            this.chkSendPhotoByEmail.Size = new System.Drawing.Size(158, 17);
            this.chkSendPhotoByEmail.TabIndex = 11;
            this.chkSendPhotoByEmail.Text = "通过邮件发送截图和拍照";
            this.chkSendPhotoByEmail.UseVisualStyleBackColor = true;
            // 
            // txtMyEmailAddress
            // 
            this.txtMyEmailAddress.Location = new System.Drawing.Point(80, 30);
            this.txtMyEmailAddress.Name = "txtMyEmailAddress";
            this.txtMyEmailAddress.Size = new System.Drawing.Size(169, 20);
            this.txtMyEmailAddress.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "邮箱地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.txtDownloadPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(21, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件下载";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(200, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(43, 25);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "浏览";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Location = new System.Drawing.Point(80, 30);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.Size = new System.Drawing.Size(114, 20);
            this.txtDownloadPath.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "下载目录：";
            // 
            // tmrClear
            // 
            this.tmrClear.Interval = 60000;
            this.tmrClear.Tick += new System.EventHandler(this.tmrClear_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 504);
            this.ContextMenuStrip = this.RightMenu;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupEmail);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.groupAccount);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.groupEmail.ResumeLayout(false);
            this.groupEmail.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolStripMenuItem menuLogoff;
        private System.Windows.Forms.Button btnGetPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.ComboBox ddlWeibo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupEmail;
        private System.Windows.Forms.CheckBox chkSendPhotoByEmail;
        private System.Windows.Forms.TextBox txtMyEmailAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtDownloadPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkClear;
        private System.Windows.Forms.Timer tmrClear;
    }
}

