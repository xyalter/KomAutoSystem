using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using LibEveFitting;


namespace HangarManager
{
    public partial class MainForm : RibbonForm
    {
        public CheckLists CheckLists { get; set; }
        public Fittings Fittings { get; set; }

        private void LoadCheckLists()
        {
            DirectoryInfo di = new DirectoryInfo("Data");
            if (!di.Exists)
                di.Create();
            CheckLists = new CheckLists();
            Fittings = new Fittings();
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.Name.Equals("CheckLists.xml"))
                    continue;
                if (fi.Extension.Contains("xml"))
                    Fittings.Merge(fi.FullName);
                else if (fi.Extension.Contains("tml"))
                    using (FileStream fs = fi.OpenRead())
                    {
                        CheckList list=  (CheckList)new XmlSerializer(typeof(CheckList)).Deserialize(fs);
                        CheckLists.Add(list);
                    }
            }
            //using (FileStream fs = new FileInfo("Data\\CheckLists.xml").OpenRead())
            //{
            //    CheckLists = (CheckLists)new XmlSerializer(typeof(CheckLists)).Deserialize(fs);
            //}
            //CheckLists = new CheckLists();
        }

        private void SaveCheckLists()
        {
            foreach (CheckList list in CheckLists)
            {
                FileInfo fi = new FileInfo("Data\\" + list.Name + ".tml");
                if (fi.Exists)
                    fi.Delete();
                using (FileStream fs = fi.Create())
                {
                    new XmlSerializer(typeof(CheckList)).Serialize(fs, list);
                    fs.Flush();
                }
            }
            //using (FileStream fs = new FileInfo("Data\\CheckLists.xml").Create())
            //{
            //    new XmlSerializer(typeof(CheckLists)).Serialize(fs, CheckLists);
            //    fs.Flush();
            //}
        }

        public MainForm()
        {
            InitializeComponent();
            LoadCheckLists();
            InitUi();
            new AboutBox().Show();
        }

        private void iPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navBarControl.SelectedLink == null)
                return;
            IDataObject data = Clipboard.GetDataObject();
            if (navBarControl.SelectedLink.Group.Name.Equals("MainGroup"))
            {
                GoodsSource.Clear();
                string tmp = (string)data.GetData(typeof(string));
                tmp = tmp.Replace("\n", "");
                string[] rows = tmp.Split(new string[] { "m3" }, StringSplitOptions.RemoveEmptyEntries);
                List<Goods> list = new List<Goods>();
                foreach (Goods goods in GoodsSource)
                    if (list.Exists(x => x.Name.Equals(goods.Name)))
                        if (goods.Count != 0)
                            list.Find(x => x.Name.Equals(goods.Name)).Count += goods.Count;
                        else break;
                    else
                        list.Add(goods);
                foreach (string str in rows)
                {
                    Goods goods = new Goods(str.Split(new string[] { "\t" }, StringSplitOptions.None));
                    if (list.Exists(x => x.Name.Equals(goods.Name)))
                        if (goods.Count != 0)
                            list.Find(x => x.Name.Equals(goods.Name)).Count += goods.Count;
                        else break;
                    else
                        list.Add(goods);
                }
                GoodsSource.Clear();
                foreach (Goods goods in list)
                    GoodsSource.Add(goods);
            }
            else
            {
                CheckSource.Clear();
                IList<CheckItem> list = Parser.GetCheckItems((string)data.GetData(typeof(string)));
                foreach (CheckItem tmp in list)
                    CheckSource.Add(tmp);
            }
            MessageBox.Show("粘贴成功");
        }

        private void iSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navBarControl.SelectedLink == null)
                return;
            if (navBarControl.SelectedLink.Group.Name.Equals("MainGroup"))
                return;
            if (navBarControl.SelectedLink.Group.Name.Equals("FittingGroup"))
                return;

            string name = navBarControl.SelectedLink.Caption;
            CheckList list = CheckLists[name];
            list.Clear();
            foreach (CheckItem tmp in CheckSource)
            {
                list.Add(tmp);
            }
        }

        private void iCompare_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navBarControl.SelectedLink == null)
                return;
            if (!navBarControl.SelectedLink.Group.Name.Equals("MainGroup"))
                return;
            CheckList list = CheckLists[(string)iTemplate.EditValue];
            if (list == null)
                return;

            GridView view = (GridView)gridControl.MainView;
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < view.RowCount - 1; i++)
            {
                map.Add((string)view.GetRowCellValue(i, "Name"), i);
            }
            foreach (CheckItem item in list)
            {
                if (!map.ContainsKey(item.Name))
                    GoodsSource.Add(new Goods() { Name = item.Name, Count = 0 });
            }
            view.RefreshData();
            map.Clear();
            for (int i = 0; i < view.RowCount - 1; i++)
            {
                map.Add((string)view.GetRowCellValue(i, "Name"), i);
            }
            foreach (CheckItem item in list)
            {
                int num = 0;
                map.TryGetValue(item.Name, out num);
                view.SetRowCellValue(num, "Limit", item.Limit * Convert.ToInt32(iRatio.EditValue));
                //int count = (int)view.GetRowCellValue(num, "Count");
                //if (count < item.Limit)
                //    AppearanceHelper.Apply(view.GetRow(), appError);
            }
        }

        private void GoodsView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            if (!e.Column.FieldName.Equals("Count"))
                return;
            GridView view = (GridView)gridControl.MainView;
            int count = (int)view.GetRowCellValue(e.RowHandle, "Count");
            int limit = (int)view.GetRowCellValue(e.RowHandle, "Limit");
            if (count < limit)
                AppearanceHelper.Apply(e.Appearance, appError);
        }

        private void iClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            GoodsSource.Clear();
            gridControl.MainView.RefreshData();
        }
    }
}