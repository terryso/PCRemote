using System;
using PCRemote.Core.Contracts;

namespace PCRemote.Core.Entities
{
    public class CommandContext
    {
        public string WeiboId { get; set; }
        public IWeiboService WeiboService { get; set; }
        public IMailUtility MailUtility { get; set; }
        public IntPtr Handle { get; set; }
        public string CommandParameter { get; set; }
        public bool SendPhotoByEmail { get; set; }
        public string To { get; set; }
        public string DownloadPath { get; set; }
    }
}