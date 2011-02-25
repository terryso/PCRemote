#region using

using System.Diagnostics;

#endregion

namespace PCRemote.Core
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