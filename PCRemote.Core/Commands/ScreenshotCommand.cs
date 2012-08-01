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

            var temp = Environment.GetEnvironmentVariable("TEMP");
            var picPath = string.Format("{0}\\{1}.jpg", temp, Guid.NewGuid());
            ImageUtility.CaptureDesktop(picPath);

            if (context.SendPhotoByEmail)
            {
                SendComment(context, "#PC遥控器#正在把你的屏幕截图发送到你指定的Email中，请过一会去查收。");
                SendPhotoByEmail(context, picPath);
            }
            else
            {
                SendComment(context, "#PC遥控器#正在上传你的屏幕截图，一会将会出现在你的最新微博中。");
                context.WeiboService.SendWeiboWithPicture("我正在使用#PC遥控器#分享我的屏幕截图 " + DateTime.Now.ToLongTimeString(), picPath);
            }
        }

        static void SendPhotoByEmail(CommandContext context, string picPath)
        {
            var title = "我的电脑桌面截图@" + DateTime.Now;
            var body = "此图由<a href='http://weibo.com/k/PC%25E9%2581%25A5%25E6%258E%25A7%25E5%2599%25A8?refer=Index_mark'>#PC遥控器#</a>自动发送，请不要回复。<br/>"  +
                        "请问题请<a href='http://weibo.com/suchuanyi'>@四眼蒙面侠</a>";
            var to = context.To;

            context.MailUtility.Send(to, title, body, picPath);
        }

        #endregion
    }
}