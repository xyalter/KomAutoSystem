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
    public partial class frmEULA : Form
    {

        private EveHttpLogin pLogin;

        public frmEULA()
        {
            InitializeComponent();
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            this.pLogin.AcceptEULA(this.tbEULAHash.Text);
            base.Close();
        }

        public static DialogResult Show(IWin32Window owner, string sTitle, string sBody, string sHash, EveHttpLogin sLogin)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            frmEULA _frmEULA = new frmEULA()
            {
                Text = sTitle
            };
            _frmEULA.tbEULA.Text = sBody;
            _frmEULA.tbEULA.SelectionStart = 0;
            _frmEULA.tbEULA.SelectionLength = 0;
            _frmEULA.btAccept.Focus();
            _frmEULA.tbEULAHash.Text = sHash;
            _frmEULA.pLogin = sLogin;
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = _frmEULA.ShowDialog(owner)));
            return dialogResult;
        }
    }
}
