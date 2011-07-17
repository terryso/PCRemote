#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class AbortShutdownCommand : CommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#已经停止关闭您的计算机。");
            Process.Start("shutdown", "-a");
        }

        #endregion
    }
}