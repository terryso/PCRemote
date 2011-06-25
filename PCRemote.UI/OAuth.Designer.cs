namespace PCRemote.UI
{
    partial class frmOAuth
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
            this.btnValidate = new System.Windows.Forms.Button();
            this.oAuth = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.oAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(12, 137);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(246, 58);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "验 证";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // oAuth
            // 
            this.oAuth.Controls.Add(this.button1);
            this.oAuth.Controls.Add(this.textBox1);
            this.oAuth.Location = new System.Drawing.Point(12, 12);
            this.oAuth.Name = "oAuth";
            this.oAuth.Size = new System.Drawing.Size(246, 119);
            this.oAuth.TabIndex = 3;
            this.oAuth.TabStop = false;
            this.oAuth.Text = "新浪微博OAuth认证";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "点击获取授权码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 209);
            this.Controls.Add(this.oAuth);
            this.Controls.Add(this.btnValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OAuth认证";
            this.oAuth.ResumeLayout(false);
            this.oAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.GroupBox oAuth;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;

    }
}