using System;
using PCRemote.Core.Contracts;

namespace PCRemote.Core.Commands
{
    public class VolUnMuteCommand : VolCommandBase, ICommand
    {

        #region ICommand Members

        public void Execute(Entities.CommandContext context)
        {
            SendComment(context, "#PCң����#�Ѿ�����ȡ���������������뷢΢��������$$�������ݡ�");
            SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_MUTE));
        }

        #endregion
    }
}