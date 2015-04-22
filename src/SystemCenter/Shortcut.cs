using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    public class Shortcut
    {
        private const int MAX_DESCRIPTION_LENGTH = 512;

        private const int MAX_PATH = 512;

        private NativeClasses.IShellLinkW _link;

        public string Arguments
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder(512, 512);
                Marshal.ThrowExceptionForHR(this._link.GetArguments(stringBuilder, stringBuilder.MaxCapacity));
                return stringBuilder.ToString();
            }
            set
            {
                Marshal.ThrowExceptionForHR(this._link.SetArguments(value));
            }
        }

        private NativeClasses.IPersistFile AsPersist
        {
            get
            {
                return (NativeClasses.IPersistFile)this._link;
            }
        }

        public string Description
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder(512, 512);
                Marshal.ThrowExceptionForHR(this._link.GetDescription(stringBuilder, stringBuilder.MaxCapacity));
                return stringBuilder.ToString();
            }
            set
            {
                Marshal.ThrowExceptionForHR(this._link.SetDescription(value));
            }
        }

        public ushort HotKey
        {
            get
            {
                ushort num = 0;
                Marshal.ThrowExceptionForHR(this._link.GetHotkey(out num));
                return num;
            }
            set
            {
                Marshal.ThrowExceptionForHR(this._link.SetHotkey(value));
            }
        }

        public string Icon
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder(512, 512);
                int num = 0;
                Marshal.ThrowExceptionForHR(this._link.GetIconLocation(stringBuilder, stringBuilder.MaxCapacity, out num));
                return string.Concat(stringBuilder.ToString(), ",", num.ToString());
            }
            set
            {
                string[] strArrays = value.Split(new char[] { ',' });
                Marshal.ThrowExceptionForHR(this._link.SetIconLocation(strArrays[0], int.Parse(strArrays[1])));
            }
        }

        public string Path
        {
            get
            {
                NativeClasses._WIN32_FIND_DATAW _WIN32FINDDATAW = new NativeClasses._WIN32_FIND_DATAW();
                StringBuilder stringBuilder = new StringBuilder(512, 512);
                Marshal.ThrowExceptionForHR(this._link.GetPath(stringBuilder, stringBuilder.MaxCapacity, ref _WIN32FINDDATAW, 2));
                return stringBuilder.ToString();
            }
            set
            {
                Marshal.ThrowExceptionForHR(this._link.SetPath(value));
            }
        }

        public string RelativePath
        {
            set
            {
                Marshal.ThrowExceptionForHR(this._link.SetRelativePath(value, 0));
            }
        }

        public string WorkingDirectory
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder(512, 512);
                Marshal.ThrowExceptionForHR(this._link.GetWorkingDirectory(stringBuilder, stringBuilder.MaxCapacity));
                return stringBuilder.ToString();
            }
            set
            {
                Marshal.ThrowExceptionForHR(this._link.SetWorkingDirectory(value));
            }
        }

        public Shortcut()
        {
            this._link = NativeClasses.CreateShellLink();
        }

        public Shortcut(string path)
            : this()
        {
            Marshal.ThrowExceptionForHR(this._link.SetPath(path));
        }

        public void Load(string fileName)
        {
            Marshal.ThrowExceptionForHR(this.AsPersist.Load(fileName, 0));
        }

        public void Resolve(IntPtr hwnd, uint flags)
        {
            Marshal.ThrowExceptionForHR(this._link.Resolve(hwnd, flags));
        }

        public void Resolve(IWin32Window window)
        {
            this.Resolve(window.Handle, 0);
        }

        public void Resolve()
        {
            this.Resolve(IntPtr.Zero, 1);
        }

        public void Save(string fileName)
        {
            Marshal.ThrowExceptionForHR(this.AsPersist.Save(fileName, true));
        }
    }
}
