using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using LibEveFitting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HangarManager
{
    public partial class MainForm
    {
        AppearanceDefault appError = new AppearanceDefault(Color.Red);
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        private NavBarControl navBarControl;
        private GridControl gridControl;
        private BindingSource GoodsSource;
        private BindingSource CheckSource;
        private BindingSource FittingSource;
        private GridView GoodsView;
        private GridView FittingView;

        public void InitUi()
        {
            CheckSource = new BindingSource(this.components) { DataSource = typeof(CheckItem) };
            GoodsSource = new BindingSource(this.components) { DataSource = typeof(Goods) };
            FittingSource = new BindingSource(this.components) { DataSource = typeof(Hardware) };

            ((ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((ISupportInitialize)(this.appMenu)).BeginInit();
            ((ISupportInitialize)(this.Bottom_Pc)).BeginInit();
            this.Bottom_Pc.SuspendLayout();
            ((ISupportInitialize)(this.buttonEdit.Properties)).BeginInit();
            ((ISupportInitialize)(this.Right_Pc)).BeginInit();
            this.Right_Pc.SuspendLayout();
            ((ISupportInitialize)(this.ribbonImageCollection)).BeginInit();
            ((ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            this.SuspendLayout();


            ImageList navbarImageList = new ImageList(components) { TransparentColor = Color.Transparent };
            navbarImageList.Images.Add("Inbox_16x16.png", Image.FromFile("Images/Inbox_16x16.png"));
            navbarImageList.Images.Add("Outbox_16x16.png", Image.FromFile("Images/Outbox_16x16.png"));
            navbarImageList.Images.Add("Drafts_16x16.png", Image.FromFile("Images/Drafts_16x16.png"));
            navbarImageList.Images.Add("Trash_16x16.png", Image.FromFile("Images/Trash_16x16.png"));
            navbarImageList.Images.Add("Calendar_16x16.png", Image.FromFile("Images/Calendar_16x16.png"));
            navbarImageList.Images.Add("Tasks_16x16.png", Image.FromFile("Images/Tasks_16x16.png"));
            ImageList navbarImageListLarge = new ImageList(components) { TransparentColor = Color.Transparent };
            navbarImageListLarge.Images.Add("Mail_16x16.png", Image.FromFile("Images/Mail_16x16.png"));
            navbarImageListLarge.Images.Add("Organizer_16x16.png", Image.FromFile("Images/Organizer_16x16.png"));
            navBarControl = new NavBarControl()
            {
                Name = "navBarControl",
                ActiveGroup = null,
                AllowSelectedLink = true,
                Dock = System.Windows.Forms.DockStyle.Fill,
                SmallImages = navbarImageList,
                LargeImages = navbarImageListLarge,
                MenuManager = ribbonControl,
                PaintStyleKind = NavBarViewKind.ExplorerBar,
                StoreDefaultPaintStyleName = true,
                Text = "navBarControl"
            };
            navBarControl.OptionsNavPane.ExpandedWidth = 165;
            splitContainerControl.Panel1.Controls.Add(navBarControl);
            navBarControl.BeginInit();
            NavBarItem CompareItem = new NavBarItem() { Name = "CompareItem", Caption = "对比" };
            navBarControl.Items.Add(CompareItem);
            NavBarGroup MainGroup = new NavBarGroup() { Name = "MainGroup", Caption = "主功能", Expanded = true };
            MainGroup.ItemLinks.Add(new NavBarItemLink(CompareItem));
            navBarControl.ActiveGroup = MainGroup;
            navBarControl.Groups.Add(MainGroup);
            NavBarGroup TemplateGroup = new NavBarGroup() { Name = "TemplateGroup", Caption = "模板", Expanded = true };
            navBarControl.Groups.Add(TemplateGroup);
            foreach (CheckList tmp in CheckLists)
            {
                AddTemplate(tmp);
            }
            NavBarGroup FittingGroup = new NavBarGroup() { Name = "FittingGroup", Caption = "装配", Expanded = true };
            navBarControl.Groups.Add(FittingGroup);
            foreach (Fitting tmp in Fittings.List)
            {
                AddFitting(tmp);
            }
            navBarControl.SelectedLinkChanged += new NavBarSelectedLinkChangedEventHandler(navBarControl_SelectedLinkChanged);
            navBarControl.EndInit();


            ribbonControl.BeginInit();
            //RibbonGalleryBarItem rgbiSkins = new RibbonGalleryBarItem()
            //{
            //    Id = 60,
            //    Name = "rgbiSkins",
            //    Caption = "皮肤"
            //};
            //rgbiSkins.Gallery.AllowHoverImages = true;
            //rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            //rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            //rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //rgbiSkins.Gallery.ColumnCount = 4;
            //rgbiSkins.Gallery.FixedHoverImageSize = false;
            //rgbiSkins.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            //rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            //rgbiSkins.Gallery.RowCount = 4;
            //ribbonControl.Items.Add(rgbiSkins);
            //RibbonPageGroup skinsRibbonPageGroup = new RibbonPageGroup()
            //{
            //    Name = "skinsRibbonPageGroup",
            //    ShowCaptionButton = false,
            //    Text = "皮肤"
            //};
            //skinsRibbonPageGroup.ItemLinks.Add(rgbiSkins);
            //homeRibbonPage.Groups.Add(skinsRibbonPageGroup);
            //SkinHelper.InitSkinGallery(rgbiSkins, true);
            BarButtonItem iHelp = new BarButtonItem()
            {
                Id = 22,
                Name = "iHelp",
                Caption = "帮助",
                ImageIndex = 7,
                LargeImageIndex = 7
            };
            ribbonControl.Toolbar.ItemLinks.Add(iHelp);
            BarButtonItem iAbout = new BarButtonItem()
            {
                Id = 24,
                Name = "iAbout",
                Caption = "关于",
                ImageIndex = 8,
                LargeImageIndex = 8
            };
            ribbonControl.PageHeaderItemLinks.Add(iAbout);
            ribbonControl.Items.AddRange(new BarItem[] { iHelp, iAbout });
            RibbonPageGroup helpRibbonPageGroup = new RibbonPageGroup()
            {
                Name = "helpRibbonPageGroup",
                Text = "帮助"
            };
            helpRibbonPageGroup.ItemLinks.Add(iHelp);
            helpRibbonPageGroup.ItemLinks.Add(iAbout);
            RibbonPage helpRibbonPage = new RibbonPage() { Name = "helpRibbonPage", Text = "帮助" };
            helpRibbonPage.Groups.Add(helpRibbonPageGroup);
            ribbonControl.Pages.Add(helpRibbonPage);

            BarButtonItem iAdd = new BarButtonItem() { Name = "iAdd", Caption = "添加模板" };
            BarButtonItem iRen = new BarButtonItem() { Name = "iRen", Caption = "重命名模板" };
            BarButtonItem iDel = new BarButtonItem() { Name = "iDel", Caption = "删除模板" };
            iAdd.ItemClick += new ItemClickEventHandler(iAdd_ItemClick);
            iRen.ItemClick += new ItemClickEventHandler(iRen_ItemClick);
            iDel.ItemClick += new ItemClickEventHandler(iDel_ItemClick);
            ribbonControl.Items.AddRange(new BarItem[] { iAdd, iRen, iDel });
            PopupMenu NavMenu = new PopupMenu(this.components) { Name = "NavMenu", Ribbon = ribbonControl };
            NavMenu.BeginInit();
            NavMenu.ItemLinks.AddRange(new BarItem[] { iAdd, iRen, iDel });
            NavMenu.EndInit();
            ribbonControl.SetPopupContextMenu(navBarControl, NavMenu);
            ribbonControl.EndInit();


            gridControl = new GridControl() { Name = "gridControl", Dock = System.Windows.Forms.DockStyle.Fill };
            splitContainerControl.Panel2.Controls.Add(gridControl);
            gridControl.BeginInit();
            GridColumn Name_Gc = new GridColumn() { Name = "Name_Gc", Caption = "名称", FieldName = "Name", VisibleIndex = 1, Visible = true };
            GridColumn Count_Gc = new GridColumn() { Name = "Count_Gc", Caption = "数量", FieldName = "Count", VisibleIndex = 2, Visible = false };
            GridColumn Limit_Gc = new GridColumn() { Name = "Limit_Gc", Caption = "阀值", FieldName = "Limit", VisibleIndex = 3, Visible = false };
            GridColumn Group_Gc = new GridColumn() { Name = "Group_Gc", Caption = "组", FieldName = "Group", VisibleIndex = 4, Visible = false };
            GridColumn Size_Gc = new GridColumn() { Name = "Size_Gc", Caption = "尺寸", FieldName = "Size", VisibleIndex = 5, Visible = false };
            GridColumn Slot_Gc = new GridColumn() { Name = "Slot_Gc", Caption = "槽位", FieldName = "Slot", VisibleIndex = 6, Visible = false };
            GridColumn Volume_Gc = new GridColumn() { Name = "Volume_Gc", Caption = "体积", FieldName = "Volume", VisibleIndex = 7, Visible = false };
            GoodsView = new GridView()
           {
               Name = "GoodsView",
               BorderStyle = BorderStyles.Simple,
               GridControl = gridControl
           };
            GoodsView.Columns.AddRange(new GridColumn[] { Name_Gc, Count_Gc, Limit_Gc, Group_Gc, Size_Gc, Slot_Gc, Volume_Gc });
            GoodsView.OptionsSelection.MultiSelect = true;
            GoodsView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GoodsView.OptionsView.ShowGroupPanel = false;
            GoodsView.RowCellStyle += new RowCellStyleEventHandler(GoodsView_RowCellStyle);
            //GoodsView.ValidateRow += new ValidateRowEventHandler(GoodsView_ValidateRow);
            //GoodsView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(GoodsView_ValidatingEditor);
            gridControl.ViewCollection.Add(GoodsView);
            GridColumn Name2_Gc = new GridColumn() { Name = "Name2_Gc", Caption = "名称", FieldName = "Type", VisibleIndex = 1, Visible = true };
            GridColumn Count2_Gc = new GridColumn() { Name = "Count2_Gc", Caption = "数量", FieldName = "Qty", VisibleIndex = 2, Visible = true };
            GridColumn Limit2_Gc = new GridColumn() { Name = "Limit2_Gc", Caption = "阀值", FieldName = "Limit", VisibleIndex = 3, Visible = true };
            GridColumn Slot2_Gc = new GridColumn() { Name = "Slot2_Gc", Caption = "槽位", FieldName = "Slot", VisibleIndex = 6, Visible = true };
            FittingView = new GridView()
           {
               Name = "FittingView",
               BorderStyle = BorderStyles.Simple,
               GridControl = gridControl
           };
            FittingView.Columns.AddRange(new GridColumn[] { Name2_Gc, Count2_Gc, Limit2_Gc, Slot2_Gc });
            FittingView.OptionsSelection.MultiSelect = true;
            FittingView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            FittingView.OptionsView.ShowGroupPanel = false;
            FittingView.RowCellStyle += new RowCellStyleEventHandler(GoodsView_RowCellStyle);
            gridControl.ViewCollection.Add(FittingView);
            gridControl.MainView = FittingView;
            gridControl.EndInit();



            ((ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((ISupportInitialize)(this.appMenu)).EndInit();
            ((ISupportInitialize)(this.Bottom_Pc)).EndInit();
            this.Bottom_Pc.ResumeLayout(false);
            ((ISupportInitialize)(this.buttonEdit.Properties)).EndInit();
            ((ISupportInitialize)(this.Right_Pc)).EndInit();
            this.Right_Pc.ResumeLayout(false);
            this.Right_Pc.PerformLayout();
            ((ISupportInitialize)(this.ribbonImageCollection)).EndInit();
            ((ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            this.ResumeLayout(false);
        }

        private void AddTemplate(CheckList list)
        {
            navBarControl.BeginInit();
            NavBarItem item = new NavBarItem()
            {
                Name = "Template" + list.Name,
                Caption = list.Name
            };
            navBarControl.Items.Add(item);
            navBarControl.Groups["TemplateGroup"].ItemLinks.Add(new NavBarItemLink(item));
            navBarControl.EndInit();
            TemplateCombo.Items.Add(list.Name);
        }

        private void AddFitting(Fitting fitting)
        {
            navBarControl.BeginInit();
            NavBarItem item = new NavBarItem()
            {
                Name = "Fitting" + fitting.Name,
                Caption = fitting.Name
            };
            navBarControl.Items.Add(item);
            navBarControl.Groups["FittingGroup"].ItemLinks.Add(new NavBarItemLink(item));
            navBarControl.EndInit();
            TemplateCombo.Items.Add(fitting.Name);
        }

        private void iAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckList tmp = new CheckList() { Name = Guid.NewGuid().ToString() };
            CheckLists.Add(tmp);
            AddTemplate(tmp);
        }

        private void iRen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navBarControl.SelectedLink == null)
                return;

            string oldName = navBarControl.SelectedLink.Item.Caption;
            RenameForm form = new RenameForm();
            form.InitUi(oldName);
            System.Windows.Forms.DialogResult edit = form.ShowDialog();
            if (edit != System.Windows.Forms.DialogResult.Cancel)
            {
                CheckLists[oldName].Name = form.NewName;
                TemplateCombo.Items.Remove(oldName);
                TemplateCombo.Items.Add(form.NewName);
                navBarControl.SelectedLink.Item.Caption = form.NewName;
            }
        }

        private void iDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navBarControl.SelectedLink == null)
                return;

            string name = navBarControl.SelectedLink.Item.Caption;
            CheckLists.Remove(CheckLists[name]);
            TemplateCombo.Items.Remove(name);
            navBarControl.Items.Remove(navBarControl.SelectedLink.Item);
        }

        private void navBarControl_SelectedLinkChanged(object sender, NavBarSelectedLinkChangedEventArgs e)
        {
            if (e.Group.Name.Equals("MainGroup"))
            {
                gridControl.MainView = GoodsView;
                gridControl.DataSource = GoodsSource;
                GridView view = (GridView)gridControl.MainView;
                view.Columns["Count"].VisibleIndex = 2;
                view.Columns["Count"].Visible = true;
                view.Columns["Limit"].VisibleIndex = 3;
                view.Columns["Limit"].Visible = true;
            }
            else if (e.Group.Name.Equals("TemplateGroup"))
            {
                gridControl.MainView = GoodsView;
                gridControl.DataSource = CheckSource;
                GridView view = (GridView)gridControl.MainView;
                view.Columns["Count"].Visible = false;
                view.Columns["Limit"].Visible = true;
                string name = e.Link.Caption;
                CheckList tmp = CheckLists[name];
                CheckSource.Clear();
                foreach (CheckItem item in tmp)
                {
                    CheckSource.Add(item);
                }
            }
            else if (e.Group.Name.Equals("FittingGroup"))
            {
                gridControl.MainView = FittingView;
                gridControl.DataSource = FittingSource;
                GridView view = (GridView)gridControl.MainView;
                string name = e.Link.Caption;
                Fitting tmp = Fittings[name];
                FittingSource.Clear();
                gridControl.DataSource = tmp.HardwaresSum;
                foreach (Hardware item in tmp.Hardwares)
                {
                    FittingSource.Add(item);
                }
            }
        }
    }
}
