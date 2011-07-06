#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class ShutdownCommand : ICommand
    {
        #region Implementation of ICommand

        public void Execute()
        {
            Process.Start("shutdown", "-s -f -t 300");
        }

        #endregion
    }
}