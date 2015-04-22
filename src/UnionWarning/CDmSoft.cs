using System;
using System.Runtime.InteropServices;

namespace EVE_我们很勤劳
{
	internal class CDmSoft : IDisposable
	{
        private const string DMCNAME = "dmc.dll";

		private IntPtr _dm = IntPtr.Zero;

		private bool disposed;

		public IntPtr DM
		{
			get
			{
				return this._dm;
			}
			set
			{
				this._dm = value;
			}
		}

		public CDmSoft()
		{
            this._dm = CDmSoft.CreateDM("dm.dll");
		}

		public CDmSoft(string path)
		{
			this._dm = CDmSoft.CreateDM(path);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ActiveInputMethod(IntPtr dm, int hwnd, string id);

		public int ActiveInputMethod(int hwnd, string id)
		{
			return CDmSoft.ActiveInputMethod(this._dm, hwnd, id);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int AddDict(IntPtr dm, int index, string dict_info);

		public int AddDict(int index, string dict_info)
		{
			return CDmSoft.AddDict(this._dm, index, dict_info);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr AppendPicAddr(IntPtr dm, string pic_info, int addr, int size);

		public string AppendPicAddr(string pic_info, int addr, int size)
		{
			return Marshal.PtrToStringUni(CDmSoft.AppendPicAddr(this._dm, pic_info, addr, size));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int AsmAdd(IntPtr dm, string asm_ins);

		public int AsmAdd(string asm_ins)
		{
			return CDmSoft.AsmAdd(this._dm, asm_ins);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int AsmCall(IntPtr dm, int hwnd, int mode);

		public int AsmCall(int hwnd, int mode)
		{
			return CDmSoft.AsmCall(this._dm, hwnd, mode);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int AsmClear(IntPtr dm);

		public int AsmClear()
		{
			return CDmSoft.AsmClear(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr AsmCode(IntPtr dm, int base_addr);

		public string AsmCode(int base_addr)
		{
			return Marshal.PtrToStringUni(CDmSoft.AsmCode(this._dm, base_addr));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr Assemble(IntPtr dm, string asm_code, int base_addr, int is_upper);

		public string Assemble(string asm_code, int base_addr, int is_upper)
		{
			return Marshal.PtrToStringUni(CDmSoft.Assemble(this._dm, asm_code, base_addr, is_upper));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Beep(IntPtr dm, int fre, int delay);

		public int Beep(int fre, int delay)
		{
			return CDmSoft.Beep(this._dm, fre, delay);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr BGR2RGB(IntPtr dm, string bgr_color);

		public string BGR2RGB(string bgr_color)
		{
			return Marshal.PtrToStringUni(CDmSoft.BGR2RGB(this._dm, bgr_color));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int BindWindow(IntPtr dm, int hwnd, string display, string mouse, string keypad, int mode);

		public int BindWindow(int hwnd, string display, string mouse, string keypad, int mode)
		{
			return CDmSoft.BindWindow(this._dm, hwnd, display, mouse, keypad, mode);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int BindWindowEx(IntPtr dm, int hwnd, string display, string mouse, string keypad, string public_desc, int mode);

		public int BindWindowEx(int hwnd, string display, string mouse, string keypad, string public_desc, int mode)
		{
			return CDmSoft.BindWindowEx(this._dm, hwnd, display, mouse, keypad, public_desc, mode);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Capture(IntPtr dm, int x1, int y1, int x2, int y2, string file_);

		public int Capture(int x1, int y1, int x2, int y2, string file_)
		{
			return CDmSoft.Capture(this._dm, x1, y1, x2, y2, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CaptureGif(IntPtr dm, int x1, int y1, int x2, int y2, string file_, int delay, int time);

		public int CaptureGif(int x1, int y1, int x2, int y2, string file_, int delay, int time)
		{
			return CDmSoft.CaptureGif(this._dm, x1, y1, x2, y2, file_, delay, time);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CaptureJpg(IntPtr dm, int x1, int y1, int x2, int y2, string file_, int quality);

		public int CaptureJpg(int x1, int y1, int x2, int y2, string file_, int quality)
		{
			return CDmSoft.CaptureJpg(this._dm, x1, y1, x2, y2, file_, quality);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CapturePng(IntPtr dm, int x1, int y1, int x2, int y2, string file_);

		public int CapturePng(int x1, int y1, int x2, int y2, string file_)
		{
			return CDmSoft.CapturePng(this._dm, x1, y1, x2, y2, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CapturePre(IntPtr dm, string file_);

		public int CapturePre(string file_)
		{
			return CDmSoft.CapturePre(this._dm, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CheckFontSmooth(IntPtr dm);

		public int CheckFontSmooth()
		{
			return CDmSoft.CheckFontSmooth(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CheckInputMethod(IntPtr dm, int hwnd, string id);

		public int CheckInputMethod(int hwnd, string id)
		{
			return CDmSoft.CheckInputMethod(this._dm, hwnd, id);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CheckUAC(IntPtr dm);

		public int CheckUAC()
		{
			return CDmSoft.CheckUAC(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ClearDict(IntPtr dm, int index);

		public int ClearDict(int index)
		{
			return CDmSoft.ClearDict(this._dm, index);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ClientToScreen(IntPtr dm, int hwnd, ref object x, ref object y);

		public int ClientToScreen(int hwnd, ref object x, ref object y)
		{
			return CDmSoft.ClientToScreen(this._dm, hwnd, ref x, ref y);
		}

		public void Close()
		{
			this.Dispose();
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CmpColor(IntPtr dm, int x, int y, string color, double sim);

		public int CmpColor(int x, int y, string color, double sim)
		{
			return CDmSoft.CmpColor(this._dm, x, y, color, sim);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CopyFile(IntPtr dm, string src_file, string dst_file, int over);

		public int CopyFile(string src_file, string dst_file, int over)
		{
			return CDmSoft.CopyFile(this._dm, src_file, dst_file, over);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr CreateDM(string dmpath);

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CreateFolder(IntPtr dm, string folder_name);

		public int CreateFolder(string folder_name)
		{
			return CDmSoft.CreateFolder(this._dm, folder_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CreateFoobarCustom(IntPtr dm, int hwnd, int x, int y, string pic, string trans_color, double sim);

		public int CreateFoobarCustom(int hwnd, int x, int y, string pic, string trans_color, double sim)
		{
			return CDmSoft.CreateFoobarCustom(this._dm, hwnd, x, y, pic, trans_color, sim);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CreateFoobarEllipse(IntPtr dm, int hwnd, int x, int y, int w, int h);

		public int CreateFoobarEllipse(int hwnd, int x, int y, int w, int h)
		{
			return CDmSoft.CreateFoobarEllipse(this._dm, hwnd, x, y, w, h);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CreateFoobarRect(IntPtr dm, int hwnd, int x, int y, int w, int h);

		public int CreateFoobarRect(int hwnd, int x, int y, int w, int h)
		{
			return CDmSoft.CreateFoobarRect(this._dm, hwnd, x, y, w, h);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int CreateFoobarRoundRect(IntPtr dm, int hwnd, int x, int y, int w, int h, int rw, int rh);

		public int CreateFoobarRoundRect(int hwnd, int x, int y, int w, int h, int rw, int rh)
		{
			return CDmSoft.CreateFoobarRoundRect(this._dm, hwnd, x, y, w, h, rw, rh);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DecodeFile(IntPtr dm, string file_, string pwd);

		public int DecodeFile(string file_, string pwd)
		{
			return CDmSoft.DecodeFile(this._dm, file_, pwd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int delay(IntPtr dm, int mis);

		public int delay(int mis)
		{
			return CDmSoft.delay(this._dm, mis);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Delays(IntPtr dm, int min_s, int max_s);

		public int Delays(int min_s, int max_s)
		{
			return CDmSoft.Delays(this._dm, min_s, max_s);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DelEnv(IntPtr dm, int index, string name);

		public int DelEnv(int index, string name)
		{
			return CDmSoft.DelEnv(this._dm, index, name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DeleteFile(IntPtr dm, string file_);

		public int DeleteFile(string file_)
		{
			return CDmSoft.DeleteFile(this._dm, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DeleteFolder(IntPtr dm, string folder_name);

		public int DeleteFolder(string folder_name)
		{
			return CDmSoft.DeleteFolder(this._dm, folder_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DeleteIni(IntPtr dm, string section, string key, string file_);

		public int DeleteIni(string section, string key, string file_)
		{
			return CDmSoft.DeleteIni(this._dm, section, key, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DeleteIniPwd(IntPtr dm, string section, string key, string file_, string pwd);

		public int DeleteIniPwd(string section, string key, string file_, string pwd)
		{
			return CDmSoft.DeleteIniPwd(this._dm, section, key, file_, pwd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DisableFontSmooth(IntPtr dm);

		public int DisableFontSmooth()
		{
			return CDmSoft.DisableFontSmooth(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DisablePowerSave(IntPtr dm);

		public int DisablePowerSave()
		{
			return CDmSoft.DisablePowerSave(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DisableScreenSave(IntPtr dm);

		public int DisableScreenSave()
		{
			return CDmSoft.DisableScreenSave(this._dm);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}
			if (this._dm != IntPtr.Zero)
			{
				this.UnBindWindow();
				this._dm = IntPtr.Zero;
				CDmSoft.FreeDM();
			}
			this.disposed = true;
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DmGuard(IntPtr dm, int en, string type_);

		public int DmGuard(int en, string type_)
		{
			return CDmSoft.DmGuard(this._dm, en, type_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr DoubleToData(IntPtr dm, double double_value);

		public string DoubleToData(double double_value)
		{
			return Marshal.PtrToStringUni(CDmSoft.DoubleToData(this._dm, double_value));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DownCpu(IntPtr dm, int rate);

		public int DownCpu(int rate)
		{
			return CDmSoft.DownCpu(this._dm, rate);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int DownloadFile(IntPtr dm, string url, string save_file, int timeout);

		public int DownloadFile(string url, string save_file, int timeout)
		{
			return CDmSoft.DownloadFile(this._dm, url, save_file, timeout);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableBind(IntPtr dm, int en);

		public int EnableBind(int en)
		{
			return CDmSoft.EnableBind(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableDisplayDebug(IntPtr dm, int enable_debug);

		public int EnableDisplayDebug(int enable_debug)
		{
			return CDmSoft.EnableDisplayDebug(this._dm, enable_debug);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableFakeActive(IntPtr dm, int en);

		public int EnableFakeActive(int en)
		{
			return CDmSoft.EnableFakeActive(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableGetColorByCapture(IntPtr dm, int en);

		public int EnableGetColorByCapture(int en)
		{
			return CDmSoft.EnableGetColorByCapture(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableIme(IntPtr dm, int en);

		public int EnableIme(int en)
		{
			return CDmSoft.EnableIme(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableKeypadMsg(IntPtr dm, int en);

		public int EnableKeypadMsg(int en)
		{
			return CDmSoft.EnableKeypadMsg(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableKeypadPatch(IntPtr dm, int en);

		public int EnableKeypadPatch(int en)
		{
			return CDmSoft.EnableKeypadPatch(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableKeypadSync(IntPtr dm, int en, int time_out);

		public int EnableKeypadSync(int en, int time_out)
		{
			return CDmSoft.EnableKeypadSync(this._dm, en, time_out);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableMouseMsg(IntPtr dm, int en);

		public int EnableMouseMsg(int en)
		{
			return CDmSoft.EnableMouseMsg(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableMouseSync(IntPtr dm, int en, int time_out);

		public int EnableMouseSync(int en, int time_out)
		{
			return CDmSoft.EnableMouseSync(this._dm, en, time_out);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableRealKeypad(IntPtr dm, int en);

		public int EnableRealKeypad(int en)
		{
			return CDmSoft.EnableRealKeypad(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableRealMouse(IntPtr dm, int en, int mousedelay, int mousestep);

		public int EnableRealMouse(int en, int mousedelay, int mousestep)
		{
			return CDmSoft.EnableRealMouse(this._dm, en, mousedelay, mousestep);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnableSpeedDx(IntPtr dm, int en);

		public int EnableSpeedDx(int en)
		{
			return CDmSoft.EnableSpeedDx(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EncodeFile(IntPtr dm, string file_, string pwd);

		public int EncodeFile(string file_, string pwd)
		{
			return CDmSoft.EncodeFile(this._dm, file_, pwd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int EnterCri(IntPtr dm);

		public int EnterCri()
		{
			return CDmSoft.EnterCri(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumIniKey(IntPtr dm, string section, string file_);

		public string EnumIniKey(string section, string file_)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumIniKey(this._dm, section, file_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumIniKeyPwd(IntPtr dm, string section, string file_, string pwd);

		public string EnumIniKeyPwd(string section, string file_, string pwd)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumIniKeyPwd(this._dm, section, file_, pwd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumIniSection(IntPtr dm, string file_);

		public string EnumIniSection(string file_)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumIniSection(this._dm, file_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumIniSectionPwd(IntPtr dm, string file_, string pwd);

		public string EnumIniSectionPwd(string file_, string pwd)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumIniSectionPwd(this._dm, file_, pwd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumProcess(IntPtr dm, string name);

		public string EnumProcess(string name)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumProcess(this._dm, name));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumWindow(IntPtr dm, int parent, string title, string class_name, int filter);

		public string EnumWindow(int parent, string title, string class_name, int filter)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumWindow(this._dm, parent, title, class_name, filter));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumWindowByProcess(IntPtr dm, string process_name, string title, string class_name, int filter);

		public string EnumWindowByProcess(string process_name, string title, string class_name, int filter)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumWindowByProcess(this._dm, process_name, title, class_name, filter));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr EnumWindowSuper(IntPtr dm, string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort);

		public string EnumWindowSuper(string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort)
		{
			return Marshal.PtrToStringUni(CDmSoft.EnumWindowSuper(this._dm, spec1, flag1, type1, spec2, flag2, type2, sort));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ExcludePos(IntPtr dm, string all_pos, int type_, int x1, int y1, int x2, int y2);

		public string ExcludePos(string all_pos, int type_, int x1, int y1, int x2, int y2)
		{
			return Marshal.PtrToStringUni(CDmSoft.ExcludePos(this._dm, all_pos, type_, x1, y1, x2, y2));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ExitOs(IntPtr dm, int type_);

		public int ExitOs(int type_)
		{
			return CDmSoft.ExitOs(this._dm, type_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FaqCancel(IntPtr dm);

		public int FaqCancel()
		{
			return CDmSoft.FaqCancel(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FaqCapture(IntPtr dm, int x1, int y1, int x2, int y2, int quality, int delay, int time);

		public int FaqCapture(int x1, int y1, int x2, int y2, int quality, int delay, int time)
		{
			return CDmSoft.FaqCapture(this._dm, x1, y1, x2, y2, quality, delay, time);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FaqCaptureFromFile(IntPtr dm, int x1, int y1, int x2, int y2, string file_, int quality);

		public int FaqCaptureFromFile(int x1, int y1, int x2, int y2, string file_, int quality)
		{
			return CDmSoft.FaqCaptureFromFile(this._dm, x1, y1, x2, y2, file_, quality);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FaqFetch(IntPtr dm);

		public string FaqFetch()
		{
			return Marshal.PtrToStringUni(CDmSoft.FaqFetch(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FaqGetSize(IntPtr dm, int handle);

		public int FaqGetSize(int handle)
		{
			return CDmSoft.FaqGetSize(this._dm, handle);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FaqPost(IntPtr dm, string server, int handle, int request_type, int time_out);

		public int FaqPost(string server, int handle, int request_type, int time_out)
		{
			return CDmSoft.FaqPost(this._dm, server, handle, request_type, time_out);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FaqRelease(IntPtr dm, int handle);

		public int FaqRelease(int handle)
		{
			return CDmSoft.FaqRelease(this._dm, handle);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FaqSend(IntPtr dm, string server, int handle, int request_type, int time_out);

		public string FaqSend(string server, int handle, int request_type, int time_out)
		{
			return Marshal.PtrToStringUni(CDmSoft.FaqSend(this._dm, server, handle, request_type, time_out));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FetchWord(IntPtr dm, int x1, int y1, int x2, int y2, string color, string word);

		public string FetchWord(int x1, int y1, int x2, int y2, string color, string word)
		{
			return Marshal.PtrToStringUni(CDmSoft.FetchWord(this._dm, x1, y1, x2, y2, color, word));
		}

		~CDmSoft()
		{
			this.Dispose(false);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindColor(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int dir, out object x, out object y);

		public int FindColor(int x1, int y1, int x2, int y2, string color, double sim, int dir, out object x, out object y)
		{
			return CDmSoft.FindColor(this._dm, x1, y1, x2, y2, color, sim, dir, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindColorBlock(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height, out object x, out object y);

		public int FindColorBlock(int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height, out object x, out object y)
		{
			return CDmSoft.FindColorBlock(this._dm, x1, y1, x2, y2, color, sim, count, width, height, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindColorBlockEx(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height);

		public string FindColorBlockEx(int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindColorBlockEx(this._dm, x1, y1, x2, y2, color, sim, count, width, height));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindColorE(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int dir);

		public string FindColorE(int x1, int y1, int x2, int y2, string color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindColorE(this._dm, x1, y1, x2, y2, color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindColorEx(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int dir);

		public string FindColorEx(int x1, int y1, int x2, int y2, string color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindColorEx(this._dm, x1, y1, x2, y2, color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindData(IntPtr dm, int hwnd, string addr_range, string data);

		public string FindData(int hwnd, string addr_range, string data)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindData(this._dm, hwnd, addr_range, data));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindDataEx(IntPtr dm, int hwnd, string addr_range, string data, int step, int multi_thread, int mode);

		public string FindDataEx(int hwnd, string addr_range, string data, int step, int multi_thread, int mode)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindDataEx(this._dm, hwnd, addr_range, data, step, multi_thread, mode));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindDouble(IntPtr dm, int hwnd, string addr_range, double double_value_min, double double_value_max);

		public string FindDouble(int hwnd, string addr_range, double double_value_min, double double_value_max)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindDouble(this._dm, hwnd, addr_range, double_value_min, double_value_max));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindDoubleEx(IntPtr dm, int hwnd, string addr_range, double double_value_min, double double_value_max, int step, int multi_thread, int mode);

		public string FindDoubleEx(int hwnd, string addr_range, double double_value_min, double double_value_max, int step, int multi_thread, int mode)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindDoubleEx(this._dm, hwnd, addr_range, double_value_min, double_value_max, step, multi_thread, mode));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindFloat(IntPtr dm, int hwnd, string addr_range, float float_value_min, float float_value_max);

		public string FindFloat(int hwnd, string addr_range, float float_value_min, float float_value_max)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindFloat(this._dm, hwnd, addr_range, float_value_min, float_value_max));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindFloatEx(IntPtr dm, int hwnd, string addr_range, float float_value_min, float float_value_max, int step, int multi_thread, int mode);

		public string FindFloatEx(int hwnd, string addr_range, float float_value_min, float float_value_max, int step, int multi_thread, int mode)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindFloatEx(this._dm, hwnd, addr_range, float_value_min, float_value_max, step, multi_thread, mode));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindInputMethod(IntPtr dm, string id);

		public int FindInputMethod(string id)
		{
			return CDmSoft.FindInputMethod(this._dm, id);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindInt(IntPtr dm, int hwnd, string addr_range, int int_value_min, int int_value_max, int type_);

		public string FindInt(int hwnd, string addr_range, int int_value_min, int int_value_max, int type_)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindInt(this._dm, hwnd, addr_range, int_value_min, int_value_max, type_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindIntEx(IntPtr dm, int hwnd, string addr_range, int int_value_min, int int_value_max, int type_, int step, int multi_thread, int mode);

		public string FindIntEx(int hwnd, string addr_range, int int_value_min, int int_value_max, int type_, int step, int multi_thread, int mode)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindIntEx(this._dm, hwnd, addr_range, int_value_min, int_value_max, type_, step, multi_thread, mode));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindMulColor(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

		public int FindMulColor(int x1, int y1, int x2, int y2, string color, double sim)
		{
			return CDmSoft.FindMulColor(this._dm, x1, y1, x2, y2, color, sim);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindMultiColor(IntPtr dm, int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir, out object x, out object y);

		public int FindMultiColor(int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir, out object x, out object y)
		{
			return CDmSoft.FindMultiColor(this._dm, x1, y1, x2, y2, first_color, offset_color, sim, dir, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindMultiColorE(IntPtr dm, int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir);

		public string FindMultiColorE(int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindMultiColorE(this._dm, x1, y1, x2, y2, first_color, offset_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindMultiColorEx(IntPtr dm, int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir);

		public string FindMultiColorEx(int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindMultiColorEx(this._dm, x1, y1, x2, y2, first_color, offset_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindNearestPos(IntPtr dm, string all_pos, int type_, int x, int y);

		public string FindNearestPos(string all_pos, int type_, int x, int y)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindNearestPos(this._dm, all_pos, type_, x, y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindPic(IntPtr dm, int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir, out object x, out object y);

		public int FindPic(int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir, out object x, out object y)
		{
			return CDmSoft.FindPic(this._dm, x1, y1, x2, y2, pic_name, delta_color, sim, dir, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindPicE(IntPtr dm, int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir);

		public string FindPicE(int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindPicE(this._dm, x1, y1, x2, y2, pic_name, delta_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindPicEx(IntPtr dm, int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir);

		public string FindPicEx(int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindPicEx(this._dm, x1, y1, x2, y2, pic_name, delta_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindPicExS(IntPtr dm, int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir);

		public string FindPicExS(int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindPicExS(this._dm, x1, y1, x2, y2, pic_name, delta_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindPicMem(IntPtr dm, int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir, out object x, out object y);

		public int FindPicMem(int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir, out object x, out object y)
		{
			return CDmSoft.FindPicMem(this._dm, x1, y1, x2, y2, pic_info, delta_color, sim, dir, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindPicMemE(IntPtr dm, int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir);

		public string FindPicMemE(int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindPicMemE(this._dm, x1, y1, x2, y2, pic_info, delta_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindPicMemEx(IntPtr dm, int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir);

		public string FindPicMemEx(int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindPicMemEx(this._dm, x1, y1, x2, y2, pic_info, delta_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindPicS(IntPtr dm, int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir, out object x, out object y);

		public string FindPicS(int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir, out object x, out object y)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindPicS(this._dm, x1, y1, x2, y2, pic_name, delta_color, sim, dir, out x, out y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindShape(IntPtr dm, int x1, int y1, int x2, int y2, string offset_color, double sim, int dir, out object x, out object y);

		public int FindShape(int x1, int y1, int x2, int y2, string offset_color, double sim, int dir, out object x, out object y)
		{
			return CDmSoft.FindShape(this._dm, x1, y1, x2, y2, offset_color, sim, dir, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindShapeE(IntPtr dm, int x1, int y1, int x2, int y2, string offset_color, double sim, int dir);

		public string FindShapeE(int x1, int y1, int x2, int y2, string offset_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindShapeE(this._dm, x1, y1, x2, y2, offset_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindShapeEx(IntPtr dm, int x1, int y1, int x2, int y2, string offset_color, double sim, int dir);

		public string FindShapeEx(int x1, int y1, int x2, int y2, string offset_color, double sim, int dir)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindShapeEx(this._dm, x1, y1, x2, y2, offset_color, sim, dir));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindStr(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

		public int FindStr(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
		{
			return CDmSoft.FindStr(this._dm, x1, y1, x2, y2, str, color, sim, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrE(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

		public string FindStrE(int x1, int y1, int x2, int y2, string str, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrE(this._dm, x1, y1, x2, y2, str, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrEx(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

		public string FindStrEx(int x1, int y1, int x2, int y2, string str, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrEx(this._dm, x1, y1, x2, y2, str, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrExS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

		public string FindStrExS(int x1, int y1, int x2, int y2, string str, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrExS(this._dm, x1, y1, x2, y2, str, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindStrFast(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

		public int FindStrFast(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
		{
			return CDmSoft.FindStrFast(this._dm, x1, y1, x2, y2, str, color, sim, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrFastE(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

		public string FindStrFastE(int x1, int y1, int x2, int y2, string str, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrFastE(this._dm, x1, y1, x2, y2, str, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrFastEx(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

		public string FindStrFastEx(int x1, int y1, int x2, int y2, string str, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrFastEx(this._dm, x1, y1, x2, y2, str, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrFastExS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

		public string FindStrFastExS(int x1, int y1, int x2, int y2, string str, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrFastExS(this._dm, x1, y1, x2, y2, str, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrFastS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

		public string FindStrFastS(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrFastS(this._dm, x1, y1, x2, y2, str, color, sim, out x, out y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindString(IntPtr dm, int hwnd, string addr_range, string string_value, int type_);

		public string FindString(int hwnd, string addr_range, string string_value, int type_)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindString(this._dm, hwnd, addr_range, string_value, type_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStringEx(IntPtr dm, int hwnd, string addr_range, string string_value, int type_, int step, int multi_thread, int mode);

		public string FindStringEx(int hwnd, string addr_range, string string_value, int type_, int step, int multi_thread, int mode)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStringEx(this._dm, hwnd, addr_range, string_value, type_, step, multi_thread, mode));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

		public string FindStrS(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrS(this._dm, x1, y1, x2, y2, str, color, sim, out x, out y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindStrWithFont(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag, out object x, out object y);

		public int FindStrWithFont(int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag, out object x, out object y)
		{
			return CDmSoft.FindStrWithFont(this._dm, x1, y1, x2, y2, str, color, sim, font_name, font_size, flag, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrWithFontE(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag);

		public string FindStrWithFontE(int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrWithFontE(this._dm, x1, y1, x2, y2, str, color, sim, font_name, font_size, flag));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FindStrWithFontEx(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag);

		public string FindStrWithFontEx(int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag)
		{
			return Marshal.PtrToStringUni(CDmSoft.FindStrWithFontEx(this._dm, x1, y1, x2, y2, str, color, sim, font_name, font_size, flag));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindWindow(IntPtr dm, string class_name, string title_name);

		public int FindWindow(string class_name, string title_name)
		{
			return CDmSoft.FindWindow(this._dm, class_name, title_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindWindowByProcess(IntPtr dm, string process_name, string class_name, string title_name);

		public int FindWindowByProcess(string process_name, string class_name, string title_name)
		{
			return CDmSoft.FindWindowByProcess(this._dm, process_name, class_name, title_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindWindowByProcessId(IntPtr dm, int process_id, string class_name, string title_name);

		public int FindWindowByProcessId(int process_id, string class_name, string title_name)
		{
			return CDmSoft.FindWindowByProcessId(this._dm, process_id, class_name, title_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindWindowEx(IntPtr dm, int parent, string class_name, string title_name);

		public int FindWindowEx(int parent, string class_name, string title_name)
		{
			return CDmSoft.FindWindowEx(this._dm, parent, class_name, title_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FindWindowSuper(IntPtr dm, string spec1, int flag1, int type1, string spec2, int flag2, int type2);

		public int FindWindowSuper(string spec1, int flag1, int type1, string spec2, int flag2, int type2)
		{
			return CDmSoft.FindWindowSuper(this._dm, spec1, flag1, type1, spec2, flag2, type2);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr FloatToData(IntPtr dm, float float_value);

		public string FloatToData(float float_value)
		{
			return Marshal.PtrToStringUni(CDmSoft.FloatToData(this._dm, float_value));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarClearText(IntPtr dm, int hwnd);

		public int FoobarClearText(int hwnd)
		{
			return CDmSoft.FoobarClearText(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarClose(IntPtr dm, int hwnd);

		public int FoobarClose(int hwnd)
		{
			return CDmSoft.FoobarClose(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarDrawLine(IntPtr dm, int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width);

		public int FoobarDrawLine(int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width)
		{
			return CDmSoft.FoobarDrawLine(this._dm, hwnd, x1, y1, x2, y2, color, style, width);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarDrawPic(IntPtr dm, int hwnd, int x, int y, string pic, string trans_color);

		public int FoobarDrawPic(int hwnd, int x, int y, string pic, string trans_color)
		{
			return CDmSoft.FoobarDrawPic(this._dm, hwnd, x, y, pic, trans_color);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarDrawText(IntPtr dm, int hwnd, int x, int y, int w, int h, string text, string color, int align);

		public int FoobarDrawText(int hwnd, int x, int y, int w, int h, string text, string color, int align)
		{
			return CDmSoft.FoobarDrawText(this._dm, hwnd, x, y, w, h, text, color, align);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarFillRect(IntPtr dm, int hwnd, int x1, int y1, int x2, int y2, string color);

		public int FoobarFillRect(int hwnd, int x1, int y1, int x2, int y2, string color)
		{
			return CDmSoft.FoobarFillRect(this._dm, hwnd, x1, y1, x2, y2, color);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarLock(IntPtr dm, int hwnd);

		public int FoobarLock(int hwnd)
		{
			return CDmSoft.FoobarLock(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarPrintText(IntPtr dm, int hwnd, string text, string color);

		public int FoobarPrintText(int hwnd, string text, string color)
		{
			return CDmSoft.FoobarPrintText(this._dm, hwnd, text, color);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarSetFont(IntPtr dm, int hwnd, string font_name, int size, int flag);

		public int FoobarSetFont(int hwnd, string font_name, int size, int flag)
		{
			return CDmSoft.FoobarSetFont(this._dm, hwnd, font_name, size, flag);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarSetSave(IntPtr dm, int hwnd, string file_, int en, string header);

		public int FoobarSetSave(int hwnd, string file_, int en, string header)
		{
			return CDmSoft.FoobarSetSave(this._dm, hwnd, file_, en, header);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarStartGif(IntPtr dm, int hwnd, int x, int y, string pic_name, int repeat_limit, int delay);

		public int FoobarStartGif(int hwnd, int x, int y, string pic_name, int repeat_limit, int delay)
		{
			return CDmSoft.FoobarStartGif(this._dm, hwnd, x, y, pic_name, repeat_limit, delay);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarStopGif(IntPtr dm, int hwnd, int x, int y, string pic_name);

		public int FoobarStopGif(int hwnd, int x, int y, string pic_name)
		{
			return CDmSoft.FoobarStopGif(this._dm, hwnd, x, y, pic_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarTextLineGap(IntPtr dm, int hwnd, int gap);

		public int FoobarTextLineGap(int hwnd, int gap)
		{
			return CDmSoft.FoobarTextLineGap(this._dm, hwnd, gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarTextPrintDir(IntPtr dm, int hwnd, int dir);

		public int FoobarTextPrintDir(int hwnd, int dir)
		{
			return CDmSoft.FoobarTextPrintDir(this._dm, hwnd, dir);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarTextRect(IntPtr dm, int hwnd, int x, int y, int w, int h);

		public int FoobarTextRect(int hwnd, int x, int y, int w, int h)
		{
			return CDmSoft.FoobarTextRect(this._dm, hwnd, x, y, w, h);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarUnlock(IntPtr dm, int hwnd);

		public int FoobarUnlock(int hwnd)
		{
			return CDmSoft.FoobarUnlock(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FoobarUpdate(IntPtr dm, int hwnd);

		public int FoobarUpdate(int hwnd)
		{
			return CDmSoft.FoobarUpdate(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ForceUnBindWindow(IntPtr dm, int hwnd);

		public int ForceUnBindWindow(int hwnd)
		{
			return CDmSoft.ForceUnBindWindow(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FreeDM();

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FreePic(IntPtr dm, string pic_name);

		public int FreePic(string pic_name)
		{
			return CDmSoft.FreePic(this._dm, pic_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FreeProcessMemory(IntPtr dm, int hwnd);

		public int FreeProcessMemory(int hwnd)
		{
			return CDmSoft.FreeProcessMemory(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int FreeScreenData(IntPtr dm, int handle);

		public int FreeScreenData(int handle)
		{
			return CDmSoft.FreeScreenData(this._dm, handle);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetAveHSV(IntPtr dm, int x1, int y1, int x2, int y2);

		public string GetAveHSV(int x1, int y1, int x2, int y2)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetAveHSV(this._dm, x1, y1, x2, y2));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetAveRGB(IntPtr dm, int x1, int y1, int x2, int y2);

		public string GetAveRGB(int x1, int y1, int x2, int y2)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetAveRGB(this._dm, x1, y1, x2, y2));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetBasePath(IntPtr dm);

		public string GetBasePath()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetBasePath(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetBindWindow(IntPtr dm);

		public int GetBindWindow()
		{
			return CDmSoft.GetBindWindow(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetClientRect(IntPtr dm, int hwnd, out object x1, out object y1, out object x2, out object y2);

		public int GetClientRect(int hwnd, out object x1, out object y1, out object x2, out object y2)
		{
			return CDmSoft.GetClientRect(this._dm, hwnd, out x1, out y1, out x2, out y2);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetClientSize(IntPtr dm, int hwnd, out object width, out object height);

		public int GetClientSize(int hwnd, out object width, out object height)
		{
			return CDmSoft.GetClientSize(this._dm, hwnd, out width, out height);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetClipboard(IntPtr dm);

		public string GetClipboard()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetClipboard(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetColor(IntPtr dm, int x, int y);

		public string GetColor(int x, int y)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetColor(this._dm, x, y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetColorBGR(IntPtr dm, int x, int y);

		public string GetColorBGR(int x, int y)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetColorBGR(this._dm, x, y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetColorHSV(IntPtr dm, int x, int y);

		public string GetColorHSV(int x, int y)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetColorHSV(this._dm, x, y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetColorNum(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

		public int GetColorNum(int x1, int y1, int x2, int y2, string color, double sim)
		{
			return CDmSoft.GetColorNum(this._dm, x1, y1, x2, y2, color, sim);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetCommandLine(IntPtr dm, int hwnd);

		public string GetCommandLine(int hwnd)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetCommandLine(this._dm, hwnd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetCursorPos(IntPtr dm, out object x, out object y);

		public int GetCursorPos(out object x, out object y)
		{
			return CDmSoft.GetCursorPos(this._dm, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetCursorShape(IntPtr dm);

		public string GetCursorShape()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetCursorShape(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetCursorShapeEx(IntPtr dm, int type_);

		public string GetCursorShapeEx(int type_)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetCursorShapeEx(this._dm, type_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetCursorSpot(IntPtr dm);

		public string GetCursorSpot()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetCursorSpot(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetDict(IntPtr dm, int index, int font_index);

		public string GetDict(int index, int font_index)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetDict(this._dm, index, font_index));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetDictCount(IntPtr dm, int index);

		public int GetDictCount(int index)
		{
			return CDmSoft.GetDictCount(this._dm, index);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetDictInfo(IntPtr dm, string str, string font_name, int font_size, int flag);

		public string GetDictInfo(string str, string font_name, int font_size, int flag)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetDictInfo(this._dm, str, font_name, font_size, flag));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetDir(IntPtr dm, int type_);

		public string GetDir(int type_)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetDir(this._dm, type_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetDiskSerial(IntPtr dm);

		public string GetDiskSerial()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetDiskSerial(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetDmCount(IntPtr dm);

		public int GetDmCount()
		{
			return CDmSoft.GetDmCount(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetEnv(IntPtr dm, int index, string name);

		public string GetEnv(int index, string name)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetEnv(this._dm, index, name));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetFileLength(IntPtr dm, string file_);

		public int GetFileLength(string file_)
		{
			return CDmSoft.GetFileLength(this._dm, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetForegroundFocus(IntPtr dm);

		public int GetForegroundFocus()
		{
			return CDmSoft.GetForegroundFocus(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetForegroundWindow(IntPtr dm);

		public int GetForegroundWindow()
		{
			return CDmSoft.GetForegroundWindow(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetID(IntPtr dm);

		public int GetID()
		{
			return CDmSoft.GetID(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetKeyState(IntPtr dm, int vk);

		public int GetKeyState(int vk)
		{
			return CDmSoft.GetKeyState(this._dm, vk);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetLastError(IntPtr dm);

		public int GetLastError()
		{
			return CDmSoft.GetLastError(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetMac(IntPtr dm);

		public string GetMac()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetMac(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetMachineCode(IntPtr dm);

		public string GetMachineCode()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetMachineCode(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetMachineCodeNoMac(IntPtr dm);

		public string GetMachineCodeNoMac()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetMachineCodeNoMac(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetModuleBaseAddr(IntPtr dm, int hwnd, string module_name);

		public int GetModuleBaseAddr(int hwnd, string module_name)
		{
			return CDmSoft.GetModuleBaseAddr(this._dm, hwnd, module_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetMousePointWindow(IntPtr dm);

		public int GetMousePointWindow()
		{
			return CDmSoft.GetMousePointWindow(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetNetTime(IntPtr dm);

		public string GetNetTime()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetNetTime(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetNetTimeByIp(IntPtr dm, string ip);

		public string GetNetTimeByIp(string ip)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetNetTimeByIp(this._dm, ip));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetNetTimeSafe(IntPtr dm);

		public string GetNetTimeSafe()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetNetTimeSafe(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetNowDict(IntPtr dm);

		public int GetNowDict()
		{
			return CDmSoft.GetNowDict(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetOsType(IntPtr dm);

		public int GetOsType()
		{
			return CDmSoft.GetOsType(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetPath(IntPtr dm);

		public string GetPath()
		{
			return Marshal.PtrToStringUni(CDmSoft.GetPath(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetPicSize(IntPtr dm, string pic_name);

		public string GetPicSize(string pic_name)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetPicSize(this._dm, pic_name));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetPointWindow(IntPtr dm, int x, int y);

		public int GetPointWindow(int x, int y)
		{
			return CDmSoft.GetPointWindow(this._dm, x, y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetProcessInfo(IntPtr dm, int pid);

		public string GetProcessInfo(int pid)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetProcessInfo(this._dm, pid));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetResultCount(IntPtr dm, string str);

		public int GetResultCount(string str)
		{
			return CDmSoft.GetResultCount(this._dm, str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetResultPos(IntPtr dm, string str, int index, out object x, out object y);

		public int GetResultPos(string str, int index, out object x, out object y)
		{
			return CDmSoft.GetResultPos(this._dm, str, index, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetScreenData(IntPtr dm, int x1, int y1, int x2, int y2);

		public int GetScreenData(int x1, int y1, int x2, int y2)
		{
			return CDmSoft.GetScreenData(this._dm, x1, y1, x2, y2);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetScreenDataBmp(IntPtr dm, int x1, int y1, int x2, int y2, out object data, out object size);

		public int GetScreenDataBmp(int x1, int y1, int x2, int y2, out object data, out object size)
		{
			return CDmSoft.GetScreenDataBmp(this._dm, x1, y1, x2, y2, out data, out size);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetScreenDepth(IntPtr dm);

		public int GetScreenDepth()
		{
			return CDmSoft.GetScreenDepth(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetScreenHeight(IntPtr dm);

		public int GetScreenHeight()
		{
			return CDmSoft.GetScreenHeight(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetScreenWidth(IntPtr dm);

		public int GetScreenWidth()
		{
			return CDmSoft.GetScreenWidth(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetSpecialWindow(IntPtr dm, int flag);

		public int GetSpecialWindow(int flag)
		{
			return CDmSoft.GetSpecialWindow(this._dm, flag);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetTime(IntPtr dm);

		public int GetTime()
		{
			return CDmSoft.GetTime(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetWindow(IntPtr dm, int hwnd, int flag);

		public int GetWindow(int hwnd, int flag)
		{
			return CDmSoft.GetWindow(this._dm, hwnd, flag);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetWindowClass(IntPtr dm, int hwnd);

		public string GetWindowClass(int hwnd)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetWindowClass(this._dm, hwnd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetWindowProcessId(IntPtr dm, int hwnd);

		public int GetWindowProcessId(int hwnd)
		{
			return CDmSoft.GetWindowProcessId(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetWindowProcessPath(IntPtr dm, int hwnd);

		public string GetWindowProcessPath(int hwnd)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetWindowProcessPath(this._dm, hwnd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetWindowRect(IntPtr dm, int hwnd, out object x1, out object y1, out object x2, out object y2);

		public int GetWindowRect(int hwnd, out object x1, out object y1, out object x2, out object y2)
		{
			return CDmSoft.GetWindowRect(this._dm, hwnd, out x1, out y1, out x2, out y2);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetWindowState(IntPtr dm, int hwnd, int flag);

		public int GetWindowState(int hwnd, int flag)
		{
			return CDmSoft.GetWindowState(this._dm, hwnd, flag);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetWindowTitle(IntPtr dm, int hwnd);

		public string GetWindowTitle(int hwnd)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetWindowTitle(this._dm, hwnd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetWordResultCount(IntPtr dm, string str);

		public int GetWordResultCount(string str)
		{
			return CDmSoft.GetWordResultCount(this._dm, str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int GetWordResultPos(IntPtr dm, string str, int index, out object x, out object y);

		public int GetWordResultPos(string str, int index, out object x, out object y)
		{
			return CDmSoft.GetWordResultPos(this._dm, str, index, out x, out y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetWordResultStr(IntPtr dm, string str, int index);

		public string GetWordResultStr(string str, int index)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetWordResultStr(this._dm, str, index));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetWords(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

		public string GetWords(int x1, int y1, int x2, int y2, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetWords(this._dm, x1, y1, x2, y2, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr GetWordsNoDict(IntPtr dm, int x1, int y1, int x2, int y2, string color);

		public string GetWordsNoDict(int x1, int y1, int x2, int y2, string color)
		{
			return Marshal.PtrToStringUni(CDmSoft.GetWordsNoDict(this._dm, x1, y1, x2, y2, color));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ImageToBmp(IntPtr dm, string pic_name, string bmp_name);

		public int ImageToBmp(string pic_name, string bmp_name)
		{
			return CDmSoft.ImageToBmp(this._dm, pic_name, bmp_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr IntToData(IntPtr dm, int int_value, int type_);

		public string IntToData(int int_value, int type_)
		{
			return Marshal.PtrToStringUni(CDmSoft.IntToData(this._dm, int_value, type_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Is64Bit(IntPtr dm);

		public int Is64Bit()
		{
			return CDmSoft.Is64Bit(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int IsBind(IntPtr dm, int hwnd);

		public int IsBind(int hwnd)
		{
			return CDmSoft.IsBind(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int IsDisplayDead(IntPtr dm, int x1, int y1, int x2, int y2, int t);

		public int IsDisplayDead(int x1, int y1, int x2, int y2, int t)
		{
			return CDmSoft.IsDisplayDead(this._dm, x1, y1, x2, y2, t);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int IsFileExist(IntPtr dm, string file_);

		public int IsFileExist(string file_)
		{
			return CDmSoft.IsFileExist(this._dm, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyDown(IntPtr dm, int vk);

		public int KeyDown(int vk)
		{
			return CDmSoft.KeyDown(this._dm, vk);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyDownChar(IntPtr dm, string key_str);

		public int KeyDownChar(string key_str)
		{
			return CDmSoft.KeyDownChar(this._dm, key_str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyPress(IntPtr dm, int vk);

		public int KeyPress(int vk)
		{
			return CDmSoft.KeyPress(this._dm, vk);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyPressChar(IntPtr dm, string key_str);

		public int KeyPressChar(string key_str)
		{
			return CDmSoft.KeyPressChar(this._dm, key_str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyPressStr(IntPtr dm, string key_str, int delay);

		public int KeyPressStr(string key_str, int delay)
		{
			return CDmSoft.KeyPressStr(this._dm, key_str, delay);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyUp(IntPtr dm, int vk);

		public int KeyUp(int vk)
		{
			return CDmSoft.KeyUp(this._dm, vk);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int KeyUpChar(IntPtr dm, string key_str);

		public int KeyUpChar(string key_str)
		{
			return CDmSoft.KeyUpChar(this._dm, key_str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LeaveCri(IntPtr dm);

		public int LeaveCri()
		{
			return CDmSoft.LeaveCri(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LeftClick(IntPtr dm);

		public int LeftClick()
		{
			return CDmSoft.LeftClick(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LeftDoubleClick(IntPtr dm);

		public int LeftDoubleClick()
		{
			return CDmSoft.LeftDoubleClick(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LeftDown(IntPtr dm);

		public int LeftDown()
		{
			return CDmSoft.LeftDown(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LeftUp(IntPtr dm);

		public int LeftUp()
		{
			return CDmSoft.LeftUp(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LoadPic(IntPtr dm, string pic_name);

		public int LoadPic(string pic_name)
		{
			return CDmSoft.LoadPic(this._dm, pic_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LockDisplay(IntPtr dm, int lock1);

		public int LockDisplay(int lock1)
		{
			return CDmSoft.LockDisplay(this._dm, lock1);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LockInput(IntPtr dm, int lock1);

		public int LockInput(int lock1)
		{
			return CDmSoft.LockInput(this._dm, lock1);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int LockMouseRect(IntPtr dm, int x1, int y1, int x2, int y2);

		public int LockMouseRect(int x1, int y1, int x2, int y2)
		{
			return CDmSoft.LockMouseRect(this._dm, x1, y1, x2, y2);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Log(IntPtr dm, string info);

		public int Log(string info)
		{
			return CDmSoft.Log(this._dm, info);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr MatchPicName(IntPtr dm, string pic_name);

		public string MatchPicName(string pic_name)
		{
			return Marshal.PtrToStringUni(CDmSoft.MatchPicName(this._dm, pic_name));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr Md5(IntPtr dm, string str);

		public string Md5(string str)
		{
			return Marshal.PtrToStringUni(CDmSoft.Md5(this._dm, str));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int MiddleClick(IntPtr dm);

		public int MiddleClick()
		{
			return CDmSoft.MiddleClick(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int MoveDD(IntPtr dm, int dx, int dy);

		public int MoveDD(int dx, int dy)
		{
			return CDmSoft.MoveDD(this._dm, dx, dy);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int MoveFile(IntPtr dm, string src_file, string dst_file);

		public int MoveFile(string src_file, string dst_file)
		{
			return CDmSoft.MoveFile(this._dm, src_file, dst_file);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int MoveR(IntPtr dm, int rx, int ry);

		public int MoveR(int rx, int ry)
		{
			return CDmSoft.MoveR(this._dm, rx, ry);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int MoveTo(IntPtr dm, int x, int y);

		public int MoveTo(int x, int y)
		{
			return CDmSoft.MoveTo(this._dm, x, y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr MoveToEx(IntPtr dm, int x, int y, int w, int h);

		public string MoveToEx(int x, int y, int w, int h)
		{
			return Marshal.PtrToStringUni(CDmSoft.MoveToEx(this._dm, x, y, w, h));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int MoveWindow(IntPtr dm, int hwnd, int x, int y);

		public int MoveWindow(int hwnd, int x, int y)
		{
			return CDmSoft.MoveWindow(this._dm, hwnd, x, y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr Ocr(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

		public string Ocr(int x1, int y1, int x2, int y2, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.Ocr(this._dm, x1, y1, x2, y2, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr OcrEx(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

		public string OcrEx(int x1, int y1, int x2, int y2, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.OcrEx(this._dm, x1, y1, x2, y2, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr OcrInFile(IntPtr dm, int x1, int y1, int x2, int y2, string pic_name, string color, double sim);

		public string OcrInFile(int x1, int y1, int x2, int y2, string pic_name, string color, double sim)
		{
			return Marshal.PtrToStringUni(CDmSoft.OcrInFile(this._dm, x1, y1, x2, y2, pic_name, color, sim));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int OpenProcess(IntPtr dm, int pid);

		public int OpenProcess(int pid)
		{
			return CDmSoft.OpenProcess(this._dm, pid);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Play(IntPtr dm, string file_);

		public int Play(string file_)
		{
			return CDmSoft.Play(this._dm, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadData(IntPtr dm, int hwnd, string addr, int len);

		public string ReadData(int hwnd, string addr, int len)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadData(this._dm, hwnd, addr, len));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadDataAddr(IntPtr dm, int hwnd, int addr, int len);

		public string ReadDataAddr(int hwnd, int addr, int len)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadDataAddr(this._dm, hwnd, addr, len));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ReadDouble(IntPtr dm, int hwnd, string addr);

		public int ReadDouble(int hwnd, string addr)
		{
			return CDmSoft.ReadDouble(this._dm, hwnd, addr);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ReadDoubleAddr(IntPtr dm, int hwnd, int addr);

		public int ReadDoubleAddr(int hwnd, int addr)
		{
			return CDmSoft.ReadDoubleAddr(this._dm, hwnd, addr);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadFile(IntPtr dm, string file_);

		public string ReadFile(string file_)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadFile(this._dm, file_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadFileData(IntPtr dm, string file_, int start_pos, int end_pos);

		public string ReadFileData(string file_, int start_pos, int end_pos)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadFileData(this._dm, file_, start_pos, end_pos));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ReadFloat(IntPtr dm, int hwnd, string addr);

		public int ReadFloat(int hwnd, string addr)
		{
			return CDmSoft.ReadFloat(this._dm, hwnd, addr);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ReadFloatAddr(IntPtr dm, int hwnd, int addr);

		public int ReadFloatAddr(int hwnd, int addr)
		{
			return CDmSoft.ReadFloatAddr(this._dm, hwnd, addr);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadIni(IntPtr dm, string section, string key, string file_);

		public string ReadIni(string section, string key, string file_)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadIni(this._dm, section, key, file_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadIniPwd(IntPtr dm, string section, string key, string file_, string pwd);

		public string ReadIniPwd(string section, string key, string file_, string pwd)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadIniPwd(this._dm, section, key, file_, pwd));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ReadInt(IntPtr dm, int hwnd, string addr, int type_);

		public int ReadInt(int hwnd, string addr, int type_)
		{
			return CDmSoft.ReadInt(this._dm, hwnd, addr, type_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ReadIntAddr(IntPtr dm, int hwnd, int addr, int type_);

		public int ReadIntAddr(int hwnd, int addr, int type_)
		{
			return CDmSoft.ReadIntAddr(this._dm, hwnd, addr, type_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadString(IntPtr dm, int hwnd, string addr, int type_, int len);

		public string ReadString(int hwnd, string addr, int type_, int len)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadString(this._dm, hwnd, addr, type_, len));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr ReadStringAddr(IntPtr dm, int hwnd, int addr, int type_, int len);

		public string ReadStringAddr(int hwnd, int addr, int type_, int len)
		{
			return Marshal.PtrToStringUni(CDmSoft.ReadStringAddr(this._dm, hwnd, addr, type_, len));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Reg(IntPtr dm, string code, string Ver);

		public int Reg(string code, string Ver)
		{
			return CDmSoft.Reg(this._dm, code, Ver);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RegEx(IntPtr dm, string code, string Ver, string ip);

		public int RegEx(string code, string Ver, string ip)
		{
			return CDmSoft.RegEx(this._dm, code, Ver, ip);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RegExNoMac(IntPtr dm, string code, string Ver, string ip);

		public int RegExNoMac(string code, string Ver, string ip)
		{
			return CDmSoft.RegExNoMac(this._dm, code, Ver, ip);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RegNoMac(IntPtr dm, string code, string Ver);

		public int RegNoMac(string code, string Ver)
		{
			return CDmSoft.RegNoMac(this._dm, code, Ver);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr RGB2BGR(IntPtr dm, string rgb_color);

		public string RGB2BGR(string rgb_color)
		{
			return Marshal.PtrToStringUni(CDmSoft.RGB2BGR(this._dm, rgb_color));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RightClick(IntPtr dm);

		public int RightClick()
		{
			return CDmSoft.RightClick(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RightDown(IntPtr dm);

		public int RightDown()
		{
			return CDmSoft.RightDown(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RightUp(IntPtr dm);

		public int RightUp()
		{
			return CDmSoft.RightUp(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int RunApp(IntPtr dm, string path, int mode);

		public int RunApp(string path, int mode)
		{
			return CDmSoft.RunApp(this._dm, path, mode);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SaveDict(IntPtr dm, int index, string file_);

		public int SaveDict(int index, string file_)
		{
			return CDmSoft.SaveDict(this._dm, index, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ScreenToClient(IntPtr dm, int hwnd, ref object x, ref object y);

		public int ScreenToClient(int hwnd, ref object x, ref object y)
		{
			return CDmSoft.ScreenToClient(this._dm, hwnd, ref x, ref y);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr SelectDirectory(IntPtr dm);

		public string SelectDirectory()
		{
			return Marshal.PtrToStringUni(CDmSoft.SelectDirectory(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr SelectFile(IntPtr dm);

		public string SelectFile()
		{
			return Marshal.PtrToStringUni(CDmSoft.SelectFile(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SendCommand(IntPtr dm, string cmd);

		public int SendCommand(string cmd)
		{
			return CDmSoft.SendCommand(this._dm, cmd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SendPaste(IntPtr dm, int hwnd);

		public int SendPaste(int hwnd)
		{
			return CDmSoft.SendPaste(this._dm, hwnd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SendString(IntPtr dm, int hwnd, string str);

		public int SendString(int hwnd, string str)
		{
			return CDmSoft.SendString(this._dm, hwnd, str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SendString2(IntPtr dm, int hwnd, string str);

		public int SendString2(int hwnd, string str)
		{
			return CDmSoft.SendString2(this._dm, hwnd, str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SendStringIme(IntPtr dm, string str);

		public int SendStringIme(string str)
		{
			return CDmSoft.SendStringIme(this._dm, str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetClientSize(IntPtr dm, int hwnd, int width, int height);

		public int SetClientSize(int hwnd, int width, int height)
		{
			return CDmSoft.SetClientSize(this._dm, hwnd, width, height);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetClipboard(IntPtr dm, string data);

		public int SetClipboard(string data)
		{
			return CDmSoft.SetClipboard(this._dm, data);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetColGapNoDict(IntPtr dm, int col_gap);

		public int SetColGapNoDict(int col_gap)
		{
			return CDmSoft.SetColGapNoDict(this._dm, col_gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetDict(IntPtr dm, int index, string dict_name);

		public int SetDict(int index, string dict_name)
		{
			return CDmSoft.SetDict(this._dm, index, dict_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetDictMem(IntPtr dm, int index, int addr, int size);

		public int SetDictMem(int index, int addr, int size)
		{
			return CDmSoft.SetDictMem(this._dm, index, addr, size);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetDictPwd(IntPtr dm, string pwd);

		public int SetDictPwd(string pwd)
		{
			return CDmSoft.SetDictPwd(this._dm, pwd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetDisplayAcceler(IntPtr dm, int level);

		public int SetDisplayAcceler(int level)
		{
			return CDmSoft.SetDisplayAcceler(this._dm, level);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetDisplayDelay(IntPtr dm, int t);

		public int SetDisplayDelay(int t)
		{
			return CDmSoft.SetDisplayDelay(this._dm, t);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetDisplayInput(IntPtr dm, string mode);

		public int SetDisplayInput(string mode)
		{
			return CDmSoft.SetDisplayInput(this._dm, mode);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetEnumWindowDelay(IntPtr dm, int delay);

		public int SetEnumWindowDelay(int delay)
		{
			return CDmSoft.SetEnumWindowDelay(this._dm, delay);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetEnv(IntPtr dm, int index, string name, string value);

		public int SetEnv(int index, string name, string value)
		{
			return CDmSoft.SetEnv(this._dm, index, name, value);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetExactOcr(IntPtr dm, int exact_ocr);

		public int SetExactOcr(int exact_ocr)
		{
			return CDmSoft.SetExactOcr(this._dm, exact_ocr);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetExportDict(IntPtr dm, int index, string dict_name);

		public int SetExportDict(int index, string dict_name)
		{
			return CDmSoft.SetExportDict(this._dm, index, dict_name);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetKeypadDelay(IntPtr dm, string type_, int delay);

		public int SetKeypadDelay(string type_, int delay)
		{
			return CDmSoft.SetKeypadDelay(this._dm, type_, delay);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetMemoryFindResultToFile(IntPtr dm, string file_);

		public int SetMemoryFindResultToFile(string file_)
		{
			return CDmSoft.SetMemoryFindResultToFile(this._dm, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetMemoryHwndAsProcessId(IntPtr dm, int en);

		public int SetMemoryHwndAsProcessId(int en)
		{
			return CDmSoft.SetMemoryHwndAsProcessId(this._dm, en);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetMinColGap(IntPtr dm, int col_gap);

		public int SetMinColGap(int col_gap)
		{
			return CDmSoft.SetMinColGap(this._dm, col_gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetMinRowGap(IntPtr dm, int row_gap);

		public int SetMinRowGap(int row_gap)
		{
			return CDmSoft.SetMinRowGap(this._dm, row_gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetMouseDelay(IntPtr dm, string type_, int delay);

		public int SetMouseDelay(string type_, int delay)
		{
			return CDmSoft.SetMouseDelay(this._dm, type_, delay);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetPath(IntPtr dm, string path);

		public int SetPath(string path)
		{
			return CDmSoft.SetPath(this._dm, path);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetPicPwd(IntPtr dm, string pwd);

		public int SetPicPwd(string pwd)
		{
			return CDmSoft.SetPicPwd(this._dm, pwd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetRowGapNoDict(IntPtr dm, int row_gap);

		public int SetRowGapNoDict(int row_gap)
		{
			return CDmSoft.SetRowGapNoDict(this._dm, row_gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetScreen(IntPtr dm, int width, int height, int depth);

		public int SetScreen(int width, int height, int depth)
		{
			return CDmSoft.SetScreen(this._dm, width, height, depth);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetShowErrorMsg(IntPtr dm, int show);

		public int SetShowErrorMsg(int show)
		{
			return CDmSoft.SetShowErrorMsg(this._dm, show);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetSimMode(IntPtr dm, int mode);

		public int SetSimMode(int mode)
		{
			return CDmSoft.SetSimMode(this._dm, mode);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetUAC(IntPtr dm, int uac);

		public int SetUAC(int uac)
		{
			return CDmSoft.SetUAC(this._dm, uac);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWindowSize(IntPtr dm, int hwnd, int width, int height);

		public int SetWindowSize(int hwnd, int width, int height)
		{
			return CDmSoft.SetWindowSize(this._dm, hwnd, width, height);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWindowState(IntPtr dm, int hwnd, int flag);

		public int SetWindowState(int hwnd, int flag)
		{
			return CDmSoft.SetWindowState(this._dm, hwnd, flag);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWindowText(IntPtr dm, int hwnd, string text);

		public int SetWindowText(int hwnd, string text)
		{
			return CDmSoft.SetWindowText(this._dm, hwnd, text);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWindowTransparent(IntPtr dm, int hwnd, int v);

		public int SetWindowTransparent(int hwnd, int v)
		{
			return CDmSoft.SetWindowTransparent(this._dm, hwnd, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWordGap(IntPtr dm, int word_gap);

		public int SetWordGap(int word_gap)
		{
			return CDmSoft.SetWordGap(this._dm, word_gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWordGapNoDict(IntPtr dm, int word_gap);

		public int SetWordGapNoDict(int word_gap)
		{
			return CDmSoft.SetWordGapNoDict(this._dm, word_gap);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWordLineHeight(IntPtr dm, int line_height);

		public int SetWordLineHeight(int line_height)
		{
			return CDmSoft.SetWordLineHeight(this._dm, line_height);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int SetWordLineHeightNoDict(IntPtr dm, int line_height);

		public int SetWordLineHeightNoDict(int line_height)
		{
			return CDmSoft.SetWordLineHeightNoDict(this._dm, line_height);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int ShowScrMsg(IntPtr dm, int x1, int y1, int x2, int y2, string msg, string color);

		public int ShowScrMsg(int x1, int y1, int x2, int y2, string msg, string color)
		{
			return CDmSoft.ShowScrMsg(this._dm, x1, y1, x2, y2, msg, color);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr SortPosDistance(IntPtr dm, string all_pos, int type_, int x, int y);

		public string SortPosDistance(string all_pos, int type_, int x, int y)
		{
			return Marshal.PtrToStringUni(CDmSoft.SortPosDistance(this._dm, all_pos, type_, x, y));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int Stop(IntPtr dm, int id);

		public int Stop(int id)
		{
			return CDmSoft.Stop(this._dm, id);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr StringToData(IntPtr dm, string string_value, int type_);

		public string StringToData(string string_value, int type_)
		{
			return Marshal.PtrToStringUni(CDmSoft.StringToData(this._dm, string_value, type_));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int StrStr(IntPtr dm, string s, string str);

		public int StrStr(string s, string str)
		{
			return CDmSoft.StrStr(this._dm, s, str);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int TerminateProcess(IntPtr dm, int pid);

		public int TerminateProcess(int pid)
		{
			return CDmSoft.TerminateProcess(this._dm, pid);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int UnBindWindow(IntPtr dm);

		public int UnBindWindow()
		{
			return CDmSoft.UnBindWindow(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int UseDict(IntPtr dm, int index);

		public int UseDict(int index)
		{
			return CDmSoft.UseDict(this._dm, index);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern IntPtr Ver(IntPtr dm);

		public string Ver()
		{
			return Marshal.PtrToStringUni(CDmSoft.Ver(this._dm));
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int VirtualAllocEx(IntPtr dm, int hwnd, int addr, int size, int type_);

		public int VirtualAllocEx(int hwnd, int addr, int size, int type_)
		{
			return CDmSoft.VirtualAllocEx(this._dm, hwnd, addr, size, type_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int VirtualFreeEx(IntPtr dm, int hwnd, int addr);

		public int VirtualFreeEx(int hwnd, int addr)
		{
			return CDmSoft.VirtualFreeEx(this._dm, hwnd, addr);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WaitKey(IntPtr dm, int key_code, int time_out);

		public int WaitKey(int key_code, int time_out)
		{
			return CDmSoft.WaitKey(this._dm, key_code, time_out);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WheelDown(IntPtr dm);

		public int WheelDown()
		{
			return CDmSoft.WheelDown(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WheelUp(IntPtr dm);

		public int WheelUp()
		{
			return CDmSoft.WheelUp(this._dm);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteData(IntPtr dm, int hwnd, string addr, string data);

		public int WriteData(int hwnd, string addr, string data)
		{
			return CDmSoft.WriteData(this._dm, hwnd, addr, data);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteDataAddr(IntPtr dm, int hwnd, int addr, string data);

		public int WriteDataAddr(int hwnd, int addr, string data)
		{
			return CDmSoft.WriteDataAddr(this._dm, hwnd, addr, data);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteDouble(IntPtr dm, int hwnd, string addr, double v);

		public int WriteDouble(int hwnd, string addr, double v)
		{
			return CDmSoft.WriteDouble(this._dm, hwnd, addr, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteDoubleAddr(IntPtr dm, int hwnd, int addr, double v);

		public int WriteDoubleAddr(int hwnd, int addr, double v)
		{
			return CDmSoft.WriteDoubleAddr(this._dm, hwnd, addr, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteFile(IntPtr dm, string file_, string content);

		public int WriteFile(string file_, string content)
		{
			return CDmSoft.WriteFile(this._dm, file_, content);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteFloat(IntPtr dm, int hwnd, string addr, float v);

		public int WriteFloat(int hwnd, string addr, float v)
		{
			return CDmSoft.WriteFloat(this._dm, hwnd, addr, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteFloatAddr(IntPtr dm, int hwnd, int addr, float v);

		public int WriteFloatAddr(int hwnd, int addr, float v)
		{
			return CDmSoft.WriteFloatAddr(this._dm, hwnd, addr, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteIni(IntPtr dm, string section, string key, string v, string file_);

		public int WriteIni(string section, string key, string v, string file_)
		{
			return CDmSoft.WriteIni(this._dm, section, key, v, file_);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteIniPwd(IntPtr dm, string section, string key, string v, string file_, string pwd);

		public int WriteIniPwd(string section, string key, string v, string file_, string pwd)
		{
			return CDmSoft.WriteIniPwd(this._dm, section, key, v, file_, pwd);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteInt(IntPtr dm, int hwnd, string addr, int type_, int v);

		public int WriteInt(int hwnd, string addr, int type_, int v)
		{
			return CDmSoft.WriteInt(this._dm, hwnd, addr, type_, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteIntAddr(IntPtr dm, int hwnd, int addr, int type_, int v);

		public int WriteIntAddr(int hwnd, int addr, int type_, int v)
		{
			return CDmSoft.WriteIntAddr(this._dm, hwnd, addr, type_, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteString(IntPtr dm, int hwnd, string addr, int type_, string v);

		public int WriteString(int hwnd, string addr, int type_, string v)
		{
			return CDmSoft.WriteString(this._dm, hwnd, addr, type_, v);
		}

		[DllImport("dmc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, ExactSpelling=false)]
		public static extern int WriteStringAddr(IntPtr dm, int hwnd, int addr, int type_, string v);

		public int WriteStringAddr(int hwnd, int addr, int type_, string v)
		{
			return CDmSoft.WriteStringAddr(this._dm, hwnd, addr, type_, v);
		}
	}
}