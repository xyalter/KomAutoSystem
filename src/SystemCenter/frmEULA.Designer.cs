using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    partial class frmEULA
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
            this.tbEULA = new TextBox();
            this.btRefuse = new Button();
            this.btAccept = new Button();
            this.tbEULAHash = new TextBox();
            this.SuspendLayout();
            // 
            // tbEULA
            // 
            this.tbEULA.Location = new Point(12, 12);
            this.tbEULA.Multiline = true;
            this.tbEULA.Name = "tbEULA";
            this.tbEULA.ReadOnly = true;
            this.tbEULA.ScrollBars = ScrollBars.Both;
            this.tbEULA.Size = new Size(560, 309);
            this.tbEULA.TabIndex = 0;
            // 
            // btRefuse
            // 
            this.btRefuse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btRefuse.Location = new Point(497, 327);
            this.btRefuse.Name = "btRefuse";
            this.btRefuse.Size = new Size(75, 23);
            this.btRefuse.TabIndex = 1;
            this.btRefuse.Text = "拒绝(&D)";
            this.btRefuse.UseVisualStyleBackColor = true;
            // 
            // btAccept
            // 
            this.btAccept.Location = new Point(416, 327);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new Size(75, 23);
            this.btAccept.TabIndex = 2;
            this.btAccept.Text = "接受(&A)";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new EventHandler(this.btAccept_Click);
            // 
            // tbEULAHash
            // 
            this.tbEULAHash.Location = new Point(12, 327);
            this.tbEULAHash.Name = "tbEULAHash";
            this.tbEULAHash.Size = new Size(231, 21);
            this.tbEULAHash.TabIndex = 3;
            this.tbEULAHash.Visible = false;
            // 
            // frmUKeyBond
            // 
            this.AcceptButton = this.btAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btRefuse;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.tbEULAHash);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btRefuse);
            this.Controls.Add(this.tbEULA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEULA";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEULA";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox tbEULA;
        private Button btRefuse;
        private Button btAccept;
        private TextBox tbEULAHash;
    }
}
