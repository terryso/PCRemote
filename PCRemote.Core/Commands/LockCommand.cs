#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class LockCommand : ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            Process.Start("rundll32.exe", "user32.dll,LockWorkStation");
        }

        #endregion
    }
}