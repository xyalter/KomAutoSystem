using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemCenter
{
    internal class NativeMethods
    {
        public const uint SHGFI_ICON = 256;

        public const uint SHGFI_LARGEICON = 0;

        public const uint SHGFI_SMALLICON = 1;

        public const uint SHGFI_USEFILEATTRIBUTES = 16;

        public const int LVM_SETICONSPACING = 4149;

        public NativeMethods()
        {
        }

        [DllImport("User32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("shell32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int ExtractIcon(IntPtr hInst, string lpFileName, int nIndex);

        [DllImport("shell32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr phiconLarge, IntPtr phiconSmall, int nIcons);

        public static Icon[] GetFileIcon(string p_Path)
        {
            int num = NativeMethods.ExtractIcon(IntPtr.Zero, p_Path, -1);
            Icon[] iconArray = new Icon[num];
            IntPtr intPtr = new IntPtr();
            for (int i = 0; i < num; i++)
            {
                intPtr = (IntPtr)NativeMethods.ExtractIcon(IntPtr.Zero, p_Path, i);
                iconArray[i] = Icon.FromHandle(intPtr);
            }
            return iconArray;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("shell32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref NativeMethods.SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public struct SHFILEINFO
        {
            public IntPtr hIcon;

            public IntPtr iIcon;

            public uint dwAttributes;

            public string szDisplayName;

            public string szTypeName;
        }
    }

}
