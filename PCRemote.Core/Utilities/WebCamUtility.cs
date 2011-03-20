using System;
using System.Runtime.InteropServices;

namespace PCRemote.Core.Utilities
{
    public class WebCamUtility
    {
        private IntPtr lwndC;
        private IntPtr mControlPtr;
        private int mHeight;
        private int mWidth;

        public WebCamUtility(IntPtr handle, int width, int height)
        {
            this.mControlPtr = handle;
            this.mWidth = width;
            this.mHeight = height;
        }

        public void CloseWebcam()
        {
            SendMessage(this.lwndC, 0x40b, (short) 0, 0);
        }

        public void GrabImage(IntPtr hWndC, string path)
        {
            SendMessage(this.lwndC, 0x419, (short) 0, Marshal.StringToHGlobalAnsi(path).ToInt32());
        }

        public void StartWebCam()
        {
            byte[] lpszName = new byte[100];
            byte[] lpszVer = new byte[100];
            capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100);
            this.lwndC = capCreateCaptureWindowA(lpszName, 0x50000000, 0, 0, this.mWidth, this.mHeight, this.mControlPtr, 0);
            if (SendMessage(this.lwndC, 0x40a, (short) 0, 0))
            {
                SendMessage(this.lwndC, 0x434, (short) 100, 0);
                SendMessage(this.lwndC, 0x432, true, 0);
            }
        }

        public const int SWP_NOMOVE = 2;
        public const int SWP_NOZORDER = 4;
        public const int WM_CAP_DRIVER_CONNECT = 0x40a;
        public const int WM_CAP_DRIVER_DISCONNECT = 0x40b;
        public const int WM_CAP_SAVEDIB = 0x419;
        public const int WM_CAP_SET_CALLBACK_FRAME = 0x405;
        public const int WM_CAP_SET_PREVIEW = 0x432;
        public const int WM_CAP_SET_PREVIEWRATE = 0x434;
        public const int WM_CAP_SET_VIDEOFORMAT = 0x42d;
        public const int WM_CAP_START = 0x400;
        public const int WM_USER = 0x400;
        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;

        [DllImport("avicap32.dll")]
        public static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);
        [DllImport("avicap32.dll")]
        public static extern bool capGetDriverDescriptionA(short wDriver, byte[] lpszName, int cbName, byte[] lpszVer, int cbVer);
        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int wMsg, short wParam, int lParam);
    }
}