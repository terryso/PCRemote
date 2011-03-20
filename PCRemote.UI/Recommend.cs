using System;
using System.Windows.Forms;
using PCRemote.UI.Properties;
using Weibo;

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
            if (string.IsNullOrEmpty(Settings.Default.Username) || string.IsNullOrEmpty(Settings.Default.Password))
            {
                MessageBox.Show("请先设置新浪微博账号和密码");
                return;
            }

            try
            {
                var client = new NormalWeiboClient(Settings.Default.Username, Settings.Default.Password, ResultFormat.json);
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