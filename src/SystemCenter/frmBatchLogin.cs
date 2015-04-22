using LibKasCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCenter
{
    public class frmBatchLogin : Form
    {
        private const int MAX_THREADS = 5;

        private const int MAX_LOGIN_TIMES = 5;

        private Hashtable htUserInfo = new Hashtable();

        private ArrayList alThreadPool = new ArrayList();

        private BackgroundWorker bgwManager = new BackgroundWorker();

        private string sExeFilePath;

        private string sExeParam;

        private bool bMaxWindows;

        private IContainer components;

        private Button btBatchDo;

        private Button btClose;

        private ListView lvBatch;

        private ColumnHeader chUserName;

        private ProgressBar pbLogin;

        private ColumnHeader chStatus;

        private LoadingCircle lcMain;

        public frmBatchLogin()
        {
            this.InitializeComponent();
            this.bgwManager.DoWork += new DoWorkEventHandler(this.bgwManager_DoWork);
            this.bgwManager.ProgressChanged += new ProgressChangedEventHandler(this.bgwManager_ProgressChanged);
            this.bgwManager.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwManager_RunWorkerCompleted);
            this.bgwManager.WorkerReportsProgress = true;
            this.bgwManager.WorkerSupportsCancellation = true;
        }

        private void bgwManager_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList argument = (ArrayList)e.Argument;
            while (argument.Count > 0 || this.alThreadPool.Count > 0)
            {
                if (this.bgwManager.CancellationPending)
                {
                    for (int i = 0; i < this.alThreadPool.Count; i++)
                    {
                        ((BackgroundWorker)this.alThreadPool[i]).CancelAsync();
                    }
                    return;
                }
                if (this.alThreadPool.Count >= 5 || argument.Count <= 0)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    BackgroundWorker backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += new DoWorkEventHandler(this.bgwSlave_DoWork);
                    backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwSlave_RunWorkerCompleted);
                    backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgwSlave_ProgressChanged);
                    backgroundWorker.WorkerReportsProgress = true;
                    backgroundWorker.WorkerSupportsCancellation = true;
                    lock (this.alThreadPool)
                    {
                        this.alThreadPool.Add(backgroundWorker);
                    }
                    backgroundWorker.RunWorkerAsync(this.htUserInfo[argument[0]]);
                    argument.RemoveAt(0);
                }
            }
        }

        private void bgwManager_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void bgwManager_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btBatchDo.Enabled = true;
            this.lcMain.Active = false;
            Application.DoEvents();
            Thread.Sleep(500);
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void bgwSlave_DoWork(object sender, DoWorkEventArgs e)
        {
            string str;
            string str1;
            UserInfo argument = (UserInfo)e.Argument;
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            string[] userName = new string[] { argument.UserName, "登录中..." };
            backgroundWorker.ReportProgress(0, userName);
            EveHttpLogin eveHttpLogin = new EveHttpLogin(argument.UserName, argument.Password);
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            int num = 0;
            if (!string.IsNullOrEmpty(argument.UKey))
            {
                BackgroundWorker backgroundWorker1 = (BackgroundWorker)sender;
                string[] strArrays = new string[] { argument.UserName, "令牌账号无法批量登录" };
                backgroundWorker1.ReportProgress(-1, strArrays);
                return;
            }
            do
            {
                if (((BackgroundWorker)sender).CancellationPending)
                {
                    return;
                }
                if (num > 0)
                {
                    BackgroundWorker backgroundWorker2 = (BackgroundWorker)sender;
                    string[] userName1 = new string[] { argument.UserName, string.Concat("重试(第 ", num.ToString(), " 次)...") };
                    backgroundWorker2.ReportProgress(-1, userName1);
                }
                if (eveHttpLogin.IsNeedCaptcha())
                {
                    BackgroundWorker backgroundWorker3 = (BackgroundWorker)sender;
                    string[] strArrays1 = new string[] { argument.UserName, "需要输入验证码..." };
                    backgroundWorker3.ReportProgress(1, strArrays1);
                    if (frmCaptcha.Show(this, out str1, out str) != DialogResult.OK)
                    {
                        BackgroundWorker backgroundWorker4 = (BackgroundWorker)sender;
                        string[] userName2 = new string[] { argument.UserName, "用户放弃登录" };
                        backgroundWorker4.ReportProgress(-1, userName2);
                        return;
                    }
                    eveHttpLogin.CaptchaToken = str1;
                    eveHttpLogin.Captcha = str;
                }
                num++;
            }
            while (!eveHttpLogin.Login(out empty2, out empty, out empty1) && num <= 5);
            if (!string.IsNullOrEmpty(empty2))
            {
                BackgroundWorker backgroundWorker5 = (BackgroundWorker)sender;
                string[] strArrays2 = new string[] { argument.UserName, "启动游戏..." };
                backgroundWorker5.ReportProgress(3, strArrays2);
                Process process = null;
                int num1 = 0;
                while (process == null)
                {
                    if (((BackgroundWorker)sender).CancellationPending)
                    {
                        return;
                    }
                    process = new Process()
                    {
                        StartInfo = new ProcessStartInfo(this.sExeFilePath)
                        {
                            Arguments = string.Concat(this.sExeParam, empty2)
                        }
                    };
                    try
                    {
                        process.Start();
                        int num2 = 0;
                        while (num2 < 60000)
                        {
                            if (!((BackgroundWorker)sender).CancellationPending)
                            {
                                process.Refresh();
                                if (string.IsNullOrEmpty(process.MainWindowTitle))
                                {
                                    num2 = num2 + 100;
                                    Thread.Sleep(100);
                                }
                                else
                                {
                                    if (this.bMaxWindows)
                                    {
                                        frmBatchLogin.ShowWindow((int)process.MainWindowHandle, 3);
                                    }
                                    BackgroundWorker backgroundWorker6 = (BackgroundWorker)sender;
                                    string[] userName3 = new string[] { argument.UserName, "已登录" };
                                    backgroundWorker6.ReportProgress(4, userName3);
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        num1++;
                        if (num1 <= 5)
                        {
                            process.Kill();
                            process = null;
                        }
                        else
                        {
                            process.Kill();
                            BackgroundWorker backgroundWorker7 = (BackgroundWorker)sender;
                            string[] strArrays3 = new string[] { argument.UserName, "登录失败(达到最大重试次数)" };
                            backgroundWorker7.ReportProgress(-1, strArrays3);
                            break;
                        }
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        BackgroundWorker backgroundWorker8 = (BackgroundWorker)sender;
                        string[] userName4 = new string[] { argument.UserName, exception.Message };
                        backgroundWorker8.ReportProgress(-1, userName4);
                        break;
                    }
                }
            }
            else
            {
                BackgroundWorker backgroundWorker9 = (BackgroundWorker)sender;
                string[] strArrays4 = new string[] { argument.UserName, "登录失败" };
                backgroundWorker9.ReportProgress(-1, strArrays4);
                if (empty.Equals("授权协议更新"))
                {
                    string[] strArrays5 = empty1.Split(new char[] { '|' });
                    frmEULA.Show(this, empty, strArrays5[1], strArrays5[0], eveHttpLogin);
                    BackgroundWorker backgroundWorker10 = (BackgroundWorker)sender;
                    string[] userName5 = new string[] { argument.UserName, "游戏协议变更，同意后重新登录" };
                    backgroundWorker10.ReportProgress(2, userName5);
                    return;
                }
            }
        }

        private void bgwSlave_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                base.Invoke(new MethodInvoker(() =>
                {
                    string[] userState = (string[])e.UserState;
                    string str = userState[0];
                    switch (e.ProgressPercentage)
                    {
                        case -1:
                        case 0:
                        case 1:
                        case 2:
                        case 4:
                            {
                                this.lvBatch.Items[str].SubItems[1].Text = userState[1];
                                return;
                            }
                        case 3:
                            {
                                ProgressBar u003cu003e4_this = this.pbLogin;
                                u003cu003e4_this.Value = u003cu003e4_this.Value + 1;
                                this.lvBatch.Items[str].SubItems[1].Text = userState[1];
                                return;
                            }
                        default:
                            {
                                this.lvBatch.Items[str].SubItems[1].Text = userState[1];
                                return;
                            }
                    }
                }));
            }
            catch (Exception exception)
            {
            }
        }

        private void bgwSlave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lock (this.alThreadPool)
            {
                this.alThreadPool.Remove(sender);
            }
        }

        private void btBatchDo_Click(object sender, EventArgs e)
        {
            this.lcMain.Active = true;
            this.lvBatch.Sorting = SortOrder.None;
            this.pbLogin.Style = ProgressBarStyle.Continuous;
            this.lcMain.Visible = true;
            ArrayList arrayLists = new ArrayList();
            foreach (ListViewItem item in this.lvBatch.Items)
            {
                if (item.Checked)
                {
                    arrayLists.Add(item.Name);
                }
                else
                {
                    item.Remove();
                }
            }
            this.btBatchDo.Enabled = false;
            if (arrayLists.Count <= 0)
            {
                this.btBatchDo.Enabled = true;
                return;
            }
            this.pbLogin.Maximum = arrayLists.Count;
            this.pbLogin.Value = 0;
            this.bgwManager.RunWorkerAsync(arrayLists);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.btClose.Enabled = false;
            this.bgwManager.CancelAsync();
            while (this.alThreadPool.Count > 0)
            {
                Thread.Sleep(50);
                Application.DoEvents();
            }
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btDebug_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btBatchDo = new Button();
            this.btClose = new Button();
            this.lvBatch = new ListView();
            this.chUserName = new ColumnHeader();
            this.chStatus = new ColumnHeader();
            this.pbLogin = new ProgressBar();
            this.lcMain = new LoadingCircle();
            base.SuspendLayout();
            this.btBatchDo.Enabled = false;
            this.btBatchDo.ForeColor = Color.DarkGreen;
            this.btBatchDo.Location = new Point(238, 170);
            this.btBatchDo.Name = "btBatchDo";
            this.btBatchDo.Size = new Size(100, 23);
            this.btBatchDo.TabIndex = 1;
            this.btBatchDo.Text = "批量启动(&B)";
            this.btBatchDo.UseVisualStyleBackColor = true;
            this.btBatchDo.Click += new EventHandler(this.btBatchDo_Click);
            this.btClose.DialogResult = DialogResult.Cancel;
            this.btClose.Location = new Point(12, 170);
            this.btClose.Name = "btClose";
            this.btClose.Size = new Size(100, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "关闭(&C)";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new EventHandler(this.btClose_Click);
            this.lvBatch.CheckBoxes = true;
            ListView.ColumnHeaderCollection columns = this.lvBatch.Columns;
            ColumnHeader[] columnHeaderArray = new ColumnHeader[] { this.chUserName, this.chStatus };
            columns.AddRange(columnHeaderArray);
            this.lvBatch.FullRowSelect = true;
            this.lvBatch.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.lvBatch.Location = new Point(12, 12);
            this.lvBatch.Name = "lvBatch";
            this.lvBatch.ShowGroups = false;
            this.lvBatch.Size = new Size(326, 139);
            this.lvBatch.Sorting = SortOrder.Ascending;
            this.lvBatch.TabIndex = 3;
            this.lvBatch.UseCompatibleStateImageBehavior = false;
            this.lvBatch.View = View.Details;
            this.lvBatch.ColumnWidthChanging += new ColumnWidthChangingEventHandler(this.lvBatch_ColumnWidthChanging);
            this.lvBatch.ItemChecked += new ItemCheckedEventHandler(this.lvBatch_ItemChecked);
            this.chUserName.Text = "账号";
            this.chUserName.Width = 150;
            this.chStatus.Text = "状态";
            this.chStatus.Width = 150;
            this.pbLogin.Location = new Point(12, 153);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new Size(326, 11);
            this.pbLogin.TabIndex = 4;
            this.lcMain.Active = false;
            this.lcMain.Color = Color.SteelBlue;
            this.lcMain.InnerCircleRadius = 5;
            this.lcMain.Location = new Point(118, 170);
            this.lcMain.Name = "lcMain";
            this.lcMain.NumberSpoke = 12;
            this.lcMain.OuterCircleRadius = 11;
            this.lcMain.RotationSpeed = 100;
            this.lcMain.Size = new Size(114, 23);
            this.lcMain.SpokeThickness = 2;
            this.lcMain.StylePreset = LoadingCircle.StylePresets.MacOSX;
            this.lcMain.TabIndex = 5;
            this.lcMain.Text = "loadingCircle1";
            this.lcMain.Visible = false;
            base.AcceptButton = this.btBatchDo;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btClose;
            base.ClientSize = new Size(350, 205);
            base.Controls.Add(this.lcMain);
            base.Controls.Add(this.pbLogin);
            base.Controls.Add(this.lvBatch);
            base.Controls.Add(this.btClose);
            base.Controls.Add(this.btBatchDo);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmBatchLogin";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "批量启动";
            base.ResumeLayout(false);
        }

        private void lvBatch_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = this.lvBatch.Columns[e.ColumnIndex].Width;
        }

        private void lvBatch_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.btBatchDo.Enabled = this.lvBatch.CheckedItems.Count > 0;
        }

        public static DialogResult Show(Hashtable pUserInfo, string exePath, string exeParam, bool maxWindow, IWin32Window owner)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            frmBatchLogin _frmBatchLogin = new frmBatchLogin();
            foreach (DictionaryEntry dictionaryEntry in pUserInfo)
            {
                if (!string.IsNullOrEmpty(((UserInfo)dictionaryEntry.Value).UKey))
                {
                    continue;
                }
                _frmBatchLogin.htUserInfo.Add(((string)dictionaryEntry.Key).Clone(), ((UserInfo)dictionaryEntry.Value).Clone());
                string[] displayName = new string[] { ((UserInfo)dictionaryEntry.Value).GetDisplayName(), string.Empty };
                ListViewItem listViewItem = new ListViewItem(displayName)
                {
                    Name = (string)dictionaryEntry.Key
                };
                _frmBatchLogin.lvBatch.Items.Add(listViewItem);
            }
            _frmBatchLogin.sExeFilePath = exePath;
            _frmBatchLogin.bMaxWindows = maxWindow;
            _frmBatchLogin.sExeParam = exeParam;
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = _frmBatchLogin.ShowDialog(owner)));
            return dialogResult;
        }

        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
    }
}
