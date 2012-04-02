#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class LogoffCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#正在帮您注销您的计算机。");
            Process.Start("shutdown", "-l -f");
        }

        #endregion
    }
}