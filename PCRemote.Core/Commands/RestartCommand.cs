#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class RestartCommand : ICommand
    {
        #region Implementation of ICommand

        public void Execute()
        {
            Process.Start("shutdown", "-r -f -t 300");
        }

        #endregion
    }
}