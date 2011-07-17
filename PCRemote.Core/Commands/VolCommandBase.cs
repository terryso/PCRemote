#region using

using System;
using System.Runtime.InteropServices;

#endregion

namespace PCRemote.Core.Commands
{
    public class VolCommandBase : CommandBase
    {
        protected const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        protected const int APPCOMMAND_VOLUME_UP = 0xA0000;
        protected const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        protected const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}