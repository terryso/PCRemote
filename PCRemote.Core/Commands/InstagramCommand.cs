#region using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

#endregion

namespace PCRemote.Core.Commands
{
    public class InstagramCommand : CommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            var parameters = context.CommandParameter.Split('|');
            if (parameters.Length == 0)
                throw new ArgumentNullException();

            var user = string.Empty;
            var count = 0;
            var sendToEmail = false;

            switch (parameters.Length)
            {
                case 1:
                    user = parameters[0].Trim();
                    break;
                case 2:
                    user = parameters[0].Trim();
                    count = Convert.ToInt32(parameters[1].Trim());
                    break;
                case 3:
                    user = parameters[0].Trim();
                    count = Convert.ToInt32(parameters[1].Trim());
                    if (parameters[2].Trim() == "1")
                        sendToEmail = true;
                    break;
            }

            SendComment(context, string.Format("#PCң����# ��ʼΪ������Instagram���û� {0} ����Ƭ��ͼƬ�п��ܺܶ࣬�����ĵȺ򡣡���", user));

            var graber = new InstagramGraber();
            var images = graber.Grab(user, count);

            var downDirectory = string.Format("{0}\\Instagram\\{1}", context.DownloadPath, user);
            if (!Directory.Exists(downDirectory))
                Directory.CreateDirectory(downDirectory);

            var downPara = new DownloadParameter();
            var files = new List<string>();
            foreach (var image in images)
            {
                var index = image.LastIndexOf("/");
                var fileName = image.Substring(index);
                downPara.FilePath = string.Format("{0}\\{1}", downDirectory, fileName);
                downPara.Url = image;

                if(File.Exists(downPara.FilePath))
                    continue;

                NetworkUtility.DownloadFile(downPara);
                files.Add(downPara.FilePath);
            }

            var page = files.Count/100 + 1;
            if(sendToEmail)
            {
                for (var i = 0; i < page; i++)
                {
                    var filesToSend = files.Take(100).Skip(i*100).ToArray();
                    SendPhotoByEmail(context, filesToSend);
                }
            }
            

            SendComment(context, string.Format("��Ƭ������ɡ�����һ��������{0}����Ƭ��", images.Count));
        }

        #endregion

        static void SendPhotoByEmail(CommandContext context, string[] pics)
        {
            var title = "Instagram ͼƬ����@" + DateTime.Now;
            var body = "���ʼ���<a href='http://weibo.com/k/PC%25E9%2581%25A5%25E6%258E%25A7%25E5%2599%25A8?refer=Index_mark'>#PCң����#</a>�Զ����ͣ��벻Ҫ�ظ���<br/>" +
                        "��������<a href='http://weibo.com/suchuanyi'>@����������</a>";
            var to = context.To;

            context.MailUtility.Send(to, title, body, pics);
        }
    }
}