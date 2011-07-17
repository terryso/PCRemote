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
            SendComment(context, "#PCң����#�����ϴ������Ļ��ͼ��һ�Ὣ��������������΢���С�");

            var temp = Environment.GetEnvironmentVariable("TEMP");
            var picPath = string.Format("{0}\\{1}.jpg", temp, Guid.NewGuid());
            ImageUtility.CaptureDesktop(picPath);

            context.WeiboService.SendWeiboWithPicture("������ʹ��#PCң����#�����ҵ���Ļ��ͼ " + DateTime.Now.ToLongTimeString(), picPath);
        }

        #endregion
    }
}