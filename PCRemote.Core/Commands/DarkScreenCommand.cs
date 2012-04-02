#region using

using System.Runtime.InteropServices;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;

#endregion

namespace PCRemote.Core.Commands
{
    public class DarkScreenCommand : CommandBase, ICommand
    {
        [DllImport("user32.dll")]
        static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PCң����#�Ѿ������ر�������ʾ����");
            SendMessage(0xFFFF, 0x112, 0xF170, 2);
        }

        #endregion
    }
}