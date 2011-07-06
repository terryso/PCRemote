#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class AbortShutdownCommand : ICommand
    {
        #region Implementation of ICommand

        public void Execute()
        {
            Process.Start("shutdown", "-a");
        }

        #endregion
    }
}