using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EVE_我们很勤劳
{
	internal class zhixing
	{
		private CDmSoft dm = new CDmSoft();

		public bool yunxin;

		public string username = "";

		public int hwnd;


		private int bzyc2;


		private int js;

		private int yj;

		private Thread gz;

		private Thread wq;

		public zhixing()
		{
		}

		private int dm_bind()
		{
			if (this.dm.IsBind(this.hwnd) == 1)
			{
				this.unbind();
			}
			Thread.Sleep(2000);
			int num = this.dm.BindWindow(this.hwnd, "gdi2", "dx", "dx", 0);
			Thread.Sleep(1000);
			return num;
		}

		private void dm_seting()
		{
			this.dm.DisablePowerSave();
			this.dm.DisableScreenSave();
			if (this.dm.SetMouseDelay("dx", 150) == 1)
			{
				this.flog("鼠标延迟设置成功");
			}
			if (this.dm.SetKeypadDelay("dx", 150) == 1)
			{
				this.flog("键盘延迟设置成功");
			}
			if (this.dm.SetDict(0, "eve.txt") == 1)
			{
				this.flog("字库设置成功！");
			}
			if (this.dm.UseDict(0) == 1)
			{
				this.flog("字库使用成功！");
			}
		}


		public void flog(string log)
		{
			string str = string.Concat(this.username, ".txt");
			FileStream fileStream = new FileStream(str, FileMode.Append, FileAccess.Write);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			streamWriter.Flush();
			object[] now = new object[] { DateTime.Now, "角色：", this.username, log };
			streamWriter.WriteLine(string.Concat(now));
			streamWriter.Close();
			fileStream.Close();
		}

		[DllImport("kernel32", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern int GetCurrentThreadId();

		[DllImport("User32.dll", CharSet=CharSet.Auto, ExactSpelling=false)]
		public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);


		public void sj_yj()
		{
			int num;
			this.bzyc2 = (new Random()).Next(1900, 2001);
			if (this.dm_bind() == 0)
			{
				this.flog(this.dm.GetLastError().ToString());
				this.flog("绑定失败！");
				MessageBox.Show(string.Concat("角色：", this.username, "绑定失败！"));
				return;
			}
			IntPtr intPtr = new IntPtr(this.hwnd);
			zhixing.GetWindowThreadProcessId(intPtr, out num);
			object[] currentThreadId = new object[] { ",PID", num, ",工作线程PID：", zhixing.GetCurrentThreadId(), " 绑定成功！" };
			this.flog(string.Concat(currentThreadId));
			this.dm_seting();
			while (this.yunxin)
			{
				if (this.dm.FindPicEx(805, 35, 870, 755, "hongxing.bmp|baiming.bmp|hongjian.bmp|chengjian.bmp", "000000", 0.9, 0) != "")
				{
					main.hjc = 1;
					this.dm.Beep(1000, 1000);
				}
				Thread.Sleep(this.bzyc2);
			}
		}



		public void unbind()
		{
			if (this.gz != null && this.gz.IsAlive)
			{
				this.gz.Abort();
			}
			this.flog("解绑!");
			this.dm.UnBindWindow();
		}
	}
}