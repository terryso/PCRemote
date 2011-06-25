using System;
using WeiboSDK.Contracts;

namespace PCRemote.Core
{
    public class ProcessListCommand : ICommand
    {
        private readonly IWeiboClient _client;

        public ProcessListCommand(IWeiboClient client)
        {
            _client = client;
        }

        #region ICommand Members

        public void Execute()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}