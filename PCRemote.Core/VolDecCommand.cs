#region using

using System;
using System.Windows.Forms;

#endregion

namespace PCRemote.Core
{
    public class VolDecCommand : VolCommandBase, ICommand
    {
        readonly Control _control;

        public VolDecCommand(Control control)
        {
            _control = control;
        }

        #region Implementation of ICommand

        public void Execute()
        {
            SendMessageW(_control.Handle, WM_APPCOMMAND, _control.Handle, new IntPtr(APPCOMMAND_VOLUME_DOWN));
        }

        #endregion
    }
}