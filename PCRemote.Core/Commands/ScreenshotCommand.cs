#region using

using System;
using PCRemote.Core.Contracts;
using PCRemote.Core.Utilities;
using WeiboSDK.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class ScreenshotCommand : ICommand
    {
        readonly IWeiboService _service;

        public ScreenshotCommand(IWeiboService service)
        {
            _service = service;
        }

        #region Implementation of ICommand

        public void Execute()
        {
            var temp = Environment.GetEnvironmentVariable("TEMP");
            var picPath = temp + "\\" + Guid.NewGuid() + ".jpg";
            ImageUtility.CaptureDesktop(picPath);

            _service.SendWeiboWithPicture("我正在使用#PC遥控器#分享我的屏幕截图 " + DateTime.Now.ToLongTimeString(), picPath);
        }

        #endregion
    }
}