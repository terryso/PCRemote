using System.Diagnostics;

namespace PCRemote.Core
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