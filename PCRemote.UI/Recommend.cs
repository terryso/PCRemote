using System;
using System.Windows.Forms;
using PCRemote.UI.Properties;
using SocialKit.LightRest.OAuth;
using WeiboSDK;

namespace PCRemote.UI
{
    public partial class Recommend : Form
    {
        Consumer consumer = new Consumer
        {
            Key = "59261381",
            Secret = "b8ead84f1d63e6518b6cb51d9885cb7b",
            RequestTokenUri = "http://api.t.sina.com.cn/oauth/request_token",
            AuthorizeUri = "http://api.t.sina.com.cn/oauth/authorize",
            AccessTokenUri = "http://api.t.sina.com.cn/oauth/access_token"
        };

        public Recommend()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.Default.Username) || string.IsNullOrEmpty(Settings.Default.Password))
            {
                MessageBox.Show("请先设置新浪微博账号和密码");
                return;
            }

            try
            {
                var accessToken = new AccessToken(consumer, Settings.Default.AccessToken, Settings.Default.AccessTokenSecret);
                var client = new WeiboClient(accessToken, ResultFormat.json);

                var content = txtContent.Text;
                if (string.IsNullOrEmpty(content))
                    content = "推荐应用【PC遥控器】http://t.sina.com.cn/app/detail/5CRj7";

                client.UpdateStatus(content);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}