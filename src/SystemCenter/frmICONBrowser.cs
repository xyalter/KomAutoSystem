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
    public class frmICONBrowser : Form
    {
        private Graphics gICON;

        private IContainer components;

        private Label lbPrompt;

        private ListView lvICON;

        private Button btOK;

        private Button btCancle;

        private ImageList ilICON;

        private PictureBox pbICON;

        public frmICONBrowser()
        {
            this.InitializeComponent();
            NativeMethods.SendMessage(this.lvICON.Handle, 4149, 0, 3145776);
            this.gICON = this.pbICON.CreateGraphics();
            this.Debug();
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

        private void Debug()
        {
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
            this.components = new Container();
            this.lbPrompt = new Label();
            this.lvICON = new ListView();
            this.ilICON = new ImageList(this.components);
            this.btOK = new Button();
            this.btCancle = new Button();
            this.pbICON = new PictureBox();
            ((ISupportInitialize)this.pbICON).BeginInit();
            base.SuspendLayout();
            this.lbPrompt.Location = new Point(12, 12);
            this.lbPrompt.Name = "lbPrompt";
            this.lbPrompt.Size = new Size(287, 32);
            this.lbPrompt.TabIndex = 0;
            this.lbPrompt.Text = "n/a";
            this.lbPrompt.TextAlign = ContentAlignment.MiddleLeft;
            this.lvICON.LargeImageList = this.ilICON;
            this.lvICON.Location = new Point(12, 50);
            this.lvICON.MultiSelect = false;
            this.lvICON.Name = "lvICON";
            this.lvICON.Size = new Size(325, 174);
            this.lvICON.TabIndex = 1;
            this.lvICON.UseCompatibleStateImageBehavior = false;
            this.lvICON.SelectedIndexChanged += new EventHandler(this.lvICON_SelectedIndexChanged);
            this.lvICON.MouseDoubleClick += new MouseEventHandler(this.lvICON_MouseDoubleClick);
            this.ilICON.ColorDepth = ColorDepth.Depth32Bit;
            this.ilICON.ImageSize = new Size(32, 32);
            this.ilICON.TransparentColor = Color.Transparent;
            this.btOK.Location = new Point(262, 230);
            this.btOK.Name = "btOK";
            this.btOK.Size = new Size(75, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "确定(&O)";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new EventHandler(this.btOK_Click);
            this.btCancle.DialogResult = DialogResult.Cancel;
            this.btCancle.Location = new Point(181, 230);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new Size(75, 23);
            this.btCancle.TabIndex = 3;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new EventHandler(this.btCancle_Click);
            this.pbICON.Location = new Point(305, 12);
            this.pbICON.Name = "pbICON";
            this.pbICON.Size = new Size(32, 32);
            this.pbICON.TabIndex = 4;
            this.pbICON.TabStop = false;
            base.AcceptButton = this.btOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btCancle;
            base.ClientSize = new Size(349, 265);
            base.Controls.Add(this.pbICON);
            base.Controls.Add(this.btCancle);
            base.Controls.Add(this.btOK);
            base.Controls.Add(this.lvICON);
            base.Controls.Add(this.lbPrompt);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmICONBrowser";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "frmICONBrowser";
            ((ISupportInitialize)this.pbICON).EndInit();
            base.ResumeLayout(false);
        }

        private void lvICON_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void lvICON_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gICON.Clear(this.pbICON.BackColor);
            this.btOK.Enabled = this.lvICON.SelectedItems.Count > 0;
            if (this.lvICON.SelectedItems.Count <= 0)
            {
                return;
            }
            this.gICON.DrawImage(this.ilICON.Images[this.lvICON.SelectedItems[0].Index], 0, 0);
        }

        public static DialogResult Show(string sTitle, string sPrompt, string sResFile, IWin32Window owner, out int iValOut)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            frmICONBrowser _frmICONBrowser = new frmICONBrowser()
            {
                Text = sTitle
            };
            _frmICONBrowser.lbPrompt.Text = sPrompt;
            _frmICONBrowser.btOK.Enabled = false;
            Icon[] fileIcon = NativeMethods.GetFileIcon(sResFile);
            for (int i = 0; i < (int)fileIcon.Length; i++)
            {
                _frmICONBrowser.ilICON.Images.Add(fileIcon[i]);
                ListViewItem listViewItem = new ListViewItem()
                {
                    ImageIndex = i
                };
                _frmICONBrowser.lvICON.Items.Add(listViewItem);
            }
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = _frmICONBrowser.ShowDialog(owner)));
            if (dialogResult != DialogResult.OK)
            {
                iValOut = -1;
            }
            else
            {
                iValOut = _frmICONBrowser.lvICON.SelectedItems[0].Index;
            }
            return dialogResult;
        }
    }
}