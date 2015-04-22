using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SystemCenter
{
    public class frmUIEditor : Form
    {
        private string csUserPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CCP\\EVE\\d_games_eve_211.144.214.68\\settings\\");

        private string csGamePath = "";

        private Regex regexCfgFile = new Regex("core_char_\\d+?\\.dat", RegexOptions.Compiled);

        private Hashtable htCfg;

        private IContainer components;

        private MenuStrip msUIEditor;

        private ToolStripMenuItem 文件FToolStripMenuItem;

        private ToolStripMenuItem 打开OToolStripMenuItem;

        private ToolStripMenuItem 保存SToolStripMenuItem;

        private ToolStripMenuItem 用户文档下配置DToolStripMenuItem;

        private ToolStripMenuItem 游戏目录下配置GToolStripMenuItem;

        private ToolStripMenuItem 编辑EToolStripMenuItem;

        private ToolStripMenuItem 备份选中的用户配置BToolStripMenuItem;

        private ToolStripMenuItem 从备份中恢复用户配置RToolStripMenuItem;

        private Label lSelect;

        private ComboBox cbCfg;

        private CheckedListBox clbCfg;

        private Label lReplace;

        private ToolStripSeparator toolStripSeparator2;

        private ToolStripMenuItem 关闭XToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator1;

        public frmUIEditor()
        {
            this.InitializeComponent();
        }

        private void cbCfg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCfg.SelectedIndex >= 0)
            {
                for (int i = 0; i < this.clbCfg.Items.Count; i++)
                {
                    if (this.clbCfg.Items[i].ToString().Equals(this.cbCfg.SelectedItem.ToString()))
                    {
                        this.clbCfg.SetItemCheckState(i, CheckState.Indeterminate);
                    }
                    else if (this.clbCfg.GetItemCheckState(i) == CheckState.Indeterminate)
                    {
                        this.clbCfg.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
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
            this.msUIEditor = new MenuStrip();
            this.文件FToolStripMenuItem = new ToolStripMenuItem();
            this.打开OToolStripMenuItem = new ToolStripMenuItem();
            this.用户文档下配置DToolStripMenuItem = new ToolStripMenuItem();
            this.游戏目录下配置GToolStripMenuItem = new ToolStripMenuItem();
            this.保存SToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.关闭XToolStripMenuItem = new ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new ToolStripMenuItem();
            this.备份选中的用户配置BToolStripMenuItem = new ToolStripMenuItem();
            this.从备份中恢复用户配置RToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.lSelect = new Label();
            this.cbCfg = new ComboBox();
            this.clbCfg = new CheckedListBox();
            this.lReplace = new Label();
            this.msUIEditor.SuspendLayout();
            base.SuspendLayout();
            ToolStripItemCollection items = this.msUIEditor.Items;
            ToolStripItem[] toolStripItemArray = new ToolStripItem[] { this.文件FToolStripMenuItem, this.编辑EToolStripMenuItem };
            items.AddRange(toolStripItemArray);
            this.msUIEditor.Location = new Point(0, 0);
            this.msUIEditor.Name = "msUIEditor";
            this.msUIEditor.Size = new Size(594, 24);
            this.msUIEditor.TabIndex = 0;
            this.msUIEditor.Text = "menuStrip1";
            ToolStripItemCollection dropDownItems = this.文件FToolStripMenuItem.DropDownItems;
            ToolStripItem[] toolStripItemArray1 = new ToolStripItem[] { this.打开OToolStripMenuItem, this.保存SToolStripMenuItem, this.toolStripSeparator2, this.关闭XToolStripMenuItem };
            dropDownItems.AddRange(toolStripItemArray1);
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new Size(59, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            ToolStripItemCollection toolStripItemCollections = this.打开OToolStripMenuItem.DropDownItems;
            ToolStripItem[] toolStripItemArray2 = new ToolStripItem[] { this.用户文档下配置DToolStripMenuItem, this.游戏目录下配置GToolStripMenuItem };
            toolStripItemCollections.AddRange(toolStripItemArray2);
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new Size(112, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.用户文档下配置DToolStripMenuItem.Name = "用户文档下配置DToolStripMenuItem";
            this.用户文档下配置DToolStripMenuItem.Size = new Size(172, 22);
            this.用户文档下配置DToolStripMenuItem.Text = "用户文档下配置(&D)";
            this.用户文档下配置DToolStripMenuItem.Click += new EventHandler(this.用户文档下配置DToolStripMenuItem_Click);
            this.游戏目录下配置GToolStripMenuItem.Name = "游戏目录下配置GToolStripMenuItem";
            this.游戏目录下配置GToolStripMenuItem.Size = new Size(172, 22);
            this.游戏目录下配置GToolStripMenuItem.Text = "游戏目录下配置(G)";
            this.游戏目录下配置GToolStripMenuItem.Click += new EventHandler(this.游戏目录下配置GToolStripMenuItem_Click);
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new Size(112, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new EventHandler(this.保存SToolStripMenuItem_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(109, 6);
            this.关闭XToolStripMenuItem.Name = "关闭XToolStripMenuItem";
            this.关闭XToolStripMenuItem.Size = new Size(112, 22);
            this.关闭XToolStripMenuItem.Text = "关闭(&X)";
            this.关闭XToolStripMenuItem.Click += new EventHandler(this.关闭XToolStripMenuItem_Click);
            ToolStripItemCollection dropDownItems1 = this.编辑EToolStripMenuItem.DropDownItems;
            ToolStripItem[] toolStripItemArray3 = new ToolStripItem[] { this.备份选中的用户配置BToolStripMenuItem, this.从备份中恢复用户配置RToolStripMenuItem, this.toolStripSeparator1 };
            dropDownItems1.AddRange(toolStripItemArray3);
            this.编辑EToolStripMenuItem.Enabled = false;
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new Size(59, 20);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            this.备份选中的用户配置BToolStripMenuItem.Name = "备份选中的用户配置BToolStripMenuItem";
            this.备份选中的用户配置BToolStripMenuItem.Size = new Size(208, 22);
            this.备份选中的用户配置BToolStripMenuItem.Text = "备份选中的用户配置(&B)";
            this.从备份中恢复用户配置RToolStripMenuItem.Name = "从备份中恢复用户配置RToolStripMenuItem";
            this.从备份中恢复用户配置RToolStripMenuItem.Size = new Size(208, 22);
            this.从备份中恢复用户配置RToolStripMenuItem.Text = "从备份中恢复用户配置(&R)";
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(205, 6);
            this.lSelect.AutoSize = true;
            this.lSelect.Location = new Point(33, 52);
            this.lSelect.Name = "lSelect";
            this.lSelect.Size = new Size(89, 12);
            this.lSelect.TabIndex = 1;
            this.lSelect.Text = "选择一个配置: ";
            this.cbCfg.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCfg.FormattingEnabled = true;
            this.cbCfg.Location = new Point(35, 67);
            this.cbCfg.Name = "cbCfg";
            this.cbCfg.Size = new Size(525, 20);
            this.cbCfg.TabIndex = 2;
            this.cbCfg.SelectedIndexChanged += new EventHandler(this.cbCfg_SelectedIndexChanged);
            this.clbCfg.CheckOnClick = true;
            this.clbCfg.FormattingEnabled = true;
            this.clbCfg.HorizontalScrollbar = true;
            this.clbCfg.Location = new Point(35, 121);
            this.clbCfg.Name = "clbCfg";
            this.clbCfg.ScrollAlwaysVisible = true;
            this.clbCfg.Size = new Size(525, 212);
            this.clbCfg.TabIndex = 3;
            this.lReplace.AutoSize = true;
            this.lReplace.Location = new Point(33, 106);
            this.lReplace.Name = "lReplace";
            this.lReplace.Size = new Size(101, 12);
            this.lReplace.TabIndex = 4;
            this.lReplace.Text = "替换选中的配置: ";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(594, 372);
            base.Controls.Add(this.lReplace);
            base.Controls.Add(this.clbCfg);
            base.Controls.Add(this.cbCfg);
            base.Controls.Add(this.lSelect);
            base.Controls.Add(this.msUIEditor);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MainMenuStrip = this.msUIEditor;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmUIEditor";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "用户界面管理器";
            this.msUIEditor.ResumeLayout(false);
            this.msUIEditor.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LoadCfg(string sPath)
        {
            this.Cursor = Cursors.WaitCursor;
            string[] files = Directory.GetFiles(sPath, "core_char_*.dat");
            this.htCfg = new Hashtable();
            string[] strArrays = files;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (this.regexCfgFile.IsMatch(Path.GetFileName(str)))
                {
                    string str1 = Path.GetFileNameWithoutExtension(str).Substring(10);
                    string characterInfo = EveHttpLogin.GetCharacterInfo(int.Parse(str1));
                    if (!string.IsNullOrEmpty(characterInfo))
                    {
                        this.cbCfg.Items.Add(characterInfo);
                        this.clbCfg.Items.Add(characterInfo);
                        this.htCfg.Add(characterInfo, str);
                        Application.DoEvents();
                    }
                }
            }
            this.Cursor = Cursors.Arrow;
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            if (this.clbCfg.CheckedItems.Count <= 0)
            {
                MessageBox.Show("请至少选择一个要替换的界面配置", "没有任何更改", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.clbCfg.CheckedItems.Count == 1 && this.clbCfg.GetItemCheckState(this.clbCfg.CheckedIndices[0]) == CheckState.Indeterminate)
            {
                MessageBox.Show("请至少选择一个要替换的界面配置", "没有任何更改", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.Cursor = Cursors.WaitCursor;
            stringBuilder.AppendLine("如下配置将被覆盖，操作无法恢复，请认真核对");
            stringBuilder.AppendLine();
            foreach (int checkedIndex in this.clbCfg.CheckedIndices)
            {
                if (this.clbCfg.GetItemCheckState(checkedIndex) == CheckState.Indeterminate)
                {
                    continue;
                }
                stringBuilder.AppendLine(string.Concat(this.cbCfg.SelectedItem.ToString(), " -> ", this.clbCfg.Items[checkedIndex].ToString()));
            }
            if (MessageBox.Show(stringBuilder.ToString(), "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                stringBuilder1.AppendLine("处理结果如下，重新登录游戏生效");
                stringBuilder1.AppendLine();
                foreach (int num in this.clbCfg.CheckedIndices)
                {
                    if (this.clbCfg.GetItemCheckState(num) == CheckState.Indeterminate)
                    {
                        continue;
                    }
                    string str = "成功\t";
                    try
                    {
                        File.Copy((string)this.htCfg[this.cbCfg.SelectedItem.ToString()], (string)this.htCfg[this.clbCfg.Items[num].ToString()], true);
                    }
                    catch (Exception exception)
                    {
                        str = "失败\t";
                    }
                    stringBuilder1.AppendLine(string.Concat(str, this.cbCfg.SelectedItem.ToString(), " -> ", this.clbCfg.Items[num].ToString()));
                }
                MessageBox.Show(stringBuilder1.ToString(), "处理完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void 关闭XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void 用户文档下配置DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CCP\\EVE\\");
            string[] directories = Directory.GetDirectories(str, "*_211.144.214.68", SearchOption.TopDirectoryOnly);
            if ((int)directories.Length > 0)
            {
                this.LoadCfg(Path.Combine(directories[0], "settings\\"));
            }
        }

        private void 游戏目录下配置GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "选择EVE安装目录\r\n例如 C:\\Program Files\\EVE",
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = false
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.csGamePath = Path.Combine(folderBrowserDialog.SelectedPath, "settings");
                if (Directory.Exists(this.csGamePath))
                {
                    this.LoadCfg(this.csGamePath);
                    return;
                }
                MessageBox.Show("没有找到有效的用户配置文件", "载入错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}