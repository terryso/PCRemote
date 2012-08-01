using System.Collections.Generic;
using NUnit.Framework;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

namespace PCRemote.Tests
{
    [TestFixture]
    public class EmailUtilityTests
    {
        [Test]
        public void Send_Email_From_Gmail_Test()
        {
            // Arrange
            var account = new EmailAccount
            {
                AccountName = "pcremotemaster@gmail.com",
                AccountPassword = "pcremotemaster",
                SmtpServer = "smtp.gmail.com",
                IsEnableSSL = true,
                Port = 587
            };

            IMailUtility mail = new MailUtility(account);

            // Act
            mail.Send("oxtiger@gmail.com", "gmail test 587", "test body", @"L:\Photo\007-»Ê¼Ò¶Ä³¡\bond_WP_1_1280x1024.jpg");
            //mail.Send("oxtiger@gmail.com", "gmail test 587", "test body");

            // Assert

        }
    }
}