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
        /// �ʼ�����
        /// </summary>
        /// <param name="toEmailAddress">����Ŀ�������б�</param>
        /// <param name="toCcEmailAddress"></param>
        /// <param name="attachmentList">�����ʼ������б�</param>
        /// <param name="emailSubject">�ʼ�����</param>
        /// <param name="emailBody">�ʼ�����</param>
        /// <param name="isBodyHtml">�Ƿ�HTML���� Ĭ��Ϊ��</param>
        /// <param name="emailPriority">�ʼ����ȼ�</param>
        /// <param name="encodingType">�����ʽ</param>
        void Send(IEnumerable<string> toEmailAddress, IEnumerable<string> toCcEmailAddress, IEnumerable<Attachment> attachmentList, string emailSubject, string emailBody, bool isBodyHtml, EmailPriorityEnum emailPriority, Encoding encodingType)
        {
            #region///�ʼ�����

            var mails = new MailMessage();

            //��������
            Encoding emaiEncodingType = encodingType;

            //��ӷ��͵�ַ
            foreach (string to in toEmailAddress)
            {
                mails.To.Add(to);
            }

            // ��ӳ��͵�ַ
            foreach (string to in toCcEmailAddress)
            {
                mails.CC.Add(to);
            }

            //��Ӹ���  
            foreach (Attachment attachment in attachmentList)
            {
                mails.Attachments.Add(attachment);
            }

            mails.From = new MailAddress(_account.AccountName, _account.DisplayName, emaiEncodingType);
            mails.Subject = emailSubject;
            mails.SubjectEncoding = emaiEncodingType;
            mails.Body = HttpUtility.HtmlDecode(emailBody);
            mails.BodyEncoding = emaiEncodingType;
            //�����ʼ��Ƿ�ΪHTML��ʽ
            mails.IsBodyHtml = isBodyHtml;
            //�����ʼ��ż��ȼ�
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