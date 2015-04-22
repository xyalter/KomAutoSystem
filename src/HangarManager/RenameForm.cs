using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace HangarManager
{
    public partial class RenameForm : DevExpress.XtraEditors.XtraForm
    {
        public string NewName { get { return layoutControl.GetControlByName("name").Text; } }

        public RenameForm()
        {
            InitializeComponent();
        }

        public void InitUi(string oldName)
        {
            //layoutControl.Root.Add(new EmptySpaceItem() { AllowHotTrack = false, Name = "es1" });

            TextEdit name = new TextEdit() { Name = "name", Text = oldName, StyleController = layoutControl };
            layoutControl.Controls.Add(name);
            LayoutControlItem nameItem = new LayoutControlItem() { Control = name, Name = "nameItem", Text = "新名称" };
            layoutControl.Root.Add(nameItem);

            //layoutControl.Root.Add(new EmptySpaceItem() { AllowHotTrack = false, Name = "es2" });

            SimpleButton confirm = new SimpleButton()
            {
                Name = "confirm",
                Text = "确定",
                DialogResult = DialogResult.OK,
                StyleController = layoutControl
            };
            layoutControl.Controls.Add(confirm);
            LayoutControlItem confirmItem = new LayoutControlItem() { Control = confirm, Name = "confirmItem", TextVisible = false };
            layoutControl.Root.Add(confirmItem);

            SimpleButton cancel = new SimpleButton()
            {
                Name = "cancel",
                Text = "取消",
                DialogResult = DialogResult.OK,
                StyleController = layoutControl
            };
            layoutControl.Controls.Add(cancel);
            LayoutControlItem cancelItem = new LayoutControlItem() { Control = cancel, Name = "cancelItem", TextVisible = false };
            layoutControl.Root.Add(cancelItem);

            cancelItem.Move(confirmItem, InsertType.Right);
        }
    }
}