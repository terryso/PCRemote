using System;
using System.IO;
using System.Text;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using WeiboSDK.Extensions;

namespace PCRemote.Core.Commands
{
    public class GetFileListCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            if (context.MailUtility.Account.AccountName.IsNullOrEmpty())
                SendComment(context, "你的邮箱账号还没设置好。");

            var template = Environment.CurrentDirectory + "\\Templates\\FileListTemplate.html";

            //读取文件，“System.Text.Encoding.Default”可以解决中文乱码问题
            var sr = new StreamReader(template, Encoding.Default);
            var body = sr.ReadToEnd();

            //关闭文件流
            sr.Close();

            var rootDir = new DirectoryInfo(context.CommandParameter);
            var files = rootDir.GetFiles("*.*");
            var directories = rootDir.GetDirectories();

            var sb = new StringBuilder();
            var count = 0;
            foreach (var directory in directories)
            {
                ++count;
                if(IsEven(count))
                    sb.AppendFormat("<tr class='even'><td>{0}</td><td>{1}</td><td>文件夹</td><td></td></tr>", directory.Name, directory.CreationTime);
                else
                    sb.AppendFormat("<tr class='odd'><td>{0}</td><td>{1}</td><td>文件夹</td><td></td></tr>", directory.Name, directory.CreationTime);

            }

            foreach (var file in files)
            {
                ++count;
                if(IsEven(count))
                    sb.AppendFormat("<tr class='even'><td>{0}</td><td>{1}</td><td>文件</td><td>{2}</td></tr>", file.Name, file.LastWriteTime, file.Length);
                else
                    sb.AppendFormat("<tr class='odd'><td>{0}</td><td>{1}</td><td>文件</td><td>{2}</td></tr>", file.Name, file.LastWriteTime, file.Length);

            }

            var title = "获取目录‘{0}’的详细信息@{1}".FormatWith(context.CommandParameter, DateTime.Now);
            body = body.Replace("{FileList}", sb.ToString());
            var to = context.To;

            SendComment(context, "#PC遥控器#正在发送目录‘{0}’的详细信息到你指定的Email中，请过一会查收。".FormatWith(context.CommandParameter));
            context.MailUtility.Send(to, title, body);
        }

        private bool IsEven(int num)
        {
            return (num%2) == 0;
        }

        #endregion
    }
}