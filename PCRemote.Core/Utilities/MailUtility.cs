using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Enums;

namespace PCRemote.Core.Utilities
{
    public class MailUtility : IMailUtility
    {
        readonly EmailAccount _account;

        public MailUtility(EmailAccount account)
        {
            _account = account;
        }

        #region IMailUtility Members

        public EmailAccount Account
        {
            get { return _account; }
        }

        public void Send(string to, string title, string body, params string[] files)
        {
            var toList = to.Split(':');

            IEnumerable<Attachment> attachmentList = new List<Attachment>();
            if(files != null)
                attachmentList = files.Select(file => new Attachment(file)).ToList();

            Send(toList, new List<string>(), attachmentList, title, body, true, EmailPriorityEnum.Normal, Encoding.UTF8);
        }

        #endregion

        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="toEmailAddress">发送目标邮箱列表</param>
        /// <param name="toCcEmailAddress"></param>
        /// <param name="attachmentList">电子邮件附件列表</param>
        /// <param name="emailSubject">邮件标题</param>
        /// <param name="emailBody">邮件内容</param>
        /// <param name="isBodyHtml">是否HTML内容 默认为是</param>
        /// <param name="emailPriority">邮件优先级</param>
        /// <param name="encodingType">编码格式</param>
        void Send(IEnumerable<string> toEmailAddress, IEnumerable<string> toCcEmailAddress, IEnumerable<Attachment> attachmentList, string emailSubject, string emailBody, bool isBodyHtml, EmailPriorityEnum emailPriority, Encoding encodingType)
        {
            #region///邮件发送

            var mails = new MailMessage();

            //编码类型
            Encoding emaiEncodingType = encodingType;

            //添加发送地址
            foreach (string to in toEmailAddress)
            {
                mails.To.Add(to);
            }

            // 添加抄送地址
            foreach (string to in toCcEmailAddress)
            {
                mails.CC.Add(to);
            }

            //添加附件  
            foreach (Attachment attachment in attachmentList)
            {
                mails.Attachments.Add(attachment);
            }

            mails.From = new MailAddress(_account.AccountName, _account.DisplayName, emaiEncodingType);
            mails.Subject = emailSubject;
            mails.SubjectEncoding = emaiEncodingType;
            mails.Body = HttpUtility.HtmlDecode(emailBody);
            mails.BodyEncoding = emaiEncodingType;
            //设置邮件是否为HTML格式
            mails.IsBodyHtml = isBodyHtml;
            //设置邮件优级先级
            switch (emailPriority)
            {
                case EmailPriorityEnum.Normal:
                    mails.Priority = MailPriority.Normal;
                    break;
                case EmailPriorityEnum.Low:
                    mails.Priority = MailPriority.Low;
                    break;
                default:
                    mails.Priority = MailPriority.High;
                    break;
            }

            var client = new SmtpClient
            {
                Credentials = new NetworkCredential(_account.AccountName, _account.AccountPassword),
                Port = _account.Port,
                Host = _account.SmtpServer,
                EnableSsl = _account.IsEnableSSL
            };

            client.Send(mails);

            #endregion
        }
    }
}