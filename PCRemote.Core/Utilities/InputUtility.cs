using System;
using System.Runtime.InteropServices;

namespace PCRemote.Core.Utilities
{
    public class InputUtility
    {
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32", EntryPoint = "keybd_event", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern long keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);


        private const int KEYEVENTF_KEYUP = 0X2; // Release key


        #region Public Enumerations
        public enum Mouse : ushort
        {
            LeftButton = 0x01,
            RightButton = 0x02,

            MiddleButton = 0x04,    // NOT contiguous with L & RBUTTON

            XButton1 = 0x05,    // NOT contiguous with L & RBUTTON
            XButton2 = 0x06,    // NOT contiguous with L & RBUTTON
        }

        public enum Keyboard : ushort
        {
            //
            // Virtual Keys, Standard Set
            //
            Cancel = 0x03,

            // 0x07 : unassigned

            Back = 0x08,
            Tab = 0x09,

            // 0x0A - 0x0B : reserved

            Clear = 0x0C,
            Return = 0x0D,

            Shift = 0x10,
            Control = 0x11,
            Menu = 0x12,
            Pause = 0x13,
            Capital = 0x14,

            Kana = 0x15,
            Hanguel = 0x15,  // old name - should be here for compatibility
            Hangul = 0x15,
            Junja = 0x17,
            Final = 0x18,
            Hanja = 0x19,
            Kanji = 0x19,

            Escape = 0x1B,

            Convert = 0x1C,
            NonCovert = 0x1D,
            Accept = 0x1E,
            ModeChange = 0x1F,

            Space = 0x20,
            Prior = 0x21,
            Next = 0x22,
            End = 0x23,
            Home = 0x24,
            Left = 0x25,
            Up = 0x26,
            Right = 0x27,
            Down = 0x28,
            Select = 0x29,
            Print = 0x2A,
            Execute = 0x2B,
            Snapshot = 0x2C,
            Insert = 0x2D,
            Delete = 0x2E,
            Help = 0x2F,

            //
            // 0 - 9 are the same as ASCII '0' - '9' (0x30 - 0x39)
            // 0x40 : unassigned
            // A - Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
            //
            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4A,
            K = 0x4B,
            L = 0x4C,
            M = 0x4D,
            N = 0x4E,
            O = 0x4F,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5A,

            LeftWindowsKey = 0x5B,
            RightWindowsKey = 0x5C,
            //Apps = 0x5D,

            //
            // 0x5E : reserved
            //

            Sleep = 0x5F,

            NumPad0 = 0x60,
            NumPad1 = 0x61,
            NumPad2 = 0x62,
            NumPad3 = 0x63,
            NumPad4 = 0x64,
            NumPad5 = 0x65,
            NumPad6 = 0x66,
            NumPad7 = 0x67,
            NumPad8 = 0x68,
            NumPad9 = 0x69,
            Multiply = 0x6A,
            Add = 0x6B,
            Seperator = 0x6C,
            Subtract = 0x6D,
            Decimal = 0x6E,
            Divide = 0x6F,
            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7A,
            F12 = 0x7B,
            F13 = 0x7C,
            F14 = 0x7D,
            F15 = 0x7E,
            F16 = 0x7F,
            F17 = 0x80,
            F18 = 0x81,
            F19 = 0x82,
            F20 = 0x83,
            F21 = 0x84,
            F22 = 0x85,
            F23 = 0x86,
            F24 = 0x87,

            //
            // 0x88 - 0x8F : unassigned
            //

            NumLock = 0x90,
            ScrollLock = 0x91,

            //
            // L* & R* - left and right Alt, Ctrl and Shift virtual keys.
            // Used only as parameters to GetAsyncKeyState() and GetKeyState().
            // No other API or message will distinguish left and right keys in this way.
            //
            LeftShift = 0xA0,
            RightShift = 0xA1,
            LeftControl = 0xA2,
            RightControl = 0xA3,
            LeftMenu = 0xA4,
            RightMenu = 0xA5,

            BrowserBack = 0xA6,
            BrowserForwrad = 0xA7,
            BrowserRefresh = 0xA8,
            BrowserStop = 0xA9,
            BrowserSearch = 0xAA,
            BrowserFavorites = 0xAB,
            BrowserHome = 0xAC,

            VolumeMute = 0xAD,
            VolumeDown = 0xAE,
            VolumeUp = 0xAF,
            MediaNextTrack = 0xB0,
            MediaPreviousTrack = 0xB1,
            MediaStop = 0xB2,
            MediaPlayPause = 0xB3,
            LaunchMail = 0xB4,
            LaunchMediaSelect = 0xB5,
            LaunchApp1 = 0xB6,
            LaunchApp2 = 0xB7,

            //
            // 0xB8 - 0xB9 : reserved
            //
            /*
            OEM_1 = 0xBA,   // ';:' for US
            OEM_PLUS = 0xBB,   // '+' any country
            OEM_COMMA = 0xBC,   // ',' any country
            OEM_MINUS = 0xBD,   // '-' any country
            OEM_PERIOD = 0xBE,   // '.' any country
            OEM_2 = 0xBF,   // '/?' for US
            OEM_3 = 0xC0,   // '`~' for US
            */
            //
            // 0xC1 - 0xD7 : reserved
            //

            //
            // 0xD8 - 0xDA : unassigned
            //

            //OEM_4 = 0xDB,  //  '[{' for US
            //OEM_5 = 0xDC,  //  '\|' for US
            //OEM_6 = 0xDD,  //  ']}' for US
            //OEM_7 = 0xDE,  //  ''"' for US
            //OEM_8 = 0xDF

            //
            // 0xE0 : reserved
            //
        }
        #endregion

        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
            public static MOUSEINPUT Zero
            {
                get
                {
                    MOUSEINPUT mi = new MOUSEINPUT();
                    mi.dx = mi.dy = 0;
                    mi.mouseData = mi.dwFlags = mi.time = 0;
                    mi.dwExtraInfo = IntPtr.Zero;
                    return mi;
                }
            }
        }

        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
            public static KEYBDINPUT Zero
            {
                get
                {
                    KEYBDINPUT ki = new KEYBDINPUT();
                    ki.wVk = ki.wScan = 0;
                    ki.dwFlags = ki.time = 0;
                    ki.dwExtraInfo = IntPtr.Zero;
                    return ki;
                }
            }
        }

        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
            public static HARDWAREINPUT Zero
            {
                get
                {
                    HARDWAREINPUT hi = new HARDWAREINPUT();
                    hi.uMsg = 0;
                    hi.wParamH = hi.wParamL = 0;
                    return hi;
                }
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        struct INPUT
        {
            public int type;
            public MOUSEKEYBDHARDWAREINPUT mkhi;
        }


        // For use with the INPUT struct, see SendInput for an example
        private enum InputType : int
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 0x1,
            INPUT_HARDWARE = 2
        }

        public static bool Send(Keyboard key)
        {
            uint ret;
            INPUT i = new INPUT();
            i.type = (int)InputType.INPUT_KEYBOARD;
            i.mkhi.ki = new KEYBDINPUT();
            i.mkhi.ki.dwExtraInfo = IntPtr.Zero;
            i.mkhi.ki.dwFlags = 0;
            i.mkhi.ki.time = 0;
            i.mkhi.ki.wScan = 0;
            i.mkhi.ki.wVk = (ushort)key;
            INPUT[] ia = new INPUT[1] { i };
            ret = SendInput(1, ia, Marshal.SizeOf(i));
            return ret == 1;
        }
    }
}