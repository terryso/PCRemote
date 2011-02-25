#region using

using System.Diagnostics;

#endregion

namespace PCRemote.Core
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