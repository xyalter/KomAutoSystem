using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EVE_我们很勤劳
{
	public class main : Form
	{
		private CDmSoft dm_main = new CDmSoft();

		private Thread TH1;

		public static ArrayList YC_BH;

		public ArrayList Snid = new ArrayList();

		public ArrayList user_name = new ArrayList();

		public static int hjc;

		private zhixing ZX1 = new zhixing();

		private IContainer components;

		private ListBox user;

		private Button user_sx;

        private Label label1;
        private Label label11;
        private Label label12;
        private Label label2;

        private Button button1;

		static main()
		{
			main.YC_BH = new ArrayList();
			main.hjc = 0;
		}

		public main()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.user.SelectedItem == null)
			{
				MessageBox.Show("请选择角色！");
				return;
			}
			if (this.button1.Text != "开始")
			{
				this.user_name.Remove(this.label1.Text);
				this.label1.Text = "";
				this.label1.Visible = false;
				if (this.TH1.IsAlive)
				{
					this.ZX1.yunxin = false;
					this.ZX1.unbind();
					Thread.Sleep(1000);
					this.TH1.Abort();
				}
				this.button1.Text = "开始";
				return;
			}
			int num = this.Snid.IndexOf(this.user.SelectedItem.ToString());
			if (num == -1)
			{
				MessageBox.Show("未找到指定角色!");
				return;
			}
			this.ZX1.username = this.user.SelectedItem.ToString();
			this.ZX1.hwnd = Convert.ToInt32(this.Snid[num + 1].ToString());
			this.ZX1.yunxin = true;

            this.TH1 = new Thread(new ThreadStart(this.ZX1.sj_yj));

			this.label1.Text = this.user.SelectedItem.ToString();
			this.label1.Visible = true;
			for (int i = 0; i < this.user_name.Count; i++)
			{
				if (this.label1.Text == this.user_name[i].ToString())
				{
					MessageBox.Show("同一个角色不能操作两次！");
					this.label1.Text = "";
					return;
				}
			}
			this.user_name.Add(this.label1.Text);
			this.button1.Text = "结束";
			this.TH1.IsBackground = true;
			this.TH1.Start();
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.user = new System.Windows.Forms.ListBox();
            this.user_sx = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.FormattingEnabled = true;
            this.user.ItemHeight = 12;
            this.user.Location = new System.Drawing.Point(12, 12);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(155, 184);
            this.user.TabIndex = 0;
            // 
            // user_sx
            // 
            this.user_sx.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_sx.Location = new System.Drawing.Point(12, 214);
            this.user_sx.Name = "user_sx";
            this.user_sx.Size = new System.Drawing.Size(155, 30);
            this.user_sx.TabIndex = 1;
            this.user_sx.Text = "刷新角色";
            this.user_sx.UseVisualStyleBackColor = true;
            this.user_sx.Click += new System.EventHandler(this.user_sx_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(185, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 20);
            this.label11.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(186, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 20);
            this.label12.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "当前预警的角色";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 272);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.user_sx);
            this.Controls.Add(this.user);
            this.Name = "main";
            this.Text = "eve 预警";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		[STAThread]
		private void main_Load(object sender, EventArgs e)
		{
			string netTime = this.dm_main.GetNetTime();
			if (netTime == "")
			{
				MessageBox.Show("网络时间获取失败，程序结束！");
				base.Dispose();
			}
			DateTime dateTime = Convert.ToDateTime(netTime);
			DateTime dateTime1 = new DateTime(2015, 12, 15);
			if (dateTime > dateTime1)
			{
				MessageBox.Show("程序过期！");
				base.Dispose();
			}
			this.label11.Text = string.Concat("程序开始时间：", DateTime.Now);
			this.label12.Text = string.Concat("程序过期时间：", dateTime1);
		}

		private void user_sx_Click(object sender, EventArgs e)
		{
			string str = this.dm_main.EnumWindow(0, "EVE - ", "", 25);
			if (str == "")
			{
				MessageBox.Show("无角色登陆");
				return;
			}
			this.user.Items.Clear();
			this.Snid.Clear();
			string[] strArrays = str.Split(new char[] { ',' });
			for (int i = 0; (long)i < strArrays.LongLength; i++)
			{
				string windowTitle = this.dm_main.GetWindowTitle(Convert.ToInt32(strArrays[i]));
				string str1 = windowTitle.Remove(0, 6);
				this.Snid.Add(str1);
				this.Snid.Add(strArrays[i]);
				this.user.Items.Insert(i, str1);
				Thread.Sleep(1000);
			}
		}

	}
}