#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class ShutdownCommand : CommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#将会在5分钟之后帮您关闭您的计算机。如果需要终止重启，请发微博：终止关机$$任意内容。");
            Process.Start("shutdown", "-s -f -t 300");
        }

        #endregion
    }
}
