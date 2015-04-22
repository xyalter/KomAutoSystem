using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    partial class frmTimer
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
            // pbBtn
            // 
            this.pbBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pbBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBtn.Location = new System.Drawing.Point(0, 128);
            this.pbBtn.Name = "pbBtn";
            this.pbBtn.Size = new System.Drawing.Size(370, 46);
            this.pbBtn.TabIndex = 1;
            this.pbBtn.TabStop = false;
            // 
            // btCancle
            // 
            this.btCancle.BackColor = System.Drawing.Color.Transparent;
            this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancle.Location = new System.Drawing.Point(13, 139);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 23);
            this.btCancle.TabIndex = 4;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.UseVisualStyleBackColor = false;
            this.btCancle.Click += new EventHandler(this.btCancle_Click);
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.Transparent;
            this.btOk.Enabled = false;
            this.btOk.Location = new System.Drawing.Point(283, 139);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "保存(&O)";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new EventHandler(this.btOk_Click);
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.Transparent;
            this.btClear.Enabled = false;
            this.btClear.Location = new System.Drawing.Point(103, 139);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 5;
            this.btClear.Text = "清除(&R)";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new EventHandler(this.btClear_Click);
            // 
            // btSync
            // 
            this.btSync.BackColor = System.Drawing.Color.Transparent;
            this.btSync.Location = new System.Drawing.Point(193, 139);
            this.btSync.Name = "btSync";
            this.btSync.Size = new System.Drawing.Size(75, 23);
            this.btSync.TabIndex = 6;
            this.btSync.Text = "同步(&S)";
            this.btSync.UseVisualStyleBackColor = false;
            this.btSync.Click += new EventHandler(this.btSync_Click);
            // 
            // lSpan
            // 
            this.lSpan.BackColor = System.Drawing.Color.White;
            this.lSpan.BorderStyle = BorderStyle.FixedSingle;
            this.lSpan.Font = new System.Drawing.Font("微软雅黑", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.lSpan.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lSpan.Location = new System.Drawing.Point(13, 9);
            this.lSpan.Name = "lSpan";
            this.lSpan.Size = new System.Drawing.Size(345, 80);
            this.lSpan.TabIndex = 7;
            this.lSpan.Text = "0 天 0 小时 0 分 0 秒";
            this.lSpan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lSpan.UseMnemonic = false;
            // 
            // tbDays
            // 
            this.tbDays.Location = new System.Drawing.Point(14, 101);
            this.tbDays.MaxLength = 3;
            this.tbDays.Name = "tbDays";
            this.tbDays.Size = new System.Drawing.Size(50, 21);
            this.tbDays.TabIndex = 8;
            this.tbDays.Text = "0";
            this.tbDays.TextAlign = HorizontalAlignment.Center;
            this.tbDays.TextChanged += new EventHandler(this.tbDays_TextChanged);
            this.tbDays.KeyPress += new KeyPressEventHandler(this.tbNumFilter_KeyPress);
            this.tbDays.Leave += new EventHandler(this.tbNumFilter_Leave);






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
            // frmTimer
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btCancle;
            this.ClientSize = new System.Drawing.Size(370, 174);
            this.Controls.Add(this.lTip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSeconds);
            this.Controls.Add(this.tbMinutes);
            this.Controls.Add(this.tbHours);
            this.Controls.Add(this.tbDays);
            this.Controls.Add(this.lSpan);
            this.Controls.Add(this.btSync);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.pbBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置技能定时器";
            ((System.ComponentModel.ISupportInitialize)(this.pbBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbBtn;
        private Button btCancle;
        private Button btOk;
        private Button btClear;
        private Button btSync;
        private Label lSpan;
        private TextBox tbDays;
        private TextBox tbHours;
        private TextBox tbMinutes;
        private TextBox tbSeconds;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Timer tSkillSpan;
        private Label lTip;
    }
}
