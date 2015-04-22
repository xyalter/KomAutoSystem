using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    public class frmTimer : Form
    {


        private TimeSpan SkillSpan;
        public DateTime SkillDeadLine;
        private bool bClear;

        public frmTimer()
        {
            InitializeComponent();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            this.bClear = true;
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btSync_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.SkillDeadLine = now.Add(new TimeSpan(int.Parse(this.tbDays.Text), int.Parse(this.tbHours.Text), int.Parse(this.tbMinutes.Text), int.Parse(this.tbSeconds.Text)));
            this.tSkillSpan.Enabled = true;
            this.btOk.Enabled = true;
            this.lTip.Text = "√已经同步";
            this.lTip.ForeColor = Color.DarkGreen;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.pbBtn = new PictureBox();
            this.btCancle = new Button();
            this.btOk = new Button();
            this.btClear = new Button();
            this.btSync = new Button();
            this.lSpan = new Label();
            this.tbDays = new TextBox();
            this.tbHours = new TextBox();
            this.tbMinutes = new TextBox();
            this.tbSeconds = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.tSkillSpan = new Timer(this.components);
            this.lTip = new Label();
            ((ISupportInitialize)this.pbBtn).BeginInit();
            base.SuspendLayout();





          
            this.tbHours.Location = new Point(104, 101);
            this.tbHours.Name = "tbHours";
            this.tbHours.Size = new Size(50, 21);
            this.tbHours.TabIndex = 9;
            this.tbHours.Text = "0";
            this.tbHours.TextAlign = HorizontalAlignment.Center;
            this.tbHours.TextChanged += new EventHandler(this.tbHours_TextChanged);
            this.tbHours.KeyPress += new KeyPressEventHandler(this.tbNumFilter_KeyPress);
            this.tbHours.Leave += new EventHandler(this.tbNumFilter_Leave);
            this.tbMinutes.Location = new Point(194, 101);
            this.tbMinutes.Name = "tbMinutes";
            this.tbMinutes.Size = new Size(50, 21);
            this.tbMinutes.TabIndex = 10;
            this.tbMinutes.Text = "0";
            this.tbMinutes.TextAlign = HorizontalAlignment.Center;
            this.tbMinutes.TextChanged += new EventHandler(this.tbMinutes_TextChanged);
            this.tbMinutes.KeyPress += new KeyPressEventHandler(this.tbNumFilter_KeyPress);
            this.tbMinutes.Leave += new EventHandler(this.tbNumFilter_Leave);
            this.tbSeconds.Location = new Point(284, 101);
            this.tbSeconds.Name = "tbSeconds";
            this.tbSeconds.Size = new Size(50, 21);
            this.tbSeconds.TabIndex = 11;
            this.tbSeconds.Text = "0";
            this.tbSeconds.TextAlign = HorizontalAlignment.Center;
            this.tbSeconds.TextChanged += new EventHandler(this.tbSeconds_TextChanged);
            this.tbSeconds.KeyPress += new KeyPressEventHandler(this.tbNumFilter_KeyPress);
            this.tbSeconds.Leave += new EventHandler(this.tbNumFilter_Leave);
            this.label1.Location = new Point(70, 101);
            this.label1.Name = "label1";
            this.label1.Size = new Size(28, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "天";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.Location = new Point(160, 101);
            this.label2.Name = "label2";
            this.label2.Size = new Size(28, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "时";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.label3.Location = new Point(250, 100);
            this.label3.Name = "label3";
            this.label3.Size = new Size(28, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "分";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.label4.Location = new Point(340, 100);
            this.label4.Name = "label4";
            this.label4.Size = new Size(28, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "秒";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.tSkillSpan.Tick += new EventHandler(this.tSkillSpan_Tick);
            this.lTip.BackColor = Color.White;
            this.lTip.ForeColor = Color.Maroon;
            this.lTip.Location = new Point(15, 74);
            this.lTip.Name = "lTip";
            this.lTip.Size = new Size(341, 12);
            this.lTip.TabIndex = 16;
            this.lTip.Text = "×需要同步";
            this.lTip.TextAlign = ContentAlignment.BottomRight;



            base.PerformLayout();
        }

        public static DialogResult Show(IWin32Window owner, string pDeadLine, out string oDeadLine)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            frmTimer _frmTimer = new frmTimer();
            if (!string.IsNullOrEmpty(pDeadLine))
            {
                _frmTimer.SkillDeadLine = DateTime.Parse(pDeadLine);
                _frmTimer.SkillSpan = _frmTimer.SkillDeadLine - DateTime.Now;
                _frmTimer.tbDays.Text = _frmTimer.SkillSpan.Days.ToString();
                _frmTimer.tbHours.Text = _frmTimer.SkillSpan.Hours.ToString();
                _frmTimer.tbMinutes.Text = _frmTimer.SkillSpan.Minutes.ToString();
                _frmTimer.tbSeconds.Text = _frmTimer.SkillSpan.Seconds.ToString();
                _frmTimer.tSkillSpan.Enabled = true;
                _frmTimer.btClear.Enabled = true;
            }
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = _frmTimer.ShowDialog(owner)));
            oDeadLine = _frmTimer.SkillDeadLine.ToString("yyyy-MM-dd HH:mm:ss");
            if (_frmTimer.bClear)
            {
                oDeadLine = string.Empty;
            }
            return dialogResult;
        }

        private void tbDays_TextChanged(object sender, EventArgs e)
        {
            this.lTip.Text = "×需要同步";
            this.tSkillSpan.Enabled = false;
            this.btOk.Enabled = false;
            this.lTip.ForeColor = Color.Maroon;
        }

        private void tbHours_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbHours.Text))
            {
                if (this.tbHours.Text.Length > 3)
                {
                    this.tbHours.Text = this.tbHours.Text.Substring(this.tbHours.Text.Length - 2);
                }
                if (int.Parse(this.tbHours.Text) >= 24)
                {
                    this.tbHours.Text = this.tbHours.Text.Substring(this.tbHours.Text.Length - 1);
                }
                this.tbHours.SelectionLength = 0;
                this.tbHours.SelectionStart = this.tbHours.Text.Length;
            }
            this.lTip.Text = "×需要同步";
            this.tSkillSpan.Enabled = false;
            this.btOk.Enabled = false;
            this.lTip.ForeColor = Color.Maroon;
        }

        private void tbMinutes_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbMinutes.Text))
            {
                if (this.tbMinutes.Text.Length > 3)
                {
                    this.tbMinutes.Text = this.tbMinutes.Text.Substring(this.tbMinutes.Text.Length - 2);
                }
                if (int.Parse(this.tbMinutes.Text) >= 60)
                {
                    this.tbMinutes.Text = this.tbMinutes.Text.Substring(this.tbMinutes.Text.Length - 1);
                }
                this.tbMinutes.SelectionLength = 0;
                this.tbMinutes.SelectionStart = this.tbMinutes.Text.Length;
            }
            this.lTip.Text = "×需要同步";
            this.tSkillSpan.Enabled = false;
            this.btOk.Enabled = false;
            this.lTip.ForeColor = Color.Maroon;
        }

        private void tbNumFilter_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void tbNumFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tbNumFilter_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        private void tbSeconds_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbSeconds.Text))
            {
                if (this.tbSeconds.Text.Length > 3)
                {
                    this.tbSeconds.Text = this.tbSeconds.Text.Substring(this.tbSeconds.Text.Length - 2);
                }
                if (int.Parse(this.tbSeconds.Text) >= 60)
                {
                    this.tbSeconds.Text = this.tbSeconds.Text.Substring(this.tbSeconds.Text.Length - 1);
                }
                this.tbSeconds.SelectionLength = 0;
                this.tbSeconds.SelectionStart = this.tbSeconds.Text.Length;
            }
            this.lTip.Text = "×需要同步";
            this.tSkillSpan.Enabled = false;
            this.btOk.Enabled = false;
            this.lTip.ForeColor = Color.Maroon;
        }

        private void tSkillSpan_Tick(object sender, EventArgs e)
        {
            this.SkillSpan = this.SkillDeadLine - DateTime.Now;
            Label label = this.lSpan;
            object[] str = new object[] { this.SkillSpan.Days.ToString(), this.SkillSpan.Hours.ToString(), this.SkillSpan.Minutes.ToString(), this.SkillSpan.Seconds.ToString() };
            label.Text = string.Format("{0} 天 {1} 时 {2} 分 {3} 秒", str);
        }
    }
}