#region using

using System;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class VolIncCommand : VolCommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PCң����#�Ѿ������Ӵ���������С�������뷢΢������С����$$�������ݡ�");
            for (int i = 0; i < 10; i++)
            {
                SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_UP));
            }
        }

        #endregion
    }
}