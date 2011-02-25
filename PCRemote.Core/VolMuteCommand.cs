using System;
using System.Windows.Forms;

namespace PCRemote.Core
{
    public class VolMuteCommand : VolCommandBase, ICommand
    {
        readonly Control _control;


        public VolMuteCommand(Control control)
        {
            _control = control;
        }

        #region Implementation of ICommand

        public void Execute()
        {
            SendMessageW(_control.Handle, WM_APPCOMMAND, _control.Handle, new IntPtr(APPCOMMAND_VOLUME_MUTE));
        }

        #endregion
    }
}