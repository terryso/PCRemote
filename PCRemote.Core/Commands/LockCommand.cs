#region using

using System.Diagnostics;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class LockCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#已经帮您锁住您的计算机的屏幕。");
            Process.Start("rundll32.exe", "user32.dll,LockWorkStation");
        }

        #endregion
    }
}