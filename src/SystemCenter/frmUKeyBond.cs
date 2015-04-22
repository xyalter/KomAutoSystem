using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    public partial class frmUKeyBond : Form
    {
        public frmUKeyBond()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void cbUKeyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lSeq.Text = string.Concat("设备序列号: ", ((USBDiskInfo)this.cbUKeyList.SelectedItem).SerialNumber);
        }

        private void RefreshUKeyList()
        {
            USBDiskInfo[] allUsbDisk = PnPDevice.AllUsbDisk;
            if (allUsbDisk == null)
            {
                this.cbUKeyList.Enabled = false;
                this.btOK.Enabled = false;
                return;
            }
            USBDiskInfo[] uSBDiskInfoArray = allUsbDisk;
            for (int i = 0; i < (int)uSBDiskInfoArray.Length; i++)
            {
                USBDiskInfo uSBDiskInfo = uSBDiskInfoArray[i];
                this.cbUKeyList.Items.Add(uSBDiskInfo);
            }
            this.cbUKeyList.SelectedIndex = 0;
        }

        public static DialogResult Show(string sTitle, string sPrompt, IWin32Window owner, out string sValOut)
        {
            frmUKeyBond _frmUKeyBond = new frmUKeyBond()
            {
                Text = sTitle
            };
            _frmUKeyBond.lText.Text = sPrompt;
            _frmUKeyBond.RefreshUKeyList();
            DialogResult dialogResult = _frmUKeyBond.ShowDialog(owner);
            if (dialogResult != DialogResult.OK)
            {
                sValOut = string.Empty;
            }
            else
            {
                sValOut = ((USBDiskInfo)_frmUKeyBond.cbUKeyList.SelectedItem).SerialNumber;
            }
            return dialogResult;
        }
    }
}
