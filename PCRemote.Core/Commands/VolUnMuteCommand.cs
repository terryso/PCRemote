using System;
using PCRemote.Core.Contracts;

namespace PCRemote.Core.Commands
{
    public class VolUnMuteCommand : VolCommandBase, ICommand
    {

        #region ICommand Members

        public void Execute(Entities.CommandContext context)
        {
            SendComment(context, "#PC遥控器#已经帮您取消静音。静音，请发微博：静音$$任意内容。");
            SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_MUTE));
        }

        #endregion
    }
}