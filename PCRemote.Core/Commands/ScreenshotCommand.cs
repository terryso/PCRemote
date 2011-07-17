#region using

using System;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;
using WeiboSDK.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class ScreenshotCommand : CommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#正在上传你的屏幕截图，一会将会出现在你的最新微博中。");

            var temp = Environment.GetEnvironmentVariable("TEMP");
            var picPath = string.Format("{0}\\{1}.jpg", temp, Guid.NewGuid());
            ImageUtility.CaptureDesktop(picPath);

            context.WeiboService.SendWeiboWithPicture("我正在使用#PC遥控器#分享我的屏幕截图 " + DateTime.Now.ToLongTimeString(), picPath);
        }

        #endregion
    }
}