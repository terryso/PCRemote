using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PCRemote.UI.Properties;
using SocialKit.LightRest;
using SocialKit.LightRest.OAuth;

namespace PCRemote.UI
{
    public partial class frmOAuth : Form
    {
        Consumer consumer = new Consumer
        {
            Key = "59261381",
            Secret = "b8ead84f1d63e6518b6cb51d9885cb7b",
            RequestTokenUri = "http://api.t.sina.com.cn/oauth/request_token",
            AuthorizeUri = "http://api.t.sina.com.cn/oauth/authorize",
            AccessTokenUri = "http://api.t.sina.com.cn/oauth/access_token"
        };

        private RequestToken requestToken;
        private string pinText;

        public frmOAuth()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

            Thread.Sleep(3500);
            pinText = Interaction.InputBox("Please enter the PIN which you got from the before opened website:", "Enter PIN for Authorization", "", -1, -1);

            //pictureBox1.Visible = false;
            //txtPin.Visible = true;  
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            var accessToken = requestToken.ToAccessToken(this.textBox1.Text);
            Settings.Default.AccessToken = accessToken.Token;
            Settings.Default.AccessTokenSecret = accessToken.Secret;

            Settings.Default.Save();

            MessageBox.Show("账号验证成功");

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            requestToken = consumer.GetRequestToken();
            var authorizeUri = requestToken.GetNormalizedAuthorizeUri();

            Process.Start(authorizeUri);
        }
    }
}
