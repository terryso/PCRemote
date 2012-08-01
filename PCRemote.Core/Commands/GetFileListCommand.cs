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
                SendComment(context, "��������˺Ż�û���úá�");

            var template = Environment.CurrentDirectory + "\\Templates\\FileListTemplate.html";

            //��ȡ�ļ�����System.Text.Encoding.Default�����Խ��������������
            var sr = new StreamReader(template, Encoding.Default);
            var body = sr.ReadToEnd();

            //�ر��ļ���
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
                    sb.AppendFormat("<tr class='even'><td>{0}</td><td>{1}</td><td>�ļ���</td><td></td></tr>", directory.Name, directory.CreationTime);
                else
                    sb.AppendFormat("<tr class='odd'><td>{0}</td><td>{1}</td><td>�ļ���</td><td></td></tr>", directory.Name, directory.CreationTime);

            }

            foreach (var file in files)
            {
                ++count;
                if(IsEven(count))
                    sb.AppendFormat("<tr class='even'><td>{0}</td><td>{1}</td><td>�ļ�</td><td>{2}</td></tr>", file.Name, file.LastWriteTime, file.Length);
                else
                    sb.AppendFormat("<tr class='odd'><td>{0}</td><td>{1}</td><td>�ļ�</td><td>{2}</td></tr>", file.Name, file.LastWriteTime, file.Length);

            }

            var title = "��ȡĿ¼��{0}������ϸ��Ϣ@{1}".FormatWith(context.CommandParameter, DateTime.Now);
            body = body.Replace("{FileList}", sb.ToString());
            var to = context.To;

            SendComment(context, "#PCң����#���ڷ���Ŀ¼��{0}������ϸ��Ϣ����ָ����Email�У����һ����ա�".FormatWith(context.CommandParameter));
            context.MailUtility.Send(to, title, body);
        }

        private bool IsEven(int num)
        {
            return (num%2) == 0;
        }

        #endregion
    }
}