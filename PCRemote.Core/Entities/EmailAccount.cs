namespace PCRemote.Core.Entities
{
    public class EmailAccount
    {
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public string SmtpServer { get; set; }
        public bool IsEnableSSL { get; set; }
        public string DisplayName { get; set; }

        private int _port = 25;
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
    }
}