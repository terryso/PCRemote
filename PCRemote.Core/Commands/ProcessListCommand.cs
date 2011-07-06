#region using

using System;
using PCRemote.Core.Contracts;
using WeiboSDK.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class ProcessListCommand : ICommand
    {
        readonly IWeiboService _service;

        public ProcessListCommand(IWeiboService service)
        {
            _service = service;
        }

        #region ICommand Members

        public void Execute()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}