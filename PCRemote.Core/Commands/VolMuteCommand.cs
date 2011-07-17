#region using

using System;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class VolMuteCommand : VolCommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#已经将您的计算机设为静音。取消静音，请发微博：取消静音$$任意内容。");
            SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_MUTE));
        }

        #endregion
    }
}