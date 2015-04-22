using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomTest
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            currentRoles = new List<string>();
            roles = new List<Role>();
        }

        private List<string > currentRoles;
        private List<Role> roles;

        private bool EnumWindowsCallback(IntPtr handle, IntPtr extraParameter)
        {
            int num1 = Class1.GetWindowTextLength(new HandleRef(this, handle)) * 2;
            StringBuilder builder1 = new StringBuilder(num1);
            Class1.GetWindowText(new HandleRef(this, handle), builder1, builder1.Capacity);
            System.Console.WriteLine(string.Format("Wnd:{0} Title: {1}", handle, builder1.ToString()));
            Application.DoEvents();
            if (builder1.ToString().StartsWith("EVE - "))
            {
                String name = builder1.ToString().Replace("EVE - ", "");
                currentRoles.Add(name);
                //listBox1.Items.Add(string.Format("Wnd:{0} Title: {1}", handle, builder1.ToString()));
            }
            // Class1.EnumChildWindows(new HandleRef(this, handle), new EnumChildrenCallback(EnumChildWindowsCallback), new HandleRef(null, IntPtr.Zero));
            return true;
        }

        private bool EnumChildWindowsCallback(IntPtr handle, IntPtr lparam)
        {
            int num1 = Class1.GetWindowTextLength(new HandleRef(this, handle)) * 2;
            StringBuilder builder1 = new StringBuilder(num1);
            Class1.GetWindowText(new HandleRef(this, handle), builder1, builder1.Capacity);
            System.Console.WriteLine(string.Format("/tSubWnd:{0} Title: {1}", handle, builder1.ToString()));
            //listBox1.Items.Add(string.Format("SubWnd:{0} Title: {1}", handle, builder1.ToString()));
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentRoles.Clear();
            EnumThreadWindowsCallback callback1 = new EnumThreadWindowsCallback(this.EnumWindowsCallback);
            Class1.EnumWindows(callback1, IntPtr.Zero);
            foreach (TreeListNode node in treeList.Nodes)
            {
                string name = (string)node.GetValue("Name");
                if (currentRoles.Contains(name))
                {
                    node.SetValue("Status", "在线");
                    currentRoles.Remove(name);
                }
                else
                     node.SetValue("Status", "离线");
                
            }

            foreach (string name in currentRoles)
            {
                treeList.Nodes.Add(new object[] { "", name, "在线" });
            }
        }
    }
}
