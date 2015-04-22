using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemCenter
{
    internal static class NativeClasses
    {
        internal const uint SLGP_SHORTPATH = 1;

        internal const uint SLGP_UNCPRIORITY = 2;

        internal const uint SLGP_RAWPATH = 4;

        internal static NativeClasses.IShellLinkW CreateShellLink()
        {
            return (NativeClasses.IShellLinkW)(new NativeClasses.CShellLink());
        }

        internal struct _FILETIME
        {
            public uint dwLowDateTime;

            public uint dwHighDateTime;
        }

        internal struct _WIN32_FIND_DATAW
        {
            public uint dwFileAttributes;

            public NativeClasses._FILETIME ftCreationTime;

            public NativeClasses._FILETIME ftLastAccessTime;

            public NativeClasses._FILETIME ftLastWriteTime;

            public uint nFileSizeHigh;

            public uint nFileSizeLow;

            public uint dwReserved0;

            public uint dwReserved1;

            public string cFileName;

            public string cAlternateFileName;
        }

        [ClassInterface(ClassInterfaceType.None)]
        [Guid("00021401-0000-0000-C000-000000000046")]
        private class CShellLink
        {
            public extern CShellLink();
        }

        [Guid("0000010B-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IPersistFile
        {
            int GetClassID(out Guid pClassID);

            int GetCurFile([Out] StringBuilder pszIconPath);

            int IsDirty();

            int Load(string pszFileName, uint dwMode);

            int Save(string pszFileName, bool fRemember);

            int SaveCompleted(string pszFileName);
        }

        [Guid("000214F9-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IShellLinkW
        {
            int GetArguments([Out] StringBuilder pszArgs, int cchMaxPath);

            int GetDescription([Out] StringBuilder pszFile, int cchMaxName);

            int GetHotkey(out ushort pwHotkey);

            int GetIconLocation([Out] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

            int GetIDList(out IntPtr ppidl);

            int GetPath([Out] StringBuilder pszFile, int cchMaxPath, ref NativeClasses._WIN32_FIND_DATAW pfd, uint fFlags);

            int GetShowCmd(out uint piShowCmd);

            int GetWorkingDirectory([Out] StringBuilder pszDir, int cchMaxPath);

            int Resolve(IntPtr hWnd, uint fFlags);

            int SetArguments(string pszArgs);

            int SetDescription(string pszName);

            int SetHotkey(ushort pwHotkey);

            int SetIconLocation(string pszIconPath, int iIcon);

            int SetIDList(IntPtr pidl);

            int SetPath(string pszFile);

            int SetRelativePath(string pszPathRel, uint dwReserved);

            int SetShowCmd(uint piShowCmd);

            int SetWorkingDirectory(string pszDir);
        }

        [Flags]
        internal enum SLR_MODE : uint
        {
            SLR_NO_UI = 1,
            SLR_UPDATE = 4,
            SLR_NOUPDATE = 8,
            SLR_NOSEARCH = 16,
            SLR_NOTRACK = 32,
            SLR_NOLINKINFO = 64,
            SLR_INVOKE_MSI = 128,
            SLR_NO_UI_WITH_MSG_PUMP = 257
        }

        [Flags]
        internal enum STGM_ACCESS : uint
        {
            STGM_DIRECT = 0,
            STGM_FAILIFTHERE = 0,
            STGM_READ = 0,
            STGM_WRITE = 1,
            STGM_READWRITE = 2,
            STGM_SHARE_EXCLUSIVE = 16,
            STGM_SHARE_DENY_WRITE = 32,
            STGM_SHARE_DENY_READ = 48,
            STGM_SHARE_DENY_NONE = 64,
            STGM_CREATE = 4096,
            STGM_TRANSACTED = 65536,
            STGM_CONVERT = 131072,
            STGM_PRIORITY = 262144,
            STGM_NOSCRATCH = 1048576,
            STGM_NOSNAPSHOT = 2097152,
            STGM_DIRECT_SWMR = 4194304,
            STGM_DELETEONRELEASE = 67108864,
            STGM_SIMPLE = 134217728
        }
    }
}
