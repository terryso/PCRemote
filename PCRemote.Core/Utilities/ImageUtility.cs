using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace PCRemote.Core.Utilities
{
    public enum TernaryRasterOperations
    {
        SRCCOPY = 0x00CC0020, /* dest = source*/
        SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
        SRCAND = 0x008800C6, /* dest = source AND dest*/
        SRCINVERT = 0x00660046, /* dest = source XOR dest*/
        SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
        NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
        NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
        MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
        MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
        PATCOPY = 0x00F00021, /* dest = pattern*/
        PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
        PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
        DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
        BLACKNESS = 0x00000042, /* dest = BLACK*/
        WHITENESS = 0x00FF0062, /* dest = WHITE*/
    }

    public class ImageUtility
    {
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string driver, string device, IntPtr res1, IntPtr res2);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight,
                                         IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        public static void CaptureDesktop(string sPath)
        {
            var rect = new Rect
                           {
                               Width = Screen.PrimaryScreen.Bounds.Width,
                               Height = Screen.PrimaryScreen.Bounds.Height
                           };

            var dcTmp = CreateDC("DISPLAY", "DISPLAY", (IntPtr) null, (IntPtr) null);
            var gScreen = Graphics.FromHdc(dcTmp);
            var image = new Bitmap((int) (rect.Width), (int) (rect.Height), PixelFormat.Format24bppRgb);
            var gImage = Graphics.FromImage(image);
            var dcImage = gImage.GetHdc();
            var dcScreen = gScreen.GetHdc();
            BitBlt(dcImage, 0, 0, (int) (rect.Width), (int) (rect.Height), dcScreen, (int) (rect.Left), (int) (rect.Top), TernaryRasterOperations.SRCCOPY);
            gScreen.ReleaseHdc(dcScreen);
            gImage.ReleaseHdc(dcImage);

            image.Save(sPath);
        }
    }
}