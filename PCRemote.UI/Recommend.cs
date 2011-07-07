using System;
using System.Windows.Forms;
using PCRemote.UI.Factories;
using PCRemote.UI.Properties;

namespace PCRemote.UI
{
    public partial class Recommend : Form
    {
        public Recommend()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.Default.AccessToken) || string.IsNullOrEmpty(Settings.Default.AccessTokenSecret))
            {
                MessageBox.Show(@"请先使用微博账号登录");
                return;
            }

            try
            {
                var service = WeiboServiceFactory.CreateInstance();

                var content = txtContent.Text;
                if (string.IsNullOrEmpty(content))
                    content = "推荐应用#PC遥控器# 可以用手机发微博遥控电脑开关机，音量，截图，很有趣的软件，真的很给力！http://suchuanyi.sinaapp.com";

                service.SendWeibo(content);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}