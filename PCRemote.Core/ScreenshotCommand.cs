using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using PCRemote.Core.Utilities;
using Weibo.Contracts;

namespace PCRemote.Core
{
    public class ScreenshotCommand : ICommand
    {
        readonly IWeiboClient _client;

        public ScreenshotCommand(IWeiboClient client)
        {
            _client = client;
        }

        #region Implementation of ICommand

        public void Execute()
        {
	    //todo:加入一些注释
            var temp = Environment.GetEnvironmentVariable("TEMP");
            var picPath = temp + "\\" + Guid.NewGuid() + ".jpg";
            ImageUtility.CaptureDesktop(picPath);

            _client.UploadStatus("我正在使用#PC遥控器#分享我的屏幕截图 " + DateTime.Now.ToLongTimeString(), picPath); 
        }

        #endregion
    }
}