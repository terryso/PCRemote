#region using

using System;
using System.Windows.Forms;
using PCRemote.Core.Contracts;

#endregion

namespace PCRemote.Core.Commands
{
    public class VolIncCommand : VolCommandBase, ICommand
    {
        readonly Control _control;

        public VolIncCommand(Control control)
        {
            _control = control;
        }

        #region Implementation of ICommand

        public void Execute()
        {
            for (int i = 0; i < 10; i++)
            {
                SendMessageW(_control.Handle, WM_APPCOMMAND, _control.Handle, new IntPtr(APPCOMMAND_VOLUME_UP));
            }
        }

        #endregion
    }
}