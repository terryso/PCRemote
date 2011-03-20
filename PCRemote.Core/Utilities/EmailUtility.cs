using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace PCRemote.Core.Utilities
{
    /// <summary>
    ///  邮件优先级：high（高）、low(低)、normal(正常)
    /// </summary>
    public enum EmailPriorityEnum
    {
        #region///邮件优先级

        /// <summary>
        /// 高
        /// </summary>
        [Description("高")] High,
        /// <summary>
        /// 低
        /// </summary>
        [Description("低")] Low,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")] Normal

        #endregion
    }

    public class EmailUtility
    {
        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="toEmailAddress">发送目标邮箱列表</param>
        /// <param name="toCcEmailAddress"></param>
        /// <param name="attachmentList">电子邮件附件列表</param>
        /// <param name="fromEmailAddress">发送账户</param>
        /// <param name="fromEmailPassword">发送密码</param>
        /// <param name="emailPersonName">发件人名</param>
        /// <param name="emailSubject">邮件标题</param>
        /// <param name="emailBody">邮件内容</param>
        /// <param name="isBodyHtml">是否HTML内容 默认为是</param>
        /// <param name="emailPriority">邮件优先级</param>
        /// <param name="port">邮箱端口号</param>
        /// <param name="emailHostName">邮箱服务器地址</param>
        /// <param name="isEnableSsl">邮件是否加密:true(加密),false(不加密)  默认为true</param>
        /// <param name="encodingType">编码格式</param>
        public void Send(IList<string> toEmailAddress, IList<string> toCcEmailAddress, IList<Attachment> attachmentList,
                         string fromEmailAddress, string fromEmailPassword, string emailPersonName, string emailSubject,
                         string emailBody, bool isBodyHtml, EmailPriorityEnum emailPriority, int port,
                         string emailHostName, bool isEnableSsl, Encoding encodingType)
        {
            #region///邮件发送

            var mails = new MailMessage();

            //编码类型
            var emaiEncodingType = encodingType;

            //添加发送地址
            foreach (var to in toEmailAddress)
            {
                mails.To.Add(to);
            }

            // 添加抄送地址
            foreach (var to in toCcEmailAddress)
            {
                mails.CC.Add(to);
            }

            //添加附件  
            foreach (var attachment in attachmentList)
            {
                mails.Attachments.Add(attachment);
            }

            mails.From = new MailAddress(fromEmailAddress, emailPersonName, emaiEncodingType);
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
                                 Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                                 Port = port,
                                 Host = emailHostName,
                                 EnableSsl = isEnableSsl
                             };

            client.Send(mails);

            #endregion
        }
    }
}