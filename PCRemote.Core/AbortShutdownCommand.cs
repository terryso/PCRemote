#region using

using System.Diagnostics;

#endregion

namespace PCRemote.Core
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