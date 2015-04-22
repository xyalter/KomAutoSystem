namespace SystemCenter
{
    partial class MainForm
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
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.MainPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.MainPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.SkillPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.AccountPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.DataPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.AboutPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PathPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.SetSkillButton = new DevExpress.XtraBars.BarButtonItem();
            this.ClearSkillButton = new DevExpress.XtraBars.BarButtonItem();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.MiscPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.AdCheck = new DevExpress.XtraBars.BarCheckItem();
            this.MaximumCheck = new DevExpress.XtraBars.BarCheckItem();
            this.HideCheck = new DevExpress.XtraBars.BarCheckItem();
            this.ImExportPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.SetSkillButton,
            this.ClearSkillButton,
            this.AdCheck,
            this.MaximumCheck,
            this.HideCheck});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 8;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.MainPage,
            this.AccountPage,
            this.DataPage,
            this.AboutPage});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(624, 147);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            // 
            // MainPage
            // 
            this.MainPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.MainPageGroup,
            this.SkillPageGroup,
            this.MiscPageGroup,
            this.PathPageGroup,
            this.ribbonPageGroup3});
            this.MainPage.Name = "MainPage";
            this.MainPage.Text = "开始";
            // 
            // MainPageGroup
            // 
            this.MainPageGroup.Name = "MainPageGroup";
            this.MainPageGroup.Text = "启动器";
            // 
            // SkillPageGroup
            // 
            this.SkillPageGroup.ItemLinks.Add(this.SetSkillButton);
            this.SkillPageGroup.ItemLinks.Add(this.ClearSkillButton);
            this.SkillPageGroup.Name = "SkillPageGroup";
            this.SkillPageGroup.Text = "技能计时器";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // AccountPage
            // 
            this.AccountPage.Name = "AccountPage";
            this.AccountPage.Text = "账号";
            // 
            // DataPage
            // 
            this.DataPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ImExportPageGroup});
            this.DataPage.Name = "DataPage";
            this.DataPage.Text = "数据管理";
            // 
            // AboutPage
            // 
            this.AboutPage.Name = "AboutPage";
            this.AboutPage.Text = "关于";
            // 
            // PathPageGroup
            // 
            this.PathPageGroup.Name = "PathPageGroup";
            this.PathPageGroup.Text = "游戏路径";
            // 
            // SetSkillButton
            // 
            this.SetSkillButton.Caption = "设置技能时间";
            this.SetSkillButton.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.SetSkillButton.Id = 1;
            this.SetSkillButton.Name = "SetSkillButton";
            // 
            // ClearSkillButton
            // 
            this.ClearSkillButton.Caption = "清除技能时间";
            this.ClearSkillButton.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.ClearSkillButton.Id = 3;
            this.ClearSkillButton.Name = "ClearSkillButton";
            // 
            // applicationMenu
            // 
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.ribbonControl;
            // 
            // layoutControl
            // 
            this.layoutControl.Location = new System.Drawing.Point(187, 186);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(226, 163);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl";
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.CustomizationFormText = "layoutControlGroup";
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(226, 163);
            this.layoutControlGroup.Text = "layoutControlGroup";
            this.layoutControlGroup.TextVisible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 411);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(624, 31);
            // 
            // MiscPageGroup
            // 
            this.MiscPageGroup.ItemLinks.Add(this.AdCheck);
            this.MiscPageGroup.ItemLinks.Add(this.MaximumCheck);
            this.MiscPageGroup.ItemLinks.Add(this.HideCheck);
            this.MiscPageGroup.Name = "MiscPageGroup";
            this.MiscPageGroup.Text = "杂项";
            // 
            // AdCheck
            // 
            this.AdCheck.Caption = "阻止关闭广告弹窗";
            this.AdCheck.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.AdCheck.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.AdCheck.Id = 5;
            this.AdCheck.Name = "AdCheck";
            // 
            // MaximumCheck
            // 
            this.MaximumCheck.Caption = "自动最大化EVE窗口";
            this.MaximumCheck.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.MaximumCheck.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.MaximumCheck.Id = 6;
            this.MaximumCheck.Name = "MaximumCheck";
            // 
            // HideCheck
            // 
            this.HideCheck.Caption = "启动EVE后隐藏";
            this.HideCheck.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.HideCheck.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.HideCheck.Id = 7;
            this.HideCheck.Name = "HideCheck";
            // 
            // ImExportPageGroup
            // 
            this.ImExportPageGroup.Name = "ImExportPageGroup";
            this.ImExportPageGroup.Text = "导入导出";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "暗月集团-EV7.0-KAS暗月自动化系统管理中心";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage MainPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup MainPageGroup;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.XtraBars.BarButtonItem SetSkillButton;
        private DevExpress.XtraBars.BarButtonItem ClearSkillButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup SkillPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage AccountPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage DataPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PathPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPage AboutPage;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraBars.BarCheckItem AdCheck;
        private DevExpress.XtraBars.BarCheckItem MaximumCheck;
        private DevExpress.XtraBars.BarCheckItem HideCheck;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup MiscPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ImExportPageGroup;

    }
}

