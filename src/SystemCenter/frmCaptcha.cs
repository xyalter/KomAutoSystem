using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SystemCenter
{
    public class frmCaptcha : Form
    {
        private const string csGenerateGuidUrl = "https://auth.eve-online.com.cn/Account/GenerateGuid";

        private const string csGenerateImgUrl = "http://captcha.tiancity.com/getimage.ashx?tid=";

        private IContainer components;

        private PictureBox pbBtn;

        private Button btOk;

        private Button btCancle;

        private PictureBox pbCaptcha;

        private TextBox tbCaptcha;

        private Label lbRefresh;

        public string sUdidVal = "";

        public frmCaptcha()
        {
            this.InitializeComponent();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmCaptcha_Shown(object sender, EventArgs e)
        {
            this.tbCaptcha.Focus();
        }

        private string GetUdid()
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            string str = "";
            try
            {
                try
                {
                    httpWebRequest = (HttpWebRequest)WebRequest.Create("https://auth.eve-online.com.cn/Account/GenerateGuid");
                    httpWebRequest.Method = "GET";
                    response = (HttpWebResponse)httpWebRequest.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.ASCII);
                    str = streamReader.ReadToEnd().Trim();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.pbBtn = new PictureBox();
            this.btOk = new Button();
            this.btCancle = new Button();
            this.pbCaptcha = new PictureBox();
            this.tbCaptcha = new TextBox();
            this.lbRefresh = new Label();
            ((ISupportInitialize)this.pbBtn).BeginInit();
            ((ISupportInitialize)this.pbCaptcha).BeginInit();
            base.SuspendLayout();
            this.pbBtn.BackColor = SystemColors.Control;
            this.pbBtn.Dock = DockStyle.Bottom;
            this.pbBtn.Location = new Point(0, 78);
            this.pbBtn.Name = "pbBtn";
            this.pbBtn.Size = new Size(290, 46);
            this.pbBtn.TabIndex = 0;
            this.pbBtn.TabStop = false;
            this.btOk.BackColor = Color.Transparent;
            this.btOk.Enabled = false;
            this.btOk.Location = new Point(148, 89);
            this.btOk.Name = "btOk";
            this.btOk.Size = new Size(75, 23);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "确定(&O)";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new EventHandler(this.btOk_Click);
            this.btCancle.BackColor = Color.Transparent;
            this.btCancle.DialogResult = DialogResult.Cancel;
            this.btCancle.Location = new Point(67, 89);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new Size(75, 23);
            this.btCancle.TabIndex = 2;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.UseVisualStyleBackColor = false;
            this.btCancle.Click += new EventHandler(this.btCancle_Click);
            this.pbCaptcha.Location = new Point(12, 12);
            this.pbCaptcha.Name = "pbCaptcha";
            this.pbCaptcha.Size = new Size(160, 60);
            this.pbCaptcha.TabIndex = 3;
            this.pbCaptcha.TabStop = false;
            this.pbCaptcha.Click += new EventHandler(this.pbCaptcha_Click);
            this.tbCaptcha.Location = new Point(178, 51);
            this.tbCaptcha.MaxLength = 6;
            this.tbCaptcha.Name = "tbCaptcha";
            this.tbCaptcha.Size = new Size(100, 21);
            this.tbCaptcha.TabIndex = 0;
            this.tbCaptcha.TextAlign = HorizontalAlignment.Center;
            this.tbCaptcha.TextChanged += new EventHandler(this.tbCaptcha_TextChanged);
            this.tbCaptcha.KeyPress += new KeyPressEventHandler(this.tbCaptcha_KeyPress);
            this.lbRefresh.AutoSize = true;
            this.lbRefresh.Cursor = Cursors.Hand;
            this.lbRefresh.Font = new Font("宋体", 9f, FontStyle.Underline, GraphicsUnit.Point, 134);
            this.lbRefresh.ForeColor = Color.DarkCyan;
            this.lbRefresh.Location = new Point(178, 36);
            this.lbRefresh.Name = "lbRefresh";
            this.lbRefresh.Size = new Size(77, 12);
            this.lbRefresh.TabIndex = 4;
            this.lbRefresh.Text = "看不清换一下";
            this.lbRefresh.Click += new EventHandler(this.lbRefresh_Click);
            this.lbRefresh.MouseEnter += new EventHandler(this.lbRefresh_MouseEnter);
            this.lbRefresh.MouseLeave += new EventHandler(this.lbRefresh_MouseLeave);
            base.AcceptButton = this.btOk;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.CancelButton = this.btCancle;
            base.ClientSize = new Size(290, 124);
            base.Controls.Add(this.lbRefresh);
            base.Controls.Add(this.tbCaptcha);
            base.Controls.Add(this.pbCaptcha);
            base.Controls.Add(this.btCancle);
            base.Controls.Add(this.btOk);
            base.Controls.Add(this.pbBtn);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmCaptcha";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "请输入验证码";
            base.Shown += new EventHandler(this.frmCaptcha_Shown);
            ((ISupportInitialize)this.pbBtn).EndInit();
            ((ISupportInitialize)this.pbCaptcha).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbRefresh_Click(object sender, EventArgs e)
        {
            this.pbCaptcha.Load(string.Concat("http://captcha.tiancity.com/getimage.ashx?tid=", this.sUdidVal, "&fid=100"));
        }

        private void lbRefresh_MouseEnter(object sender, EventArgs e)
        {
            this.lbRefresh.ForeColor = Color.Crimson;
        }

        private void lbRefresh_MouseLeave(object sender, EventArgs e)
        {
            this.lbRefresh.ForeColor = Color.DarkCyan;
        }

        private void pbCaptcha_Click(object sender, EventArgs e)
        {
            this.pbCaptcha.Load(string.Concat("http://captcha.tiancity.com/getimage.ashx?tid=", this.sUdidVal, "&fid=100"));
        }

        public static DialogResult Show(IWin32Window owner, out string sUdid, out string sCaptcha)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            frmCaptcha _frmCaptcha = new frmCaptcha();
            _frmCaptcha.sUdidVal = _frmCaptcha.GetUdid();
            _frmCaptcha.pbCaptcha.Load(string.Concat("http://captcha.tiancity.com/getimage.ashx?tid=", _frmCaptcha.sUdidVal, "&fid=100"));
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = _frmCaptcha.ShowDialog(owner)));
            sUdid = _frmCaptcha.sUdidVal;
            sCaptcha = _frmCaptcha.tbCaptcha.Text;
            return dialogResult;
        }

        private void tbCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void tbCaptcha_TextChanged(object sender, EventArgs e)
        {
            if (this.tbCaptcha.Text.Length != 6)
            {
                this.btOk.Enabled = false;
                return;
            }
            this.btOk.Enabled = true;
        }
    }

}
