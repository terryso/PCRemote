#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class LogoffCommand : ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            Process.Start("shutdown", "-l -f");
        }

        #endregion
    }
}