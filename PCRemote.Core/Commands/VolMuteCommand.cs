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
            SendComment(context, "#PCң����#�Ѿ������ļ������Ϊ������ȡ���������뷢΢����ȡ������$$�������ݡ�");
            SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_MUTE));
        }

        #endregion
    }
}