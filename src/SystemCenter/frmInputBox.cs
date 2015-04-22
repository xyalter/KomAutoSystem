using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    public class frmInputBox : Form
    {
        private IContainer components;

        private PictureBox pbBt;

        private Button btOK;

        private Button btCancle;

        private TextBox tbVal;

        private Label lText;

        private Label lCnt;

        private Label lbKeyScore;

        private ProgressBar pbUKey;

        private bool bMaxCheck;

        private bool bPassword;

        private bool bMustInput;

        private bool bUKey;

        private string sUKey = string.Empty;

        private bool bUKeyIsValidate;

        private static bool _UKeyIsValidate;

        private int iUKeyWaitTimeout;

        static frmInputBox()
        {
        }

        public frmInputBox()
        {
            this.InitializeComponent();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
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

        private void frmInputBox_Shown(object sender, EventArgs e)
        {
            this.tbVal.Focus();
            this.tbVal.SelectAll();
            if (this.bUKey)
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(this.tUKey_Tick);
                timer.Interval = 1000;
                timer.Start();
            }
        }

        private void InitializeComponent()
        {
            this.pbBt = new PictureBox();
            this.btOK = new Button();
            this.btCancle = new Button();
            this.tbVal = new TextBox();
            this.lText = new Label();
            this.lCnt = new Label();
            this.lbKeyScore = new Label();
            this.pbUKey = new ProgressBar();
            ((ISupportInitialize)this.pbBt).BeginInit();
            base.SuspendLayout();
            this.pbBt.BackColor = SystemColors.Control;
            this.pbBt.Dock = DockStyle.Bottom;
            this.pbBt.Location = new Point(0, 107);
            this.pbBt.Name = "pbBt";
            this.pbBt.Size = new Size(394, 50);
            this.pbBt.TabIndex = 0;
            this.pbBt.TabStop = false;
            this.btOK.BackColor = Color.Transparent;
            this.btOK.Location = new Point(200, 122);
            this.btOK.Name = "btOK";
            this.btOK.Size = new Size(75, 23);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "确定(&O)";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new EventHandler(this.btOK_Click);
            this.btCancle.BackColor = Color.Transparent;
            this.btCancle.DialogResult = DialogResult.Cancel;
            this.btCancle.Location = new Point(119, 122);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new Size(75, 23);
            this.btCancle.TabIndex = 2;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.UseVisualStyleBackColor = false;
            this.btCancle.Click += new EventHandler(this.btCancle_Click);
            this.tbVal.Location = new Point(12, 54);
            this.tbVal.Name = "tbVal";
            this.tbVal.Size = new Size(370, 21);
            this.tbVal.TabIndex = 0;
            this.tbVal.TextChanged += new EventHandler(this.tbVal_TextChanged);
            this.tbVal.KeyPress += new KeyPressEventHandler(this.tbVal_KeyPress);
            this.lText.AutoEllipsis = true;
            this.lText.Location = new Point(12, 9);
            this.lText.Name = "lText";
            this.lText.Size = new Size(370, 42);
            this.lText.TabIndex = 4;
            this.lText.Text = "请输入:";
            this.lCnt.ForeColor = Color.DarkCyan;
            this.lCnt.Location = new Point(182, 78);
            this.lCnt.Name = "lCnt";
            this.lCnt.Size = new Size(200, 12);
            this.lCnt.TabIndex = 5;
            this.lCnt.Text = "已输入0字符";
            this.lCnt.TextAlign = ContentAlignment.MiddleRight;
            this.lbKeyScore.ForeColor = Color.DarkGray;
            this.lbKeyScore.Location = new Point(12, 78);
            this.lbKeyScore.Name = "lbKeyScore";
            this.lbKeyScore.Size = new Size(200, 12);
            this.lbKeyScore.TabIndex = 7;
            this.lbKeyScore.Text = "输入密码检测强度";
            this.lbKeyScore.TextAlign = ContentAlignment.MiddleLeft;
            this.lbKeyScore.Visible = false;
            this.pbUKey.ForeColor = Color.SteelBlue;
            this.pbUKey.Location = new Point(12, 54);
            this.pbUKey.Name = "pbUKey";
            this.pbUKey.Size = new Size(370, 21);
            this.pbUKey.TabIndex = 8;
            this.pbUKey.Visible = false;
            base.AcceptButton = this.btOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.CancelButton = this.btCancle;
            base.ClientSize = new Size(394, 157);
            base.Controls.Add(this.pbUKey);
            base.Controls.Add(this.lbKeyScore);
            base.Controls.Add(this.lCnt);
            base.Controls.Add(this.lText);
            base.Controls.Add(this.tbVal);
            base.Controls.Add(this.btCancle);
            base.Controls.Add(this.btOK);
            base.Controls.Add(this.pbBt);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmInputBox";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "InputBox";
            base.Shown += new EventHandler(this.frmInputBox_Shown);
            ((ISupportInitialize)this.pbBt).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public static DialogResult Show(string sTitle, string sPrompt, string sDefault, bool bPassword, IWin32Window owner, out string sValOut)
        {
            return frmInputBox.Show(sTitle, sPrompt, sDefault, bPassword, 0, false, string.Empty, owner, out sValOut, out frmInputBox._UKeyIsValidate);
        }

        public static DialogResult Show(string sTitle, string sPrompt, string sDefault, bool bPassword, int iMax, IWin32Window owner, out string sValOut)
        {
            return frmInputBox.Show(sTitle, sPrompt, sDefault, bPassword, iMax, false, string.Empty, owner, out sValOut, out frmInputBox._UKeyIsValidate);
        }

        public static DialogResult Show(string sTitle, string sPrompt, string sDefault, bool bPassword, int iMax, bool bMustInput, IWin32Window owner, out string sValOut)
        {
            return frmInputBox.Show(sTitle, sPrompt, sDefault, bPassword, iMax, bMustInput, string.Empty, owner, out sValOut, out frmInputBox._UKeyIsValidate);
        }

        public static DialogResult Show(string sTitle, string sPrompt, string sDefault, bool bPassword, int iMax, bool bMustInput, string sUKey, IWin32Window owner, out string sValOut, out bool bUKeyIsValidate)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            frmInputBox _frmInputBox = new frmInputBox()
            {
                Text = sTitle
            };
            _frmInputBox.lText.Text = sPrompt;
            _frmInputBox.tbVal.Text = sDefault;
            _frmInputBox.bMaxCheck = iMax > 0;
            if (_frmInputBox.bMaxCheck)
            {
                _frmInputBox.tbVal.MaxLength = iMax;
            }
            _frmInputBox.bPassword = bPassword;
            _frmInputBox.bMustInput = bMustInput;
            if (_frmInputBox.bPassword)
            {
                _frmInputBox.tbVal.PasswordChar = '*';
                _frmInputBox.lbKeyScore.Visible = true;
            }
            _frmInputBox.bUKey = !string.IsNullOrEmpty(sUKey);
            if (_frmInputBox.bUKey)
            {
                _frmInputBox.sUKey = sUKey;
                _frmInputBox.lbKeyScore.Visible = false;
                _frmInputBox.tbVal.Visible = false;
                _frmInputBox.lCnt.Visible = false;
                _frmInputBox.pbUKey.Visible = true;
                _frmInputBox.pbUKey.Style = ProgressBarStyle.Marquee;
            }
            if (_frmInputBox.bMustInput)
            {
                _frmInputBox.btOK.Enabled = !string.IsNullOrEmpty(_frmInputBox.tbVal.Text);
            }
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = _frmInputBox.ShowDialog(owner)));
            if (dialogResult != DialogResult.OK)
            {
                sValOut = sDefault;
                bUKeyIsValidate = false;
            }
            else
            {
                sValOut = _frmInputBox.tbVal.Text;
                bUKeyIsValidate = _frmInputBox.bUKeyIsValidate;
            }
            return dialogResult;
        }

        private void tbVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void tbVal_TextChanged(object sender, EventArgs e)
        {
            if (!this.bMaxCheck)
            {
                Label label = this.lCnt;
                int length = this.tbVal.Text.Length;
                label.Text = string.Concat("已输入", length.ToString(), "字符");
            }
            else
            {
                Label label1 = this.lCnt;
                string[] str = new string[] { "已输入(", null, null, null, null };
                int num = this.tbVal.Text.Length;
                str[1] = num.ToString();
                str[2] = "/";
                str[3] = this.tbVal.MaxLength.ToString();
                str[4] = ")字符";
                label1.Text = string.Concat(str);
            }
            if (this.bMustInput)
            {
                this.btOK.Enabled = !string.IsNullOrEmpty(this.tbVal.Text);
            }
            if (this.bPassword)
            {
                if (string.IsNullOrEmpty(this.tbVal.Text))
                {
                    this.lbKeyScore.Text = "输入密码检测强度";
                    this.lbKeyScore.ForeColor = Color.DarkGray;
                    return;
                }
                int passwordScore = PasswordLevelKit.GetPasswordScore(this.tbVal.Text);
                Color color = Color.FromArgb(255 * (100 - passwordScore) / 100, 255 * passwordScore / 100, 0);
                this.lbKeyScore.ForeColor = color;
                switch (PasswordLevelKit.GetPasswordLevel(this.tbVal.Text))
                {
                    case PasswordLevelKit.PasswordLevel.None:
                        {
                            this.lbKeyScore.Text = string.Concat(passwordScore.ToString(), "分，这根本不是密码 T_T");
                            return;
                        }
                    case PasswordLevelKit.PasswordLevel.Very_Week:
                        {
                            this.lbKeyScore.Text = string.Concat(passwordScore.ToString(), "分，这密码弱爆了 >_<");
                            return;
                        }
                    case PasswordLevelKit.PasswordLevel.Week:
                        {
                            this.lbKeyScore.Text = string.Concat(passwordScore.ToString(), "分，幼儿园水平 →_→");
                            return;
                        }
                    case PasswordLevelKit.PasswordLevel.Good:
                        {
                            this.lbKeyScore.Text = string.Concat(passwordScore.ToString(), "分，这才是合格的密码 ^_^");
                            return;
                        }
                    case PasswordLevelKit.PasswordLevel.Strong:
                        {
                            this.lbKeyScore.Text = string.Concat(passwordScore.ToString(), "分，灰常给力的密码 ^3^");
                            return;
                        }
                    case PasswordLevelKit.PasswordLevel.Very_Strong:
                        {
                            this.lbKeyScore.Text = string.Concat(passwordScore.ToString(), "分，这密码碉堡了 ⊙o⊙");
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
        }

        private void tUKey_Tick(object sender, EventArgs e)
        {
            if (this.bUKeyIsValidate)
            {
                base.Close();
                return;
            }
            USBDiskInfo[] uSBDiskInfoArray = PnPDevice.WhoUsbDisk(this.sUKey);
            frmInputBox _frmInputBox = this;
            _frmInputBox.iUKeyWaitTimeout = _frmInputBox.iUKeyWaitTimeout + 1;
            if (uSBDiskInfoArray == null || this.sUKey.Length < 1)
            {
                if (!this.tbVal.Visible && this.iUKeyWaitTimeout > 5)
                {
                    this.tbVal.Visible = true;
                    this.lCnt.Visible = true;
                    this.pbUKey.Visible = false;
                }
                return;
            }
            this.tbVal.ReadOnly = true;
            this.bUKeyIsValidate = true;
            this.btCancle.Enabled = false;
            this.lText.ForeColor = Color.Green;
            this.lText.Text = string.Concat("已经插入正确的 UKey !\r\n\r\n设备序列号: ", uSBDiskInfoArray[0].SerialNumber);
            for (int i = 0; i < 75; i++)
            {
                Thread.Sleep(20);
                Application.DoEvents();
            }
            base.DialogResult = DialogResult.OK;
        }
    }

}
