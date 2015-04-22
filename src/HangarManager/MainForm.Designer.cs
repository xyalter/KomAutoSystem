using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
namespace HangarManager
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
            SaveCheckLists();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.appMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.Bottom_Pc = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.iPaste = new DevExpress.XtraBars.BarButtonItem();
            this.Right_Pc = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.someLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.someLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.Status_Bsi = new DevExpress.XtraBars.BarStaticItem();
            this.iTemplate = new DevExpress.XtraBars.BarEditItem();
            this.TemplateCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.iSave = new DevExpress.XtraBars.BarButtonItem();
            this.iCompare = new DevExpress.XtraBars.BarButtonItem();
            this.iClear = new DevExpress.XtraBars.BarButtonItem();
            this.iRatio = new DevExpress.XtraBars.BarEditItem();
            this.RatioTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.homeRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dataRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bottom_Pc)).BeginInit();
            this.Bottom_Pc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Right_Pc)).BeginInit();
            this.Right_Pc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatioTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 147);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Padding = new System.Windows.Forms.Padding(6);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(924, 358);
            this.splitContainerControl.SplitterPosition = 165;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl";
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.appMenu;
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Images = this.ribbonImageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.iPaste,
            this.Status_Bsi,
            this.iTemplate,
            this.iSave,
            this.iCompare,
            this.iClear,
            this.iRatio});
            this.ribbonControl.LargeImages = this.ribbonImageCollectionLarge;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 80;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.homeRibbonPage});
            this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TemplateCombo,
            this.RatioTextEdit,
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(924, 147);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iPaste);
            // 
            // appMenu
            // 
            this.appMenu.BottomPaneControlContainer = this.Bottom_Pc;
            this.appMenu.ItemLinks.Add(this.iPaste);
            this.appMenu.Name = "appMenu";
            this.appMenu.Ribbon = this.ribbonControl;
            this.appMenu.RightPaneControlContainer = this.Right_Pc;
            this.appMenu.ShowRightPane = true;
            // 
            // Bottom_Pc
            // 
            this.Bottom_Pc.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Bottom_Pc.Appearance.Options.UseBackColor = true;
            this.Bottom_Pc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Bottom_Pc.Controls.Add(this.buttonEdit);
            this.Bottom_Pc.Location = new System.Drawing.Point(238, 289);
            this.Bottom_Pc.Name = "Bottom_Pc";
            this.Bottom_Pc.Ribbon = this.ribbonControl;
            this.Bottom_Pc.Size = new System.Drawing.Size(118, 28);
            this.Bottom_Pc.TabIndex = 3;
            this.Bottom_Pc.Visible = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.EditValue = "Some Text";
            this.buttonEdit.Location = new System.Drawing.Point(3, 5);
            this.buttonEdit.MenuManager = this.ribbonControl;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit.Size = new System.Drawing.Size(100, 20);
            this.buttonEdit.TabIndex = 0;
            // 
            // iPaste
            // 
            this.iPaste.Caption = "粘贴";
            this.iPaste.Id = 1;
            this.iPaste.ImageIndex = 4;
            this.iPaste.LargeImageIndex = 4;
            this.iPaste.Name = "iPaste";
            this.iPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iPaste_ItemClick);
            // 
            // Right_Pc
            // 
            this.Right_Pc.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Right_Pc.Appearance.Options.UseBackColor = true;
            this.Right_Pc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Right_Pc.Controls.Add(this.someLabelControl2);
            this.Right_Pc.Controls.Add(this.someLabelControl1);
            this.Right_Pc.Location = new System.Drawing.Point(111, 197);
            this.Right_Pc.Name = "Right_Pc";
            this.Right_Pc.Ribbon = this.ribbonControl;
            this.Right_Pc.Size = new System.Drawing.Size(76, 70);
            this.Right_Pc.TabIndex = 2;
            this.Right_Pc.Visible = false;
            // 
            // someLabelControl2
            // 
            this.someLabelControl2.Location = new System.Drawing.Point(3, 57);
            this.someLabelControl2.Name = "someLabelControl2";
            this.someLabelControl2.Size = new System.Drawing.Size(57, 14);
            this.someLabelControl2.TabIndex = 0;
            this.someLabelControl2.Text = "Some Info";
            // 
            // someLabelControl1
            // 
            this.someLabelControl1.Location = new System.Drawing.Point(3, 3);
            this.someLabelControl1.Name = "someLabelControl1";
            this.someLabelControl1.Size = new System.Drawing.Size(57, 14);
            this.someLabelControl1.TabIndex = 0;
            this.someLabelControl1.Text = "Some Info";
            // 
            // ribbonImageCollection
            // 
            this.ribbonImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollection.ImageStream")));
            this.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png");
            // 
            // Status_Bsi
            // 
            this.Status_Bsi.Caption = "就绪";
            this.Status_Bsi.Id = 31;
            this.Status_Bsi.Name = "Status_Bsi";
            this.Status_Bsi.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // iTemplate
            // 
            this.iTemplate.Caption = "模板选择";
            this.iTemplate.Edit = this.TemplateCombo;
            this.iTemplate.Id = 67;
            this.iTemplate.Name = "iTemplate";
            this.iTemplate.Width = 100;
            // 
            // TemplateCombo
            // 
            this.TemplateCombo.AutoHeight = false;
            this.TemplateCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TemplateCombo.Name = "TemplateCombo";
            // 
            // iSave
            // 
            this.iSave.Caption = "保存";
            this.iSave.Id = 68;
            this.iSave.ImageIndex = 4;
            this.iSave.LargeImageIndex = 4;
            this.iSave.Name = "iSave";
            this.iSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSave_ItemClick);
            // 
            // iCompare
            // 
            this.iCompare.Caption = "比较";
            this.iCompare.Id = 69;
            this.iCompare.ImageIndex = 3;
            this.iCompare.LargeImageIndex = 3;
            this.iCompare.Name = "iCompare";
            this.iCompare.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCompare_ItemClick);
            // 
            // iClear
            // 
            this.iClear.Caption = "清空";
            this.iClear.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iClear.Id = 70;
            this.iClear.ImageIndex = 6;
            this.iClear.LargeImageIndex = 6;
            this.iClear.Name = "iClear";
            this.iClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iClear_ItemClick);
            // 
            // iRatio
            // 
            this.iRatio.Caption = "倍率调整";
            this.iRatio.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iRatio.Edit = this.RatioTextEdit;
            this.iRatio.EditValue = 1;
            this.iRatio.Id = 71;
            this.iRatio.Name = "iRatio";
            // 
            // RatioTextEdit
            // 
            this.RatioTextEdit.AutoHeight = false;
            this.RatioTextEdit.Name = "RatioTextEdit";
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png");
            // 
            // homeRibbonPage
            // 
            this.homeRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.dataRibbonPageGroup,
            this.ribbonPageGroup1});
            this.homeRibbonPage.Name = "homeRibbonPage";
            this.homeRibbonPage.Text = "主菜单";
            // 
            // dataRibbonPageGroup
            // 
            this.dataRibbonPageGroup.ItemLinks.Add(this.iPaste);
            this.dataRibbonPageGroup.ItemLinks.Add(this.iSave);
            this.dataRibbonPageGroup.ItemLinks.Add(this.iTemplate);
            this.dataRibbonPageGroup.ItemLinks.Add(this.iRatio);
            this.dataRibbonPageGroup.ItemLinks.Add(this.iCompare);
            this.dataRibbonPageGroup.ItemLinks.Add(this.iClear);
            this.dataRibbonPageGroup.Name = "dataRibbonPageGroup";
            this.dataRibbonPageGroup.Text = "数据";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.Status_Bsi);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 505);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(924, 31);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.InitialImage = ((System.Drawing.Image)(resources.GetObject("repositoryItemPictureEdit1.InitialImage")));
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(349, 51);
            this.pictureEdit1.MenuManager = this.ribbonControl;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(141, 96);
            this.pictureEdit1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 536);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.Right_Pc);
            this.Controls.Add(this.Bottom_Pc);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "暗月集团-EV3.0自动机库管理";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bottom_Pc)).EndInit();
            this.Bottom_Pc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Right_Pc)).EndInit();
            this.Right_Pc.ResumeLayout(false);
            this.Right_Pc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatioTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem iPaste;
        private DevExpress.XtraBars.BarStaticItem Status_Bsi;
        private DevExpress.XtraBars.Ribbon.RibbonPage homeRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup dataRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu appMenu;
        private DevExpress.XtraBars.PopupControlContainer Right_Pc;
        private DevExpress.XtraEditors.LabelControl someLabelControl2;
        private DevExpress.XtraEditors.LabelControl someLabelControl1;
        private DevExpress.XtraBars.PopupControlContainer Bottom_Pc;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Utils.ImageCollection ribbonImageCollection;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        private DevExpress.XtraBars.BarEditItem iTemplate;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox TemplateCombo;
        private DevExpress.XtraBars.BarButtonItem iSave;
        private DevExpress.XtraBars.BarButtonItem iCompare;
        private DevExpress.XtraBars.BarButtonItem iClear;
        private DevExpress.XtraBars.BarEditItem iRatio;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RatioTextEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
