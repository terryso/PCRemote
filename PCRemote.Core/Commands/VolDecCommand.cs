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
            SendComment(context, "#PCң����#�Ѿ�������С�������Ӵ��������뷢΢�����Ӵ�����$$�������ݡ�");
            for (int i = 0; i < 10; i++)
            {
                SendMessageW(context.Handle, WM_APPCOMMAND, context.Handle, new IntPtr(APPCOMMAND_VOLUME_DOWN));
            }
        }

        #endregion
    }
}