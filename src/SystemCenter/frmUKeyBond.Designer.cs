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
    partial class frmUKeyBond
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbBt = new System.Windows.Forms.PictureBox();
            this.btCancle = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.lText = new System.Windows.Forms.Label();
            this.cbUKeyList = new System.Windows.Forms.ComboBox();
            this.lSeq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBt)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBt
            // 
            this.pbBt.BackColor = System.Drawing.SystemColors.Control;
            this.pbBt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBt.Location = new System.Drawing.Point(0, 107);
            this.pbBt.Name = "pbBt";
            this.pbBt.Size = new System.Drawing.Size(394, 50);
            this.pbBt.TabIndex = 1;
            this.pbBt.TabStop = false;
            // 
            // btCancle
            // 
            this.btCancle.BackColor = System.Drawing.Color.Transparent;
            this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancle.Location = new System.Drawing.Point(119, 122);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 23);
            this.btCancle.TabIndex = 4;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.UseVisualStyleBackColor = false;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Transparent;
            this.btOK.Location = new System.Drawing.Point(200, 122);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "确定(&O)";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lText
            // 
            this.lText.AutoEllipsis = true;
            this.lText.Location = new System.Drawing.Point(12, 9);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(370, 42);
            this.lText.TabIndex = 5;
            this.lText.Text = "请输入:";
            // 
            // cbUKeyList
            // 
            this.cbUKeyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUKeyList.FormattingEnabled = true;
            this.cbUKeyList.Location = new System.Drawing.Point(14, 54);
            this.cbUKeyList.Name = "cbUKeyList";
            this.cbUKeyList.Size = new System.Drawing.Size(368, 20);
            this.cbUKeyList.TabIndex = 6;
            this.cbUKeyList.SelectedIndexChanged += new System.EventHandler(this.cbUKeyList_SelectedIndexChanged);
            // 
            // lSeq
            // 
            this.lSeq.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lSeq.Location = new System.Drawing.Point(14, 77);
            this.lSeq.Name = "lSeq";
            this.lSeq.Size = new System.Drawing.Size(368, 12);
            this.lSeq.TabIndex = 7;
            this.lSeq.Text = "设备序列号: N/A";
            this.lSeq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmUKeyBond
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btCancle;
            this.ClientSize = new System.Drawing.Size(394, 157);
            this.Controls.Add(this.lSeq);
            this.Controls.Add(this.cbUKeyList);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.pbBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUKeyBond";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UKeyBond";
            ((System.ComponentModel.ISupportInitialize)(this.pbBt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbBt;
        private Button btCancle;
        private Button btOK;
        private Label lText;
        private ComboBox cbUKeyList;
        private Label lSeq;
    }
}
