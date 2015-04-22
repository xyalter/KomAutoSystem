using LibKasCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SystemCenter
{
    public class frmEditor : Form
    {
        private XmlDocumentEx xUserInfo = new XmlDocumentEx();

        private Hashtable htUserInfo = new Hashtable();

        private bool bNeedSave;

        private IContainer components;

        private ListView lvUserInfo;

        private ColumnHeader chUserName;

        private Button btAdd;

        private Button btDel;

        private Button btOk;

        private Button btCancle;

        private Button btChk;

        private Button btAlias;

        private Button btUKeyOn;

        private Button btUKeyOff;

        private ColumnHeader chUKey;

        private Button btChgPassword;

        public frmEditor()
        {
            this.InitializeComponent();
            this.LoadConfig();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            if (frmInputBox.Show("添加账户", "请输入游戏账号", "", false, this, out str) == DialogResult.Cancel || frmInputBox.Show("添加账户", "请输入游戏密码", "", true, this, out str1) == DialogResult.Cancel || frmInputBox.Show("添加账户", "请输入账户别名（可选）", "", false, this, out str2) == DialogResult.Cancel)
            {
                return;
            }
            UserInfo userInfo = new UserInfo(str, str1, str2, string.Empty);
            if (this.htUserInfo.ContainsKey(str))
            {
                if (MessageBox.Show(string.Concat("已经存在用户名为 ", str, " 的账号，是否替换？"), "替换", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                {
                    return;
                }
                this.lvUserInfo.Items[str].Remove();
                this.htUserInfo.Remove(str);
            }
            string[] displayName = new string[] { userInfo.GetDisplayName(), "未绑定" };
            ListViewItem listViewItem = new ListViewItem(displayName)
            {
                Name = str
            };
            this.htUserInfo.Add(str, userInfo);
            this.lvUserInfo.Items.Add(listViewItem);
            this.Text = "RatEveLanucher - 添加/删除账户 *";
            this.bNeedSave = true;
        }

        private void btAlias_Click(object sender, EventArgs e)
        {
            string str;
            if (this.lvUserInfo.SelectedItems.Count != 1)
            {
                return;
            }
            if (frmInputBox.Show("设置别名", string.Concat("请输入账号 ", ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).GetDisplayName(), " 的别名，点击[取消]不做修改"), ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).Alias, false, this, out str) == DialogResult.OK)
            {
                ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).Alias = str;
                this.lvUserInfo.Items[((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UserName].Text = ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).GetDisplayName();
                this.Text = "RatEveLanucher - 添加/删除账户 *";
                this.bNeedSave = true;
            }
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btChgPassword_Click(object sender, EventArgs e)
        {
            string str;
            string str1;
            string str2;
            if (this.lvUserInfo.SelectedItems.Count != 1)
            {
                return;
            }
            UserInfo item = (UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name];
            if (frmInputBox.Show("添加账户", "请输入原密码", "", true, this, out str) == DialogResult.Cancel)
            {
                return;
            }
            if (!item.Password.Equals(str))
            {
                MessageBox.Show("抱歉，原密码不正确！\r\n\r\n请认真回忆账号密码，过于依赖启动器可不行哦", "密码错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            bool flag = false;
            while (!flag)
            {
                if (frmInputBox.Show("添加账户", "请输入新密码", "", true, this, out str1) == DialogResult.Cancel)
                {
                    return;
                }
                if (frmInputBox.Show("添加账户", "请再次输入新密码", "", true, this, out str2) == DialogResult.Cancel)
                {
                    return;
                }
                if (str1.Equals(str2))
                {
                    item.Password = str1;
                    this.bNeedSave = true;
                    this.Text = "RatEveLanucher - 添加/删除账户 *";
                    return;
                }
                MessageBox.Show("两次输入的密码不一致，请重新输入", "密码错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btChk_Click(object sender, EventArgs e)
        {
            string str;
            if (this.lvUserInfo.SelectedItems.Count != 1)
            {
                return;
            }
            if (frmInputBox.Show("验证密码", string.Concat("请输入账号 ", ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).GetDisplayName(), " 的密码，进行验证"), "", true, this, out str) == DialogResult.OK)
            {
                if (((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).Password.Equals(str))
                {
                    MessageBox.Show("恭喜您，密码验证无误！\r\n\r\n建议您每月至少一次验证密码已增强记忆", "正确", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MessageBox.Show("抱歉，密码验证失败！\r\n\r\n请认真回忆账号密码，过于依赖启动器可不行哦", "失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.lvUserInfo.SelectedItems)
            {
                this.htUserInfo.Remove(selectedItem.Name);
                selectedItem.Remove();
                this.Text = "RatEveLanucher - 添加/删除账户 *";
                this.bNeedSave = true;
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            this.SaveConfig();
            this.Text = "RatEveLanucher - 添加/删除账户";
            this.bNeedSave = false;
            base.Close();
        }

        private void btUKeyOff_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            bool flag = false;
            if (frmInputBox.Show("解绑UKey", string.Concat("请插入账号 ", ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).GetDisplayName(), " 绑定的UKey\r\n\r\n或输入档案密钥，点击确定解除UKey绑定"), "", true, 256, true, ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UKey, this, out empty, out flag) == DialogResult.OK)
            {
                if (flag || this.xUserInfo.ValidateKey(empty))
                {
                    ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UKey = string.Empty;
                    this.lvUserInfo.SelectedItems[0].SubItems[1].Text = "未绑定";
                    this.lvUserInfo.SelectedItems[0].ForeColor = Color.Black;
                    this.btUKeyOn.Enabled = string.IsNullOrEmpty(((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UKey);
                    this.btUKeyOff.Enabled = !this.btUKeyOn.Enabled;
                    this.Text = "RatEveLanucher - 添加/删除账户 *";
                    this.bNeedSave = true;
                    return;
                }
                MessageBox.Show(this, "安全档案密钥不正确，不能解除 UKey 绑定！", "解除UKey", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btUKeyOn_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (frmUKeyBond.Show("绑定UKey", string.Concat("将账号 ", ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).GetDisplayName(), " 绑定到如下设备上"), this, out empty) == DialogResult.OK)
            {
                ((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UKey = empty;
                this.lvUserInfo.SelectedItems[0].SubItems[1].Text = "已绑定";
                this.lvUserInfo.SelectedItems[0].ForeColor = this.btUKeyOn.ForeColor;
                this.btUKeyOn.Enabled = string.IsNullOrEmpty(((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UKey);
                this.btUKeyOff.Enabled = !this.btUKeyOn.Enabled;
                this.Text = "RatEveLanucher - 添加/删除账户 *";
                this.bNeedSave = true;
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

        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bNeedSave)
            {
                DialogResult dialogResult = MessageBox.Show(this, "账户信息已经修改，是否保存？", "添加/删除账户", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            {
                                base.DialogResult = DialogResult.OK;
                                this.Text = "RatEveLanucher - 添加/删除账户";
                                this.SaveConfig();
                                this.bNeedSave = false;
                                return;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.lvUserInfo = new ListView();
            this.chUserName = new ColumnHeader();
            this.chUKey = new ColumnHeader();
            this.btAdd = new Button();
            this.btDel = new Button();
            this.btOk = new Button();
            this.btCancle = new Button();
            this.btChk = new Button();
            this.btAlias = new Button();
            this.btUKeyOn = new Button();
            this.btUKeyOff = new Button();
            this.btChgPassword = new Button();
            base.SuspendLayout();
            ListView.ColumnHeaderCollection columns = this.lvUserInfo.Columns;
            ColumnHeader[] columnHeaderArray = new ColumnHeader[] { this.chUserName, this.chUKey };
            columns.AddRange(columnHeaderArray);
            this.lvUserInfo.FullRowSelect = true;
            this.lvUserInfo.GridLines = true;
            this.lvUserInfo.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.lvUserInfo.HideSelection = false;
            this.lvUserInfo.LabelWrap = false;
            this.lvUserInfo.Location = new Point(12, 12);
            this.lvUserInfo.MultiSelect = false;
            this.lvUserInfo.Name = "lvUserInfo";
            this.lvUserInfo.ShowGroups = false;
            this.lvUserInfo.Size = new Size(269, 295);
            this.lvUserInfo.Sorting = SortOrder.Ascending;
            this.lvUserInfo.TabIndex = 0;
            this.lvUserInfo.UseCompatibleStateImageBehavior = false;
            this.lvUserInfo.View = View.Details;
            this.lvUserInfo.SelectedIndexChanged += new EventHandler(this.lvUserInfo_SelectedIndexChanged);
            this.chUserName.Text = "账号";
            this.chUserName.Width = 195;
            this.chUKey.Text = "UKey";
            this.chUKey.Width = 50;
            this.btAdd.Location = new Point(287, 10);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new Size(95, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "新增(&A)";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new EventHandler(this.btAdd_Click);
            this.btDel.Location = new Point(287, 39);
            this.btDel.Name = "btDel";
            this.btDel.Size = new Size(95, 23);
            this.btDel.TabIndex = 2;
            this.btDel.Text = "删除(&D)";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new EventHandler(this.btDel_Click);
            this.btOk.Location = new Point(287, 284);
            this.btOk.Name = "btOk";
            this.btOk.Size = new Size(95, 23);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "确定(&O)";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new EventHandler(this.btOk_Click);
            this.btCancle.DialogResult = DialogResult.Cancel;
            this.btCancle.Location = new Point(287, 255);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new Size(95, 23);
            this.btCancle.TabIndex = 4;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new EventHandler(this.btCancle_Click);
            this.btChk.Location = new Point(287, 68);
            this.btChk.Name = "btChk";
            this.btChk.Size = new Size(95, 23);
            this.btChk.TabIndex = 7;
            this.btChk.Text = "验证(&R)";
            this.btChk.UseVisualStyleBackColor = true;
            this.btChk.Click += new EventHandler(this.btChk_Click);
            this.btAlias.Location = new Point(287, 97);
            this.btAlias.Name = "btAlias";
            this.btAlias.Size = new Size(95, 23);
            this.btAlias.TabIndex = 8;
            this.btAlias.Text = "设置别名(&N)";
            this.btAlias.UseVisualStyleBackColor = true;
            this.btAlias.Click += new EventHandler(this.btAlias_Click);
            this.btUKeyOn.Enabled = false;
            this.btUKeyOn.ForeColor = Color.DarkGreen;
            this.btUKeyOn.Location = new Point(287, 177);
            this.btUKeyOn.Name = "btUKeyOn";
            this.btUKeyOn.Size = new Size(95, 23);
            this.btUKeyOn.TabIndex = 9;
            this.btUKeyOn.Text = "绑定UKey(&B)";
            this.btUKeyOn.UseVisualStyleBackColor = true;
            this.btUKeyOn.Click += new EventHandler(this.btUKeyOn_Click);
            this.btUKeyOff.Enabled = false;
            this.btUKeyOff.ForeColor = Color.Teal;
            this.btUKeyOff.Location = new Point(287, 206);
            this.btUKeyOff.Name = "btUKeyOff";
            this.btUKeyOff.Size = new Size(95, 23);
            this.btUKeyOff.TabIndex = 10;
            this.btUKeyOff.Text = "解绑UKey(&U)";
            this.btUKeyOff.UseVisualStyleBackColor = true;
            this.btUKeyOff.Click += new EventHandler(this.btUKeyOff_Click);
            this.btChgPassword.ForeColor = Color.SaddleBrown;
            this.btChgPassword.Location = new Point(287, 126);
            this.btChgPassword.Name = "btChgPassword";
            this.btChgPassword.Size = new Size(95, 23);
            this.btChgPassword.TabIndex = 11;
            this.btChgPassword.Text = "修改密码(&P)";
            this.btChgPassword.UseVisualStyleBackColor = true;
            this.btChgPassword.Click += new EventHandler(this.btChgPassword_Click);
            base.AcceptButton = this.btOk;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btCancle;
            base.ClientSize = new Size(394, 319);
            base.Controls.Add(this.btChgPassword);
            base.Controls.Add(this.btUKeyOff);
            base.Controls.Add(this.btUKeyOn);
            base.Controls.Add(this.btAlias);
            base.Controls.Add(this.btChk);
            base.Controls.Add(this.btCancle);
            base.Controls.Add(this.btOk);
            base.Controls.Add(this.btDel);
            base.Controls.Add(this.btAdd);
            base.Controls.Add(this.lvUserInfo);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditor";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "RatEveLanucher - 添加/删除账户";
            base.FormClosing += new FormClosingEventHandler(this.frmEditor_FormClosing);
            base.ResumeLayout(false);
        }

        private void LoadConfig()
        {
            this.lvUserInfo.Items.Clear();
            this.htUserInfo.Clear();
            this.xUserInfo.Load("Config.xml");
            foreach (XmlNode xmlNodes in this.xUserInfo.DocumentElement.SelectNodes("User[@UserName][@Password]"))
            {
                string value = xmlNodes.Attributes["UserName"].Value;
                string str = xmlNodes.Attributes["Password"].Value;
                string empty = string.Empty;
                if (xmlNodes.Attributes["Alias"] != null)
                {
                    empty = xmlNodes.Attributes["Alias"].Value;
                }
                string empty1 = string.Empty;
                if (xmlNodes.Attributes["UKey"] != null)
                {
                    empty1 = xmlNodes.Attributes["UKey"].Value;
                }
                string value1 = string.Empty;
                if (xmlNodes.Attributes["SkillDeadLine"] != null)
                {
                    value1 = xmlNodes.Attributes["SkillDeadLine"].Value;
                }
                UserInfo userInfo = new UserInfo(value, str, empty, empty1);
                if (!string.IsNullOrEmpty(value1))
                {
                    userInfo.SkillDeadLine = value1;
                }
                this.htUserInfo.Add(value, userInfo);
                string[] displayNameOnly = new string[] { userInfo.GetDisplayNameOnly(), null };
                displayNameOnly[1] = (string.IsNullOrEmpty(userInfo.UKey) ? "未绑定" : "已绑定");
                ListViewItem listViewItem = new ListViewItem(displayNameOnly)
                {
                    Name = value,
                    ForeColor = (string.IsNullOrEmpty(userInfo.UKey) ? Color.Black : this.btUKeyOn.ForeColor)
                };
                this.lvUserInfo.Items.Add(listViewItem);
            }
        }

        private void lvUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvUserInfo.SelectedItems.Count != 1)
            {
                this.btUKeyOn.Enabled = false;
                this.btUKeyOff.Enabled = false;
                return;
            }
            this.btUKeyOn.Enabled = string.IsNullOrEmpty(((UserInfo)this.htUserInfo[this.lvUserInfo.SelectedItems[0].Name]).UKey);
            this.btUKeyOff.Enabled = !this.btUKeyOn.Enabled;
        }

        private void SaveConfig()
        {
            if (this.xUserInfo != null)
            {
                foreach (XmlNode xmlNodes in this.xUserInfo.DocumentElement.SelectNodes("User"))
                {
                    this.xUserInfo.DocumentElement.RemoveChild(xmlNodes);
                }
                foreach (ListViewItem item in this.lvUserInfo.Items)
                {
                    XmlNode xmlNodes1 = this.xUserInfo.CreateElement("User");
                    UserInfo userInfo = (UserInfo)this.htUserInfo[item.Name];
                    xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("UserName")).Value = userInfo.UserName;
                    xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("Password")).Value = userInfo.Password;
                    xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("Alias")).Value = userInfo.Alias;
                    xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("UKey")).Value = userInfo.UKey;
                    xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("SkillDeadLine")).Value = userInfo.SkillDeadLine;
                    this.xUserInfo.DocumentElement.AppendChild(xmlNodes1);
                }
                this.xUserInfo.Save();
            }
        }
    }

}
