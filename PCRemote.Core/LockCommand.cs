using System.Diagnostics;

namespace PCRemote.Core
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