#region using

using System;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class VolDecCommand : VolCommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#已经帮您减小音量。加大音量，请发微博：加大音量$$任意内容。");
            for (int i = 0; i < 10; i++)
            {
                SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_DOWN));
            }
        }

        #endregion
    }
}