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
                SendComment(context, "#PCң����#���ڰ������Ļ��ͼ���͵���ָ����Email�У����һ��ȥ���ա�");
                SendPhotoByEmail(context, picPath);
            }
            else
            {
                SendComment(context, "#PCң����#�����ϴ������Ļ��ͼ��һ�Ὣ��������������΢���С�");
                context.WeiboService.SendWeiboWithPicture("������ʹ��#PCң����#�����ҵ���Ļ��ͼ " + DateTime.Now.ToLongTimeString(), picPath);
            }
        }

        static void SendPhotoByEmail(CommandContext context, string picPath)
        {
            var title = "�ҵĵ��������ͼ@" + DateTime.Now;
            var body = "��ͼ��<a href='http://weibo.com/k/PC%25E9%2581%25A5%25E6%258E%25A7%25E5%2599%25A8?refer=Index_mark'>#PCң����#</a>�Զ����ͣ��벻Ҫ�ظ���<br/>"  +
                        "��������<a href='http://weibo.com/suchuanyi'>@����������</a>";
            var to = context.To;

            context.MailUtility.Send(to, title, body, picPath);
        }

        #endregion
    }
}