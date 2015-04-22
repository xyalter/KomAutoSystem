using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemCenter.Properties;

namespace SystemCenter
{
    partial class frmLauncher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            this.pbTop = new PictureBox();
            this.lOnlinePlayers = new Label();
            this.lbEdit = new Label();
            this.lbSSOToken = new Label();
            this.cbUserName = new ComboBox();
            this.btRun = new Button();
            this.pbLogin = new ProgressBar();
            this.cmMain = new ContextMenuStrip(this.components);
            this.cmRunFrom = new ToolStripMenuItem();
            this.cmLocalSettings = new ToolStripMenuItem();
            this.cmDisableAdvShow = new ToolStripMenuItem();
            this.cmAutoMaxWindow = new ToolStripMenuItem();
            this.启动游戏后关闭登录器CToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator5 = new ToolStripSeparator();
            this.toolStripMenuItemSpl = new ToolStripMenuItem();
            this.禁用DToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.占用内存最小MToolStripMenuItem = new ToolStripMenuItem();
            this.会战模式BToolStripMenuItem = new ToolStripMenuItem();
            this.标准精简模式SToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.cmUserUIConfig = new ToolStripMenuItem();
            this.toolStripSeparator6 = new ToolStripSeparator();
            this.toolStripMenuSkillSpan = new ToolStripMenuItem();
            this.设定计时器SToolStripMenuItem = new ToolStripMenuItem();
            this.清除计时器CToolStripMenuItem = new ToolStripMenuItem();
            this.tspLine2 = new ToolStripSeparator();
            this.cmSubSSOToken = new ToolStripMenuItem();
            this.仅获取SSOTokenToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.导入和导出XToolStripMenuItem = new ToolStripMenuItem();
            this.导出当前账号信息EToolStripMenuItem = new ToolStripMenuItem();
            this.导入账号信息IToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.批量导出账号信息AToolStripMenuItem = new ToolStripMenuItem();
            this.批量导入账号信息BToolStripMenuItem = new ToolStripMenuItem();
            this.恢复和重置RToolStripMenuItem = new ToolStripMenuItem();
            this.恢复全部账号信息RToolStripMenuItem = new ToolStripMenuItem();
            this.cmSubClear = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.快捷方式LToolStripMenuItem = new ToolStripMenuItem();
            this.发送到桌面快捷方式DToolStripMenuItem = new ToolStripMenuItem();
            this.发送批量登录快捷方式到桌面BToolStripMenuItem = new ToolStripMenuItem();
            this.批量登录BToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripSeparator();
            this.cm启动登录器输入密码 = new ToolStripMenuItem();
            this.ilMain = new ImageList(this.components);
            this.tSkillRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.pbTop.SuspendLayout();
            this.cmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEdit
            // 
            this.lbEdit.BackColor = Color.Transparent;
            this.lbEdit.Cursor = Cursors.Hand;
            this.lbEdit.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.lbEdit.ForeColor = Color.White;
            this.lbEdit.Location = new Point(275, 9);
            this.lbEdit.Name = "lbEdit";
            this.lbEdit.Size = new Size(120, 12);
            this.lbEdit.TabIndex = 2;
            this.lbEdit.Text = "添加/删除账户(&C)";
            this.lbEdit.TextAlign = ContentAlignment.MiddleRight;
            this.lbEdit.Click += new EventHandler(this.lbEdit_Click);
            this.lbEdit.MouseDown += new MouseEventHandler(this.lb_MouseDown);
            this.lbEdit.MouseEnter += new EventHandler(this.lb_MouseEnter);
            this.lbEdit.MouseLeave += new EventHandler(this.lb_MouseLeave);
            this.lbEdit.MouseUp += new MouseEventHandler(this.lb_MouseUp);
            // 
            // lbSSOToken
            // 
            this.lbSSOToken.BackColor = Color.Transparent;
            this.lbSSOToken.Cursor = Cursors.Hand;
            this.lbSSOToken.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.lbSSOToken.ForeColor = Color.White;
            this.lbSSOToken.Location = new Point(275, 28);
            this.lbSSOToken.Name = "lbSSOToken";
            this.lbSSOToken.Size = new Size(120, 12);
            this.lbSSOToken.TabIndex = 4;
            this.lbSSOToken.Text = "高级功能(&A)";
            this.lbSSOToken.TextAlign = ContentAlignment.MiddleRight;
            this.lbSSOToken.MouseClick += new MouseEventHandler(this.lbSSOToken_MouseClick);
            this.lbSSOToken.MouseDown += new MouseEventHandler(this.lb_MouseDown);
            this.lbSSOToken.MouseEnter += new EventHandler(this.lb_MouseEnter);
            this.lbSSOToken.MouseLeave += new EventHandler(this.lb_MouseLeave);
            this.lbSSOToken.MouseUp += new MouseEventHandler(this.lb_MouseUp);
            // 
            // cbUserName
            // 
            this.cbUserName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cbUserName.DropDownHeight = 150;
            this.cbUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbUserName.IntegralHeight = false;
            this.cbUserName.Location = new Point(12, 218);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new Size(319, 22);
            this.cbUserName.Sorted = true;
            this.cbUserName.TabIndex = 1;
            this.cbUserName.DrawItem += new DrawItemEventHandler(this.cbUserName_DrawItem);
            this.cbUserName.DropDown += new EventHandler(this.cbUserName_DropDown);
            this.cbUserName.SelectedIndexChanged += new EventHandler(this.cbUserName_SelectedIndexChanged);
            this.cbUserName.DropDownClosed += new EventHandler(this.cbUserName_DropDownClosed);
            // 
            // btRun
            // 
            this.btRun.Location = new Point(337, 218);
            this.btRun.Name = "btRun";
            this.btRun.Size = new Size(75, 22);
            this.btRun.TabIndex = 2;
            this.btRun.Text = "运行(&R)";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new EventHandler(this.btRun_Click);
            // 
            // lOnlinePlayers
            // 
            this.lOnlinePlayers.AutoSize = true;
            this.lOnlinePlayers.BackColor = Color.Transparent;
            this.lOnlinePlayers.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.lOnlinePlayers.ForeColor = Color.Turquoise;
            this.lOnlinePlayers.Location = new Point(10, 9);
            this.lOnlinePlayers.Name = "lOnlinePlayers";
            this.lOnlinePlayers.Size = new Size(71, 12);
            this.lOnlinePlayers.TabIndex = 4;
            this.lOnlinePlayers.Text = "99,999 在线";
            this.lOnlinePlayers.TextAlign = ContentAlignment.MiddleLeft;
            this.lOnlinePlayers.Visible = false;
            // 
            // pbLogin
            // 
            this.pbLogin.Location = new Point(12, 202);
            this.pbLogin.MarqueeAnimationSpeed = 25;
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new Size(400, 10);
            this.pbLogin.Style = ProgressBarStyle.Continuous;
            this.pbLogin.TabIndex = 3;
            //
            // toolStripSeparator5
            //
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new Size(209, 6);
            //
            // 禁用DToolStripMenuItem
            //
            this.禁用DToolStripMenuItem.Checked = true;
            this.禁用DToolStripMenuItem.CheckState = CheckState.Checked;
            this.禁用DToolStripMenuItem.Name = "禁用DToolStripMenuItem";
            this.禁用DToolStripMenuItem.Size = new Size(168, 22);
            this.禁用DToolStripMenuItem.Text = "禁用(&D)";
            this.禁用DToolStripMenuItem.Click += new EventHandler(this.精简启动ToolStripMenuItem_Click);
            //
            // toolStripSeparator2
            //
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(165, 6);
            // 
            // 占用内存最小MToolStripMenuItem
            // 
            this.占用内存最小MToolStripMenuItem.Name = "占用内存最小MToolStripMenuItem";
            this.占用内存最小MToolStripMenuItem.Size = new Size(168, 22);
            this.占用内存最小MToolStripMenuItem.Text = "占用内存最小(&M)";
            this.占用内存最小MToolStripMenuItem.Click += new EventHandler(this.精简启动ToolStripMenuItem_Click);
            // 
            // 会战模式BToolStripMenuItem
            // 
            this.会战模式BToolStripMenuItem.Name = "会战模式BToolStripMenuItem";
            this.会战模式BToolStripMenuItem.Size = new Size(168, 22);
            this.会战模式BToolStripMenuItem.Text = "会战模式(&B)";
            this.会战模式BToolStripMenuItem.Click += new EventHandler(this.精简启动ToolStripMenuItem_Click);
            // 
            // 标准精简模式SToolStripMenuItem
            // 
            this.标准精简模式SToolStripMenuItem.Name = "标准精简模式SToolStripMenuItem";
            this.标准精简模式SToolStripMenuItem.Size = new Size(168, 22);
            this.标准精简模式SToolStripMenuItem.Text = "标准精简模式(&S)";
            this.标准精简模式SToolStripMenuItem.Click += new EventHandler(this.精简启动ToolStripMenuItem_Click);
            //
            // toolStripMenuItemSpl
            //
            this.toolStripMenuItemSpl.Enabled = false;
            this.toolStripMenuItemSpl.Image = Resources.cut;
            this.toolStripMenuItemSpl.Name = "toolStripMenuItemSpl";
            this.toolStripMenuItemSpl.Size = new Size(212, 22);
            this.toolStripMenuItemSpl.Text = "无模型启动(&P)";
            this.toolStripMenuItemSpl.DropDownItems.AddRange(new ToolStripItem[] { this.禁用DToolStripMenuItem, this.toolStripSeparator2, this.占用内存最小MToolStripMenuItem, this.会战模式BToolStripMenuItem, this.标准精简模式SToolStripMenuItem });
            // 
            // cmSubSSOToken
            // 
            this.cmSubSSOToken.Name = "cmSubSSOToken";
            this.cmSubSSOToken.Size = new Size(212, 22);
            this.cmSubSSOToken.Text = "输入SSOToken登录(&S)";
            this.cmSubSSOToken.Visible = false;
            this.cmSubSSOToken.Click += new EventHandler(this.cmSubSSOToken_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(209, 6);
            //
            // cmUserUIConfig
            //
            this.cmUserUIConfig.Name = "cmUserUIConfig";
            this.cmUserUIConfig.Size = new Size(212, 22);
            this.cmUserUIConfig.Text = "界面风格管理器(&U)";
            this.cmUserUIConfig.Click += new EventHandler(this.cmUserUIConfig_Click);
            //
            // toolStripSeparator6
            //
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new Size(209, 6);
            // 
            // 设定计时器SToolStripMenuItem
            // 
            this.设定计时器SToolStripMenuItem.Name = "设定计时器SToolStripMenuItem";
            this.设定计时器SToolStripMenuItem.Size = new Size(152, 22);
            this.设定计时器SToolStripMenuItem.Text = "设定计时器(&S)";
            this.设定计时器SToolStripMenuItem.Click += new EventHandler(this.设定计时器SToolStripMenuItem_Click);
            // 
            // 清除计时器CToolStripMenuItem
            // 
            this.清除计时器CToolStripMenuItem.Name = "清除计时器CToolStripMenuItem";
            this.清除计时器CToolStripMenuItem.Size = new Size(152, 22);
            this.清除计时器CToolStripMenuItem.Text = "清除计时器(C)";
            this.清除计时器CToolStripMenuItem.Click += new EventHandler(this.清除计时器CToolStripMenuItem_Click);
            // 
            // toolStripMenuSkillSpan
            // 
            this.toolStripMenuSkillSpan.Image = Resources.time_clock1;
            this.toolStripMenuSkillSpan.Name = "toolStripMenuSkillSpan";
            this.toolStripMenuSkillSpan.Size = new Size(212, 22);
            this.toolStripMenuSkillSpan.Text = "技能计时器(&T)";
            this.toolStripMenuSkillSpan.DropDownItems.AddRange(new ToolStripItem[] { this.设定计时器SToolStripMenuItem, this.清除计时器CToolStripMenuItem });
            // 
            // tspLine2
            // 
            this.tspLine2.Name = "tspLine2";
            this.tspLine2.Size = new Size(209, 6);
            this.tspLine2.Visible = false;
            // 
            // 仅获取SSOTokenToolStripMenuItem
            // 
            this.仅获取SSOTokenToolStripMenuItem.Name = "仅获取SSOTokenToolStripMenuItem";
            this.仅获取SSOTokenToolStripMenuItem.Size = new Size(212, 22);
            this.仅获取SSOTokenToolStripMenuItem.Text = "仅获取SSOToken(&T)";
            this.仅获取SSOTokenToolStripMenuItem.Visible = false;
            this.仅获取SSOTokenToolStripMenuItem.Click += new EventHandler(this.仅获取SSOTokenToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(209, 6);
            // 
            // 批量导入账号信息BToolStripMenuItem
            // 
            this.批量导入账号信息BToolStripMenuItem.Name = "批量导入账号信息BToolStripMenuItem";
            this.批量导入账号信息BToolStripMenuItem.Size = new Size(188, 22);
            this.批量导入账号信息BToolStripMenuItem.Text = "批量导入账号信息(&B)";
            this.批量导入账号信息BToolStripMenuItem.Click += new EventHandler(this.批量导入账号信息BToolStripMenuItem_Click);
            // 
            // 批量导出账号信息AToolStripMenuItem
            // 
            this.批量导出账号信息AToolStripMenuItem.Name = "批量导出账号信息AToolStripMenuItem";
            this.批量导出账号信息AToolStripMenuItem.Size = new Size(188, 22);
            this.批量导出账号信息AToolStripMenuItem.Text = "批量导出账号信息(&A)";
            this.批量导出账号信息AToolStripMenuItem.Click += new EventHandler(this.批量导出账号信息AToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(185, 6);
            // 
            // 导入账号信息IToolStripMenuItem
            // 
            this.导入账号信息IToolStripMenuItem.Name = "导入账号信息IToolStripMenuItem";
            this.导入账号信息IToolStripMenuItem.Size = new Size(188, 22);
            this.导入账号信息IToolStripMenuItem.Text = "导入账号信息(I)";
            this.导入账号信息IToolStripMenuItem.Click += new EventHandler(this.导入账号信息IToolStripMenuItem_Click);
            // 
            // 导出当前账号信息EToolStripMenuItem
            // 
            this.导出当前账号信息EToolStripMenuItem.Name = "导出当前账号信息EToolStripMenuItem";
            this.导出当前账号信息EToolStripMenuItem.Size = new Size(188, 22);
            this.导出当前账号信息EToolStripMenuItem.Text = "导出账号信息(&E)";
            this.导出当前账号信息EToolStripMenuItem.Click += new EventHandler(this.导出当前账号信息EToolStripMenuItem_Click);
            // 
            // 导入和导出XToolStripMenuItem
            // 
            this.导入和导出XToolStripMenuItem.Image = Resources.save_diskette_floppy_disk;
            this.导入和导出XToolStripMenuItem.Name = "导入和导出XToolStripMenuItem";
            this.导入和导出XToolStripMenuItem.Size = new Size(212, 22);
            this.导入和导出XToolStripMenuItem.Text = "导入和导出(&X)";
            this.导入和导出XToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.导出当前账号信息EToolStripMenuItem, this.导入账号信息IToolStripMenuItem, this.toolStripSeparator4, this.批量导出账号信息AToolStripMenuItem, this.批量导入账号信息BToolStripMenuItem });
            // 
            // 恢复全部账号信息RToolStripMenuItem
            // 
            this.恢复全部账号信息RToolStripMenuItem.Name = "恢复全部账号信息RToolStripMenuItem";
            this.恢复全部账号信息RToolStripMenuItem.Size = new Size(200, 22);
            this.恢复全部账号信息RToolStripMenuItem.Text = "恢复全部账号信息(&R)";
            this.恢复全部账号信息RToolStripMenuItem.Click += new EventHandler(this.恢复全部账号信息RToolStripMenuItem_Click);
            // 
            // cmSubClear
            // 
            this.cmSubClear.Name = "cmSubClear";
            this.cmSubClear.Size = new Size(200, 22);
            this.cmSubClear.Text = "重置账户信息和设置(&C)";
            this.cmSubClear.Click += new EventHandler(this.cmSubClear_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(209, 6);
            // 
            // 恢复和重置RToolStripMenuItem
            // 
            this.恢复和重置RToolStripMenuItem.Name = "恢复和重置RToolStripMenuItem";
            this.恢复和重置RToolStripMenuItem.Size = new Size(212, 22);
            this.恢复和重置RToolStripMenuItem.Text = "恢复和重置(&R)";
            this.恢复和重置RToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.恢复全部账号信息RToolStripMenuItem, this.cmSubClear });
            // 
            // cmRunFrom
            // 
            this.cmRunFrom.Name = "cmRunFrom";
            this.cmRunFrom.Size = new Size(212, 22);
            this.cmRunFrom.Text = "指定游戏路径(&R)";
            this.cmRunFrom.Click += new EventHandler(this.cmRunFrom_Click);
            // 
            // cmLocalSettings
            // 
            this.cmLocalSettings.Name = "cmLocalSettings";
            this.cmLocalSettings.Size = new Size(212, 22);
            this.cmLocalSettings.Text = "使用游戏路径下配置(&L)";
            this.cmLocalSettings.Click += new EventHandler(this.cmLocalSettings_Click);
            // 
            // cmDisableAdvShow
            // 
            this.cmDisableAdvShow.Name = "cmDisableAdvShow";
            this.cmDisableAdvShow.Size = new Size(212, 22);
            this.cmDisableAdvShow.Text = "阻止EVE关闭广告弹窗(A)";
            this.cmDisableAdvShow.Click += new EventHandler(this.cmDisableAdvShow_Click);
            // 
            // cmAutoMaxWindow
            // 
            this.cmAutoMaxWindow.Name = "cmAutoMaxWindow";
            this.cmAutoMaxWindow.Size = new Size(212, 22);
            this.cmAutoMaxWindow.Text = "自动最大化游戏窗口(&M)";
            this.cmAutoMaxWindow.Click += new EventHandler(this.cmAutoMaxWindow_Click);
            // 
            // 启动游戏后关闭登录器CToolStripMenuItem
            // 
            this.启动游戏后关闭登录器CToolStripMenuItem.Name = "启动游戏后关闭登录器CToolStripMenuItem";
            this.启动游戏后关闭登录器CToolStripMenuItem.Size = new Size(212, 22);
            this.启动游戏后关闭登录器CToolStripMenuItem.Text = "启动游戏后关闭登录器(&C)";
            this.启动游戏后关闭登录器CToolStripMenuItem.Click += new EventHandler(this.启动游戏后关闭登录器CToolStripMenuItem_Click);
            // 
            // cmMain
            // 
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new Size(213, 398);
            this.cmMain.Items.AddRange(new ToolStripItem[] { this.cmRunFrom, this.cmLocalSettings, this.cmDisableAdvShow, this.cmAutoMaxWindow, this.启动游戏后关闭登录器CToolStripMenuItem, this.toolStripSeparator5, this.toolStripMenuItemSpl, this.toolStripSeparator1, this.cmUserUIConfig, this.toolStripSeparator6, this.toolStripMenuSkillSpan, this.tspLine2, this.cmSubSSOToken, this.仅获取SSOTokenToolStripMenuItem, this.toolStripSeparator3, this.导入和导出XToolStripMenuItem, this.恢复和重置RToolStripMenuItem, this.toolStripMenuItem1, this.快捷方式LToolStripMenuItem, this.批量登录BToolStripMenuItem, this.toolStripMenuItem2, this.cm启动登录器输入密码 });
            // 
            // 发送批量登录快捷方式到桌面BToolStripMenuItem
            // 
            this.发送批量登录快捷方式到桌面BToolStripMenuItem.Name = "发送批量登录快捷方式到桌面BToolStripMenuItem";
            this.发送批量登录快捷方式到桌面BToolStripMenuItem.Size = new Size(248, 22);
            this.发送批量登录快捷方式到桌面BToolStripMenuItem.Text = "发送批量登录快捷方式到桌面(&B)";
            this.发送批量登录快捷方式到桌面BToolStripMenuItem.Click += new EventHandler(this.发送批量登录快捷方式到桌面BToolStripMenuItem_Click);
            // 
            // 发送到桌面快捷方式DToolStripMenuItem
            // 
            this.发送到桌面快捷方式DToolStripMenuItem.Name = "发送到桌面快捷方式DToolStripMenuItem";
            this.发送到桌面快捷方式DToolStripMenuItem.Size = new Size(248, 22);
            this.发送到桌面快捷方式DToolStripMenuItem.Text = "发送到桌面快捷方式(&D)";
            this.发送到桌面快捷方式DToolStripMenuItem.Click += new EventHandler(this.发送到桌面快捷方式DToolStripMenuItem_Click);
            // 
            // 批量登录BToolStripMenuItem
            // 
            this.批量登录BToolStripMenuItem.Name = "批量登录BToolStripMenuItem";
            this.批量登录BToolStripMenuItem.Size = new Size(212, 22);
            this.批量登录BToolStripMenuItem.Text = "批量登录(&B)";
            this.批量登录BToolStripMenuItem.Click += new EventHandler(this.批量登录BToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(209, 6);
            // 
            // cm启动登录器输入密码
            // 
            this.cm启动登录器输入密码.ForeColor = Color.Maroon;
            this.cm启动登录器输入密码.Name = "cm启动登录器输入密码";
            this.cm启动登录器输入密码.Size = new Size(212, 22);
            this.cm启动登录器输入密码.Text = "启动登录器输入密码(&S)";
            this.cm启动登录器输入密码.Click += new EventHandler(this.cm启动登录器输入密码_Click);
            // 
            // tspLine2
            // 
            this.快捷方式LToolStripMenuItem.Name = "快捷方式LToolStripMenuItem";
            this.快捷方式LToolStripMenuItem.Size = new Size(212, 22);
            this.快捷方式LToolStripMenuItem.Text = "快捷方式(&K)"; 
            this.快捷方式LToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.发送到桌面快捷方式DToolStripMenuItem, this.发送批量登录快捷方式到桌面BToolStripMenuItem });
            this.快捷方式LToolStripMenuItem.Image = (Image)resources.GetObject("快捷方式LToolStripMenuItem.Image");
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = (ImageListStreamer)resources.GetObject("ilMain.ImageStream");
            this.ilMain.TransparentColor = Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "shield.png");
            this.ilMain.Images.SetKeyName(1, "shieldg.png");
            // 
            // tSkillRefresh
            // 
            this.tSkillRefresh.Enabled = true;
            this.tSkillRefresh.Tick += new EventHandler(this.tSkillRefresh_Tick);
            // 
            // pbTop
            // 
            this.pbTop.Controls.Add(this.lOnlinePlayers);
            this.pbTop.Controls.Add(this.lbEdit);
            this.pbTop.Controls.Add(this.lbSSOToken);
            this.pbTop.Image = (Image)resources.GetObject("pbTop.Image");
            this.pbTop.Location = new Point(12, 12);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new Size(400, 200);
            this.pbTop.TabIndex = 0;
            this.pbTop.TabStop = false;
            // 
            // frmLauncher
            // 
            this.AcceptButton = this.btRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.ClientSize = new System.Drawing.Size(424, 250);
            this.Controls.Add(this.pbLogin);
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.pbTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLauncher";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RatEveLanucher";
            this.Shown += new EventHandler(this.frmLauncher_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.pbTop.ResumeLayout(false);
            this.pbTop.PerformLayout();
            this.cmMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbTop;
        private ComboBox cbUserName;
        private Label lbEdit;
        private Button btRun;
        private ProgressBar pbLogin;
        private Label lbSSOToken;
        private ContextMenuStrip cmMain;
        private ToolStripMenuItem cmSubSSOToken;
        private ToolStripMenuItem cmDisableAdvShow;
        private ToolStripSeparator tspLine2;
        private ToolStripMenuItem cmRunFrom;
        private Label lOnlinePlayers;
        private ToolStripMenuItem cmAutoMaxWindow;
        private ToolStripMenuItem cmLocalSettings;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cmUserUIConfig;
        private ToolStripMenuItem 仅获取SSOTokenToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem 导入和导出XToolStripMenuItem;
        private ToolStripMenuItem 导出当前账号信息EToolStripMenuItem;
        private ToolStripMenuItem 导入账号信息IToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem 批量导出账号信息AToolStripMenuItem;
        private ToolStripMenuItem 批量导入账号信息BToolStripMenuItem;
        private ToolStripMenuItem 恢复和重置RToolStripMenuItem;
        private ToolStripMenuItem cmSubClear;
        private ToolStripMenuItem 恢复全部账号信息RToolStripMenuItem;
        private ToolStripMenuItem 启动游戏后关闭登录器CToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ImageList ilMain;
        private ToolStripMenuItem 快捷方式LToolStripMenuItem;
        private ToolStripMenuItem 发送到桌面快捷方式DToolStripMenuItem;
        private ToolStripMenuItem 发送批量登录快捷方式到桌面BToolStripMenuItem;
        private ToolStripMenuItem 批量登录BToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemSpl;
        private ToolStripMenuItem 禁用DToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 占用内存最小MToolStripMenuItem;
        private ToolStripMenuItem 会战模式BToolStripMenuItem;
        private ToolStripMenuItem 标准精简模式SToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolStripMenuSkillSpan;
        private ToolStripMenuItem 设定计时器SToolStripMenuItem;
        private ToolStripMenuItem 清除计时器CToolStripMenuItem;
        private System.Windows.Forms.Timer tSkillRefresh;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem cm启动登录器输入密码;
    }
}
