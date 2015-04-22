using LibKasCore;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SystemCenter.Properties;

namespace SystemCenter
{
    public partial class frmLauncher : Form
    {

        public frmLauncher()
        {
            InitializeComponent();
        }

        public frmLauncher(string autoStartUserName)
        {
            this.autoStartUserName = autoStartUserName;
            InitializeComponent();
        }

        public frmLauncher(bool batchLogin)
        {
            bBatchLogin = batchLogin;
            InitializeComponent();
        }

        private const string csExeFilePath = "bin\\ExeFile.exe";
        private const string csExeParam = "/noconsole /ssoToken=";
        private const string csExeParamLocal = "/noconsole /LUA:OFF /ssoToken=";
        private const string csServer = "211.144.214.68";
        private XmlDocumentEx xUserInfo = new XmlDocumentEx();
        private Hashtable htUserInfo = new Hashtable();
        private string csExeFileSelPath = "";
        private BackgroundWorker bgwPing = new BackgroundWorker();
        private BackgroundWorker bgwLogin = new BackgroundWorker();
        private BackgroundWorker bgwStatus = new BackgroundWorker();
        public EveHttpLogin myLogin;
        private frmCaptcha fCaptchs = new frmCaptcha();
        private bool bSSOTokenOnly;
        private string sTokenOnly = "";
        private string autoStartUserName = "";
        private bool bBatchLogin;
        private ArrayList alLockList = new ArrayList();

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            string str;
            string str1;
            string str2;
            string str3;
            string str4;
            UserInfo argument = (UserInfo)e.Argument;
            this.myLogin = new EveHttpLogin(argument.UserName, argument.Password);
            if (!string.IsNullOrEmpty(argument.UKey))
            {
                bool flag = false;
                string empty = string.Empty;
                if (frmInputBox.Show("UKey安全登录", string.Concat("请插入账号 ", argument.GetDisplayName(), " 绑定的UKey\r\n\r\n或输入档案密钥，点击确定登录游戏"), "", true, 256, true, argument.UKey, this, out empty, out flag) != DialogResult.OK || !flag && !this.xUserInfo.ValidateKey(empty))
                {
                    return;
                }
            }
            do
            {
                if (!this.myLogin.IsNeedCaptcha())
                {
                    continue;
                }
                if (frmCaptcha.Show(this, out str3, out str2) != DialogResult.OK)
                {
                    return;
                }
                this.myLogin.CaptchaToken = str3;
                this.myLogin.Captcha = str2;
            }
            while (!this.myLogin.Login(out str4, out str, out str1) && this.MessageBoxEx(this, str1, str, MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) == DialogResult.Retry);
            if (!string.IsNullOrEmpty(str4))
            {
                if (this.bSSOTokenOnly)
                {
                    this.sTokenOnly = str4;
                }
                else
                {
                    this.bgwLogin.ReportProgress(2);
                    this.bgwLogin.ReportProgress(1, 100);
                    base.Invoke(new MethodInvoker(() => this.RunGame(str4)));
                }
                if (argument.HasSkillSpan && argument.SkillHasExpired())
                {
                    argument.ClearSkillSpan();
                }
            }
            else if (str.Equals("授权协议更新"))
            {
                string[] strArrays = str1.Split(new char[] { '|' });
                frmEULA.Show(this, str, strArrays[1], strArrays[0], this.myLogin);
                return;
            }
        }

        private void bgwLogin_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    {
                        this.pbLogin.Value = (int)e.UserState;
                        return;
                    }
                case 2:
                    {
                        this.pbLogin.Style = ProgressBarStyle.Continuous;
                        return;
                    }
                case 3:
                    {
                        this.pbLogin.Style = ProgressBarStyle.Marquee;
                        return;
                    }
                case 4:
                    {
                        this.RunGame((string)e.UserState);
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void bgwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.bSSOTokenOnly)
            {
                this.bSSOTokenOnly = false;
                MessageBox.Show(string.Concat("启动参数已经复制到剪贴板\r\n\r\n", (this.cmLocalSettings.Checked ? "/noconsole /LUA:OFF /ssoToken=" : "/noconsole /ssoToken="), this.sTokenOnly), "SSOToken", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Clipboard.Clear();
                Clipboard.SetText(string.Concat((this.cmLocalSettings.Checked ? "/noconsole /LUA:OFF /ssoToken=" : "/noconsole /ssoToken="), this.sTokenOnly), TextDataFormat.Text);
            }
            this.btRun.Enabled = true;
            this.cbUserName.Enabled = true;
            this.pbLogin.Style = ProgressBarStyle.Continuous;
        }

        private void bgwPing_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    while (true)
                    {
                    Label0:
                        PingReply pingReply = (new Ping()).Send("211.144.214.68", 1000);
                        if (pingReply.Status != IPStatus.Success)
                        {
                            this.bgwPing.ReportProgress(-1, "?");
                        }
                        else
                        {
                            this.bgwPing.ReportProgress(0, pingReply.RoundtripTime);
                        }
                        Thread.Sleep(30000);
                        goto Label0;
                    }
                }
                catch (Exception exception)
                {
                    this.bgwPing.ReportProgress(-1, exception.Message);
                }
            }
        }

        private void bgwPing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string titleInfo = Resources.TitleInfo;
            switch (e.ProgressPercentage)
            {
                case -1:
                    {
                        if (!string.IsNullOrEmpty(titleInfo))
                        {
                            this.Text = string.Concat("RatEveLanucher(", (string)e.UserState, ") - ", titleInfo);
                            return;
                        }
                        this.Text = string.Concat("RatEveLanucher(", (string)e.UserState, ") - ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
                        return;
                    }
                case 0:
                    {
                        long userState = (long)e.UserState;
                        if (!string.IsNullOrEmpty(titleInfo))
                        {
                            this.Text = string.Concat("RatEveLanucher(", userState.ToString(), "ms) - ", titleInfo);
                            return;
                        }
                        this.Text = string.Concat("RatEveLanucher(", userState.ToString(), "ms) - ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void bgwStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            while (true)
            {
                bool serverStatus = EveHttpLogin.GetServerStatus(out num);
                this.bgwStatus.ReportProgress(num, serverStatus);
                Thread.Sleep(60000);
            }
        }

        private void bgwStatus_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
            {
                this.lOnlinePlayers.Text = "晨曦 不在线";
                this.lOnlinePlayers.ForeColor = Color.LightSeaGreen;
                this.lOnlinePlayers.Visible = true;
                return;
            }
            Label label = this.lOnlinePlayers;
            int progressPercentage = e.ProgressPercentage;
            label.Text = string.Concat("晨曦 ", progressPercentage.ToString("n0"), " 在线");
            this.lOnlinePlayers.ForeColor = Color.Turquoise;
            this.lOnlinePlayers.Visible = true;
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            if (this.cbUserName.SelectedIndex < 0)
            {
                return;
            }
            this.btRun.Enabled = false;
            this.cbUserName.Enabled = false;
            this.pbLogin.Value = 0;
            this.pbLogin.Style = ProgressBarStyle.Marquee;
            this.bgwLogin.RunWorkerAsync(this.cbUserName.SelectedItem);
        }

        private void cbUserName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            if (this.CompareDrawItemState(e.State, DrawItemState.Selected) || this.CompareDrawItemState(e.State, DrawItemState.NoAccelerator) && this.CompareDrawItemState(e.State, DrawItemState.NoFocusRect) && this.CompareDrawItemState(e.State, DrawItemState.ComboBoxEdit))
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.FromArgb(0, 33, 89), Color.FromArgb(27, 153, 199), LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(linearGradientBrush, e.Bounds);
                if (string.IsNullOrEmpty(((UserInfo)((ComboBox)sender).Items[e.Index]).UKey))
                {
                    e.Graphics.DrawImage(this.ilMain.Images[1], e.Bounds.Left, e.Bounds.Top);
                    Graphics graphics = e.Graphics;
                    string str = ((ComboBox)sender).Items[e.Index].ToString();
                    Font font = e.Font;
                    SolidBrush solidBrush = new SolidBrush(Color.White);
                    float left = (float)(e.Bounds.Left + this.ilMain.ImageSize.Width);
                    Rectangle bounds = e.Bounds;
                    graphics.DrawString(str, font, solidBrush, left, (float)(bounds.Top + 2));
                }
                else
                {
                    e.Graphics.DrawImage(this.ilMain.Images[0], e.Bounds.Left, e.Bounds.Top);
                    Graphics graphic = e.Graphics;
                    string str1 = ((ComboBox)sender).Items[e.Index].ToString();
                    Font font1 = e.Font;
                    SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(0, 33, 89));
                    float single = (float)(e.Bounds.Left + this.ilMain.ImageSize.Width);
                    Rectangle rectangle = e.Bounds;
                    graphic.DrawString(str1, font1, solidBrush1, single, (float)(rectangle.Top + 2));
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                if (string.IsNullOrEmpty(((UserInfo)((ComboBox)sender).Items[e.Index]).UKey))
                {
                    e.Graphics.DrawImage(this.ilMain.Images[1], e.Bounds.Left, e.Bounds.Top);
                    Graphics graphics1 = e.Graphics;
                    string str2 = ((ComboBox)sender).Items[e.Index].ToString();
                    Font font2 = e.Font;
                    SolidBrush solidBrush2 = new SolidBrush(e.ForeColor);
                    float left1 = (float)(e.Bounds.Left + this.ilMain.ImageSize.Width);
                    Rectangle bounds1 = e.Bounds;
                    graphics1.DrawString(str2, font2, solidBrush2, left1, (float)(bounds1.Top + 2));
                }
                else
                {
                    e.Graphics.DrawImage(this.ilMain.Images[0], e.Bounds.Left, e.Bounds.Top);
                    Graphics graphic1 = e.Graphics;
                    string str3 = ((ComboBox)sender).Items[e.Index].ToString();
                    Font font3 = e.Font;
                    SolidBrush solidBrush3 = new SolidBrush(Color.FromArgb(50, 50, 50));
                    float single1 = (float)(e.Bounds.Left + this.ilMain.ImageSize.Width);
                    Rectangle rectangle1 = e.Bounds;
                    graphic1.DrawString(str3, font3, solidBrush3, single1, (float)(rectangle1.Top + 2));
                }
            }
            e.DrawFocusRectangle();
        }

        private void cbUserName_DropDown(object sender, EventArgs e)
        {
            this.tSkillRefresh.Enabled = false;
        }

        private void cbUserName_DropDownClosed(object sender, EventArgs e)
        {
            this.tSkillRefresh.Enabled = true;
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pbLogin.Value = 0;
        }

        private bool CheckAdvStatus()
        {
            RegistrySecurity registrySecurity = new RegistrySecurity();
            registrySecurity.AddAccessRule(new RegistryAccessRule(string.Concat(Environment.UserDomainName, "\\", Environment.UserName), RegistryRights.QueryValues | RegistryRights.SetValue | RegistryRights.CreateSubKey | RegistryRights.EnumerateSubKeys | RegistryRights.Notify | RegistryRights.ExecuteKey | RegistryRights.ReadKey | RegistryRights.WriteKey | RegistryRights.Delete | RegistryRights.ReadPermissions, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\eveBanner.exe");
            if (registryKey == null)
            {
                return false;
            }
            string str = registryKey.GetValue("debugger", "").ToString();
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            if (!str.Equals("C:\\Windows\\System32\\svchost.exe"))
            {
                return false;
            }
            return true;
        }

        private void cmAutoMaxWindow_Click(object sender, EventArgs e)
        {
            this.cmAutoMaxWindow.Checked = !this.cmAutoMaxWindow.Checked;
            XmlNode str = this.xUserInfo.DocumentElement.SelectSingleNode("AutoMaximized") ?? this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("AutoMaximized"));
            str.InnerText = this.cmAutoMaxWindow.Checked.ToString();
            this.xUserInfo.Save();
        }

        private void cmDisableAdvShow_Click(object sender, EventArgs e)
        {
            RegistrySecurity registrySecurity = new RegistrySecurity();
            registrySecurity.AddAccessRule(new RegistryAccessRule(string.Concat(Environment.UserDomainName, "\\", Environment.UserName), RegistryRights.QueryValues | RegistryRights.SetValue | RegistryRights.CreateSubKey | RegistryRights.EnumerateSubKeys | RegistryRights.Notify | RegistryRights.ExecuteKey | RegistryRights.ReadKey | RegistryRights.WriteKey | RegistryRights.Delete | RegistryRights.ReadPermissions, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            if (this.CheckAdvStatus())
            {
                if (MessageBox.Show(this, "广告弹窗当前已启用，是否禁用？\r\n\r\n若关闭此功能，每次游戏关闭后都会弹出广告窗口！", "启用/禁用广告弹窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    try
                    {
                        Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options", true).DeleteSubKeyTree("eveBanner.exe");
                        MessageBox.Show(this, "广告弹窗已成功禁用！\r\n\r\n", "启用/禁用广告弹窗", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        MessageBox.Show(this, string.Concat("访问注册表错误！\r\n\r\n", exception.Message), "启用/禁用广告弹窗", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else if (MessageBox.Show(this, "广告弹窗当前已禁用，是否启用？(建议启用此功能)\r\n\r\n声明：这个修改通过操作系统本身的功能实现，禁用广告不会违反EULA中任何关于修改客户端的规定！", "启用/禁用广告弹窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                try
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options", true);
                    registryKey.CreateSubKey("eveBanner.exe").SetValue("debugger", "C:\\Windows\\System32\\svchost.exe");
                    MessageBox.Show(this, "广告弹窗已成功启用！\r\n\r\n", "启用/禁用广告弹窗", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception exception3)
                {
                    Exception exception2 = exception3;
                    MessageBox.Show(this, string.Concat("访问注册表错误！\r\n\r\n", exception2.Message), "启用/禁用广告弹窗", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            bool flag = this.CheckAdvStatus();
            this.cmDisableAdvShow.Checked = flag;
        }

        private void cmLocalSettings_Click(object sender, EventArgs e)
        {
            this.cmLocalSettings.Checked = !this.cmLocalSettings.Checked;
            XmlNode str = this.xUserInfo.DocumentElement.SelectSingleNode("UseLocalSettings") ?? this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("UseLocalSettings"));
            str.InnerText = this.cmLocalSettings.Checked.ToString();
            this.xUserInfo.Save();
        }

        private void cmMidPosCal_Click(object sender, EventArgs e)
        {
        }

        private void cmRunFrom_Click(object sender, EventArgs e)
        {
            this.cmRunFrom.Checked = !this.cmRunFrom.Checked;
            if (!this.cmRunFrom.Checked)
            {
                XmlNode empty = this.xUserInfo.DocumentElement.SelectSingleNode("ExeFile");
                if (empty != null)
                {
                    empty.InnerText = string.Empty;
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    AddExtension = true,
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DefaultExt = "exe",
                    Filter = "EVE主程序(ExeFile.exe)|ExeFile.exe",
                    FilterIndex = 0,
                    Multiselect = false,
                    RestoreDirectory = true,
                    Title = "选择EVE主程序位置",
                    ValidateNames = true
                };
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    this.cmRunFrom.Checked = false;
                    XmlNode xmlNodes = this.xUserInfo.DocumentElement.SelectSingleNode("ExeFile");
                    if (xmlNodes != null)
                    {
                        xmlNodes.InnerText = string.Empty;
                    }
                }
                else
                {
                    this.csExeFileSelPath = openFileDialog.FileName;
                    XmlNode xmlNodes1 = this.xUserInfo.DocumentElement.SelectSingleNode("ExeFile");
                    if (xmlNodes1 != null)
                    {
                        xmlNodes1.InnerText = this.csExeFileSelPath;
                    }
                    else
                    {
                        this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("ExeFile")).InnerText = this.csExeFileSelPath;
                    }
                }
            }
            this.xUserInfo.Save();
            this.LoadConfig();
            this.NTFSCheck();
        }

        private void cmSubClear_Click(object sender, EventArgs e)
        {
            this.ResetDocument();
        }

        private void cmSubSSOToken_Click(object sender, EventArgs e)
        {
            string str = "";
            string text = Clipboard.GetText();
            text = text.Trim();
            if (text.Length != 151)
            {
                text = "";
            }
            if (frmInputBox.Show("输入SSOToken", "手工输入从网页获取的登录令牌", text, false, 151, this, out str) == DialogResult.OK)
            {
                this.RunGame(str);
            }
        }

        private void cmUserUIConfig_Click(object sender, EventArgs e)
        {
            (new frmUIEditor()).ShowDialog(this);
        }

        private void cm启动登录器输入密码_Click(object sender, EventArgs e)
        {
            string str;
            string str1;
            if (this.cm启动登录器输入密码.Checked)
            {
                if (frmInputBox.Show("关闭启动密码", "请输入安全档案密钥\r\n\r\n提示：您在首次建立安全档案时设置了这个密钥", "", true, this, out str) == DialogResult.Cancel)
                {
                    return;
                }
                if (!this.xUserInfo.ValidateKey(str))
                {
                    MessageBox.Show(this, "密钥输入不正确，无法关闭启动密码！", "启动密码", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (MessageBox.Show(this, "密码验证通过，是否取消启动时输入密码？", "启动密码", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    XmlNode xmlNodes = this.xUserInfo.DocumentElement.SelectSingleNode("SecurityLevel") ?? this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("SecurityLevel"));
                    xmlNodes.InnerText = "0";
                    this.cm启动登录器输入密码.Checked = false;
                    this.xUserInfo.Save();
                }
                return;
            }
            if (frmInputBox.Show("激活启动密码", "请输入安全档案密钥\r\n\r\n提示：您在首次建立安全档案时设置了这个密钥", "", true, this, out str1) == DialogResult.Cancel)
            {
                return;
            }
            if (!this.xUserInfo.ValidateKey(str1))
            {
                MessageBox.Show(this, "密钥输入不正确，无法激活启动密码！", "启动密码", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (MessageBox.Show(this, "密码验证通过，是否激活启动时输入密码？", "启动密码", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                XmlNode xmlNodes1 = this.xUserInfo.DocumentElement.SelectSingleNode("SecurityLevel") ?? this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("SecurityLevel"));
                xmlNodes1.InnerText = "1";
                this.cm启动登录器输入密码.Checked = true;
                this.xUserInfo.Save();
            }
        }

        private bool CompareDrawItemState(DrawItemState srcState, DrawItemState tarState)
        {
            return (srcState & tarState) == tarState;
        }

        private void CreateLink(string LinkName, string ExeName, string Arguments, string Description)
        {
            this.CreateLink(LinkName, ExeName, Arguments, Description, 0);
        }

        private void CreateLink(string LinkName, string ExeName, string Arguments, string Description, int iconIndex)
        {
            Shortcut shortcut = new Shortcut()
            {
                Path = ExeName,
                WorkingDirectory = Path.GetDirectoryName(ExeName),
                Arguments = Arguments,
                Description = Description,
                Icon = string.Concat(ExeName, ",", iconIndex.ToString())
            };
            shortcut.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), string.Concat(LinkName, ".lnk")));
            MessageBox.Show(string.Concat("成功为 ", LinkName, " 建立桌面快捷方式！"), "快捷方式", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private UserInfo DecodeUserInfo(string sIn)
        {
            UserInfo userInfo;
            string str = "";
            StreamReader streamReader = null;
            StringBuilder stringBuilder = new StringBuilder();
            HashAlgorithm hashAlgorithm = MD5.Create();
            UserInfo userInfo1 = new UserInfo();
            try
            {
                try
                {
                    str = Base64.DecodeBase64(sIn);
                    streamReader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(str)));
                    userInfo1.UserName = streamReader.ReadLine();
                    userInfo1.Password = streamReader.ReadLine();
                    userInfo1.Alias = streamReader.ReadLine();
                    stringBuilder.AppendLine(userInfo1.UserName);
                    stringBuilder.AppendLine(userInfo1.Password);
                    stringBuilder.AppendLine(userInfo1.Alias);
                    if (BitConverter.ToString(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()))).Equals(streamReader.ReadLine()))
                    {
                        userInfo = userInfo1;
                    }
                    else
                    {
                        userInfo = null;
                    }
                }
                catch (Exception exception)
                {
                    userInfo = null;
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return userInfo;
        }

        private string EncodeUserInfo(UserInfo uiIn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashAlgorithm hashAlgorithm = MD5.Create();
            stringBuilder.AppendLine(uiIn.UserName);
            stringBuilder.AppendLine(uiIn.Password);
            stringBuilder.AppendLine(uiIn.Alias);
            string str = BitConverter.ToString(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString())));
            stringBuilder.AppendLine(str);
            return Base64.EncodeBase64(stringBuilder.ToString());
        }

        private void frmLauncher_Shown(object sender, EventArgs e)
        {
            string titleInfo = Resources.TitleInfo;
            if (string.IsNullOrEmpty(titleInfo))
            {
                this.Text = string.Concat("RatEveLanucher - ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
            else
            {
                this.Text = string.Concat("RatEveLanucher - ", titleInfo);
            }
            while (true)
            {
                try
                {
                    this.LoadConfig();
                    break;
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    string empty = string.Empty;
                    if (frmInputBox.Show("初始化全档案", "首次使用，请您输入用于加密整个安全档案的密钥\r\n\r\n提示：请妥善保管这个密钥", "", true, 256, true, this, out empty) != DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.xUserInfo = new XmlDocumentEx(empty);
                        this.xUserInfo.AppendChild(this.xUserInfo.CreateXmlDeclaration("1.0", "GBK", "yes"));
                        this.xUserInfo.AppendChild(this.xUserInfo.CreateElement("Config"));
                        this.xUserInfo.Save("Config.xml");
                        break;
                    }
                }
                catch (CryptographicException cryptographicException)
                {
                    DialogResult dialogResult = MessageBox.Show(this, "无法识别的档案文件，如果您是老用户可以尝试输入原来的密钥进行档案升级\r\n\r\n - 点击 [是] 尝试从老档案恢复升级\r\n - 点击 [否] 覆盖生成新的档案\r\n - 点击 [取消] 关闭登录器", "无法载入档案", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        switch (dialogResult)
                        {
                            case DialogResult.Yes:
                                {
                                    string str = string.Empty;
                                    if (frmInputBox.Show("恢复升级", "请输入原始档案密钥\r\n\r\n如果您不知道，请咨询开发人员", "", true, 256, true, this, out str) != DialogResult.OK)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            this.LoadConfig(str, XmlDocumentEx.CryptMode.CONST8);
                                            string outerXml = this.xUserInfo.OuterXml;
                                            string empty1 = string.Empty;
                                            if (frmInputBox.Show("档案恢复升级", "恢复成功，请您输入新的密钥\r\n\r\n提示：请妥善保管这个密钥", "", true, 256, true, this, out empty1) != DialogResult.OK)
                                            {
                                                MessageBox.Show(this, "用户放弃重置，所有操作已经回退，没有对原档案进行修改", "放弃操作", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            }
                                            else
                                            {
                                                this.xUserInfo = new XmlDocumentEx(empty1);
                                                this.xUserInfo.LoadXml(outerXml);
                                                this.xUserInfo.Save("Config.xml");
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            MessageBox.Show(this, "密钥输入不正确，无法从旧档案中恢复！\r\n\r\n如果旧档案已经损坏，请尝试覆盖生成新档案。", "档案恢复升级", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        }
                                        continue;
                                    }
                                }
                            case DialogResult.No:
                                {
                                    this.ResetDocument();
                                    break;
                                }
                        }
                    }
                }
                catch (Exception exception2)
                {
                    Exception exception1 = exception2;
                    MessageBox.Show(this, exception1.Message, "载入配置文件错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
            }
            this.bgwPing.DoWork += new DoWorkEventHandler(this.bgwPing_DoWork);
            this.bgwPing.ProgressChanged += new ProgressChangedEventHandler(this.bgwPing_ProgressChanged);
            this.bgwLogin.DoWork += new DoWorkEventHandler(this.bgwLogin_DoWork);
            this.bgwLogin.ProgressChanged += new ProgressChangedEventHandler(this.bgwLogin_ProgressChanged);
            this.bgwLogin.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwLogin_RunWorkerCompleted);
            this.bgwStatus.DoWork += new DoWorkEventHandler(this.bgwStatus_DoWork);
            this.bgwStatus.ProgressChanged += new ProgressChangedEventHandler(this.bgwStatus_ProgressChanged);
            this.bgwStatus.WorkerReportsProgress = true;
            this.bgwLogin.WorkerReportsProgress = true;
            this.bgwLogin.WorkerSupportsCancellation = true;
            this.bgwPing.WorkerReportsProgress = true;
            this.bgwPing.RunWorkerAsync();
            if (!string.IsNullOrEmpty(this.csExeFileSelPath) || File.Exists("bin\\ExeFile.exe"))
            {
                this.NTFSCheck();
            }
            else
            {
                MessageBox.Show(this, "请将启动器放入 EVE Online 安装目录下，或指定游戏路径.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.bgwStatus.RunWorkerAsync();
            if (!string.IsNullOrEmpty(this.autoStartUserName) && this.htUserInfo.ContainsKey(this.autoStartUserName))
            {
                this.btRun.Enabled = false;
                this.cbUserName.Enabled = false;
                this.pbLogin.Value = 0;
                this.pbLogin.Style = ProgressBarStyle.Marquee;
                this.cbUserName.SelectedItem = this.htUserInfo[this.autoStartUserName];
                this.bgwLogin.RunWorkerAsync(this.htUserInfo[this.autoStartUserName]);
            }
            if (this.bBatchLogin)
            {
                frmBatchLogin.Show(this.htUserInfo, (this.cmRunFrom.Checked ? this.csExeFileSelPath : "bin\\ExeFile.exe"), (this.cmLocalSettings.Checked ? "/noconsole /LUA:OFF /ssoToken=" : "/noconsole /ssoToken="), this.cmAutoMaxWindow.Checked, this);
            }
        }

        private void lb_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(143, 179, 164);
        }

        private void lb_MouseEnter(object sender, EventArgs e)
        {
            Label font = (Label)sender;
            font.Font = new Font(font.Font, FontStyle.Underline);
            font.ForeColor = Color.FromArgb(180, 224, 191);
        }

        private void lb_MouseLeave(object sender, EventArgs e)
        {
            Label font = (Label)sender;
            font.Font = new Font(font.Font, FontStyle.Regular);
            font.ForeColor = Color.White;
        }

        private void lb_MouseUp(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
        }

        private void lbEdit_Click(object sender, EventArgs e)
        {
            if ((new frmEditor()).ShowDialog(this) == DialogResult.OK)
            {
                this.LoadConfig();
            }
        }

        private void lbSSOToken_MouseClick(object sender, MouseEventArgs e)
        {
            this.cmMain.Show(this.lbSSOToken, e.Location);
        }

        private void LoadConfig()
        {
            this.LoadConfig(string.Empty, XmlDocumentEx.CryptMode.MD5);
        }

        private void LoadConfig(string sKey, XmlDocumentEx.CryptMode psMode)
        {
            string str;
            if (!string.IsNullOrEmpty(sKey))
            {
                this.xUserInfo = new XmlDocumentEx(sKey, psMode);
            }
            else
            {
                this.xUserInfo = new XmlDocumentEx();
            }
            this.cbUserName.Items.Clear();
            this.htUserInfo.Clear();
            this.xUserInfo.Load("Config.xml");
            XmlNode xmlNodes = this.xUserInfo.DocumentElement.SelectSingleNode("SecurityLevel");
            if (xmlNodes == null)
            {
                xmlNodes = this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("SecurityLevel"));
                xmlNodes.InnerText = "0";
                this.xUserInfo.Save();
            }
            if (!xmlNodes.InnerText.Equals("0"))
            {
                this.cm启动登录器输入密码.Checked = true;
                if (frmInputBox.Show("启动密码", "请输入安全档案密钥\r\n\r\n提示：您在首次建立安全档案时设置了这个密钥", "", true, this, out str) == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
                if (!this.xUserInfo.ValidateKey(str))
                {
                    MessageBox.Show(this, "密钥输入不正确，无法启动登录器！", "启动密码", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
            }
            else
            {
                this.cm启动登录器输入密码.Checked = false;
            }
            foreach (XmlNode xmlNodes1 in this.xUserInfo.DocumentElement.SelectNodes("User[@UserName][@Password]"))
            {
                string value = xmlNodes1.Attributes["UserName"].Value;
                string value1 = xmlNodes1.Attributes["Password"].Value;
                string empty = string.Empty;
                if (xmlNodes1.Attributes["Alias"] != null)
                {
                    empty = xmlNodes1.Attributes["Alias"].Value;
                }
                string empty1 = string.Empty;
                if (xmlNodes1.Attributes["UKey"] != null)
                {
                    empty1 = xmlNodes1.Attributes["UKey"].Value;
                }
                string str1 = string.Empty;
                if (xmlNodes1.Attributes["SkillDeadLine"] != null)
                {
                    str1 = xmlNodes1.Attributes["SkillDeadLine"].Value;
                }
                UserInfo userInfo = new UserInfo(value, value1, empty, empty1);
                if (!string.IsNullOrEmpty(str1))
                {
                    userInfo.SkillDeadLine = str1;
                }
                this.htUserInfo.Add(userInfo.UserName, userInfo);
                this.cbUserName.Items.Add(userInfo);
            }
            XmlNode xmlNodes2 = this.xUserInfo.DocumentElement.SelectSingleNode("ExeFile");
            if (xmlNodes2 == null)
            {
                this.csExeFileSelPath = string.Empty;
                this.cmRunFrom.Checked = false;
            }
            else if (!string.IsNullOrEmpty(xmlNodes2.InnerText))
            {
                this.csExeFileSelPath = xmlNodes2.InnerText;
                this.cmRunFrom.Checked = true;
            }
            else
            {
                this.csExeFileSelPath = string.Empty;
                this.cmRunFrom.Checked = false;
            }
            XmlNode xmlNodes3 = this.xUserInfo.DocumentElement.SelectSingleNode("AutoMaximized");
            if (xmlNodes3 == null)
            {
                xmlNodes3 = this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("AutoMaximized"));
                xmlNodes3.InnerText = "False";
            }
            XmlNode xmlNodes4 = this.xUserInfo.DocumentElement.SelectSingleNode("UseLocalSettings");
            if (xmlNodes4 == null)
            {
                xmlNodes4 = this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("UseLocalSettings"));
                xmlNodes4.InnerText = "False";
            }
            XmlNode xmlNodes5 = this.xUserInfo.DocumentElement.SelectSingleNode("CloseAfterLaunch");
            if (xmlNodes5 == null)
            {
                xmlNodes5 = this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("CloseAfterLaunch"));
                xmlNodes5.InnerText = "False";
            }
            if (this.xUserInfo.DocumentElement.SelectSingleNode("SimpleLaunchMod") == null)
            {
                XmlNode xmlNodes6 = this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("SimpleLaunchMod"));
                xmlNodes6.InnerText = "0";
            }
            XmlNode xmlNodes7 = this.xUserInfo.DocumentElement.SelectSingleNode("SimpleLaunchCustom");
            if (xmlNodes7 != null)
            {
                this.xUserInfo.DocumentElement.RemoveChild(xmlNodes7);
                this.xUserInfo.Save();
            }
            this.cmLocalSettings.Checked = bool.Parse(xmlNodes4.InnerText);
            this.cmAutoMaxWindow.Checked = bool.Parse(xmlNodes3.InnerText);
            this.启动游戏后关闭登录器CToolStripMenuItem.Checked = bool.Parse(xmlNodes5.InnerText);
            this.cmDisableAdvShow.Checked = this.CheckAdvStatus();
        }

        private void LockStuff(bool bCustomShipsAndDrones, bool bPlantes, bool bStations, bool bOthers)
        {
            this.ProcessStuff(Resources.ShipsAndDrones, bCustomShipsAndDrones);
            this.ProcessStuff(Resources.Plantes, bPlantes);
            this.ProcessStuff(Resources.Stations, bStations);
            this.ProcessStuff(Resources.Others, bOthers);
        }

        private DialogResult MessageBoxEx(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult dialogResult = DialogResult.None;
            ((Form)owner).Invoke(new MethodInvoker(() => dialogResult = MessageBox.Show(owner, text, caption, buttons, icon)));
            return dialogResult;
        }

        private void NTFSCheck()
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot((string.IsNullOrEmpty(this.csExeFileSelPath) ? Path.Combine(Application.StartupPath, "bin\\ExeFile.exe") : this.csExeFileSelPath)));
                if (driveInfo.DriveFormat.Equals("NTFS"))
                {
                    this.toolStripMenuItemSpl.Enabled = true;
                }
                else
                {
                    this.toolStripMenuItemSpl.Enabled = false;
                    this.toolStripMenuItemSpl.Text = string.Concat("无模型启动(&P)(", driveInfo.DriveFormat, "不可用)");
                }
            }
            catch (Exception exception)
            {
                this.toolStripMenuItemSpl.Enabled = false;
                this.toolStripMenuItemSpl.Text = "无模型启动(&P)(当前系统不可用)";
            }
        }

        private bool ProcessStuff(string sList, bool dFlag)
        {
            bool flag = true;
            MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(sList));
            StreamReader streamReader = new StreamReader(memoryStream, Encoding.Default);
            string directoryName = Path.GetDirectoryName((this.cmRunFrom.Checked ? this.csExeFileSelPath : "bin\\ExeFile.exe"));
            directoryName = directoryName.Substring(0, directoryName.Length - 3);
            while (!streamReader.EndOfStream)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(Path.Combine(directoryName, streamReader.ReadLine()));
                    FileSecurity accessControl = fileInfo.GetAccessControl(AccessControlSections.All);
                    FileSystemAccessRule fileSystemAccessRule = new FileSystemAccessRule(Environment.UserName, FileSystemRights.ReadAndExecute, AccessControlType.Deny);
                    if (!dFlag)
                    {
                        accessControl.RemoveAccessRule(fileSystemAccessRule);
                    }
                    else
                    {
                        accessControl.AddAccessRule(fileSystemAccessRule);
                    }
                    fileInfo.SetAccessControl(accessControl);
                }
                catch (Exception exception)
                {
                    flag = false;
                }
            }
            streamReader.Close();
            return flag;
        }

        private void ResetDocument()
        {
            if (MessageBox.Show(this, "所有已保存的帐号/密码将丢失无法恢复，设置将被重置！\r\n\r\n确定要继续吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK && MessageBox.Show(this, "请再次确认这个操作，这将是无法恢复的！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                string empty = string.Empty;
                if (frmInputBox.Show("初始化安全档案", "请您输入用于加密整个安全档案的密钥\r\n\r\n提示：请妥善保管这个密钥", "", true, 256, true, this, out empty) != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
                else
                {
                    this.xUserInfo = new XmlDocumentEx(empty);
                    this.xUserInfo.AppendChild(this.xUserInfo.CreateXmlDeclaration("1.0", "GBK", "yes"));
                    this.xUserInfo.AppendChild(this.xUserInfo.CreateElement("Config"));
                    this.xUserInfo.Save("Config.xml");
                }
                this.LoadConfig();
            }
        }

        private void ResetLoginControlState(bool bState)
        {
            this.cbUserName.Enabled = bState;
            this.btRun.Enabled = bState;
        }

        private void RunGame(string sToken)
        {
            Process process = null;
        Label4:
            while (process == null)
            {
                process = new Process()
                {
                    StartInfo = (this.cmRunFrom.Checked ? new ProcessStartInfo(this.csExeFileSelPath) : new ProcessStartInfo("bin\\ExeFile.exe"))
                };
                process.StartInfo.Arguments = string.Concat((this.cmLocalSettings.Checked ? "/noconsole /LUA:OFF /ssoToken=" : "/noconsole /ssoToken="), sToken);
                try
                {
                    process.Start();
                    int num = 0;
                    while (true)
                    {
                        if (num < 60000)
                        {
                            process.Refresh();
                            if (!string.IsNullOrEmpty(process.MainWindowTitle))
                            {
                                if (this.cmAutoMaxWindow.Checked)
                                {
                                    frmLauncher.ShowWindow((int)process.MainWindowHandle, 3);
                                }
                                Thread.Sleep(500);
                                if (!this.启动游戏后关闭登录器CToolStripMenuItem.Checked && string.IsNullOrEmpty(this.autoStartUserName))
                                {
                                    this.ResetLoginControlState(true);
                                    return;
                                }
                                Environment.Exit(0);
                            }
                            num = num + 100;
                            Thread.Sleep(100);
                            Application.DoEvents();
                        }
                        else
                        {
                            string[] newLine = new string[] { "游戏启动超时，重新启动游戏？", Environment.NewLine, Environment.NewLine, "[放弃] 终止游戏进程并放弃启动", Environment.NewLine, "[重试] 终止游戏进程并重新启动", Environment.NewLine, "[忽略] 继续等待60s" };
                            switch (MessageBox.Show(string.Concat(newLine), "游戏启动超时", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
                            {
                                case DialogResult.Abort:
                                    {
                                        process.Kill();
                                        return;
                                    }
                                case DialogResult.Retry:
                                    {
                                        break;
                                    }
                                case DialogResult.Ignore:
                                    {
                                        num = 0;
                                        continue;
                                    }
                                default:
                                    {
                                        goto Label2;
                                    }
                            }
                        }
                    }
                    process.Kill();
                    process = null;
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(string.Concat("无法启动游戏进程!\r\n", exception.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            return;
        Label2:
            goto Label4;
        }

        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        private void tSkillRefresh_Tick(object sender, EventArgs e)
        {
            this.cbUserName.Refresh();
        }

        private void 导出当前账号信息EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cbUserName.SelectedIndex < 0)
            {
                return;
            }
            UserInfo selectedItem = (UserInfo)this.cbUserName.SelectedItem;
            string str = this.EncodeUserInfo(selectedItem);
            string[] displayName = new string[] { "账号", selectedItem.GetDisplayName(), "信息已导出为\r\n\r\n", str, "\r\n\r\n是否复制到剪贴板？" };
            if (MessageBox.Show(string.Concat(displayName), "导出账号信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Clipboard.Clear();
                Clipboard.SetText(str, TextDataFormat.Text);
                MessageBox.Show(string.Concat("账号 ", selectedItem.GetDisplayName(), " 信息已经复制到剪贴板！"), "导出账号信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void 导入账号信息IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "";
            if (frmInputBox.Show("导入账号信息", "请输入要导入的账号信息", Clipboard.GetText(TextDataFormat.Text), false, this, out str) == DialogResult.Cancel)
            {
                return;
            }
            UserInfo userInfo = this.DecodeUserInfo(str);
            if (userInfo == null)
            {
                MessageBox.Show("这不是一个有效的账户信息，无法导入！", "导入账号信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (this.htUserInfo.ContainsKey(userInfo.GetDisplayName()) && MessageBox.Show(string.Concat("已经存在一个账号 ", userInfo.GetDisplayName(), " 是否覆盖？"), "导入账号信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
            {
                return;
            }
            if (this.xUserInfo.DocumentElement.SelectSingleNode(string.Concat("User[@UserName='", userInfo.UserName, "'][@Password]")) != null)
            {
                this.xUserInfo.DocumentElement.RemoveChild(this.xUserInfo.DocumentElement.SelectSingleNode(string.Concat("User[@UserName='", userInfo.UserName, "'][@Password]")));
            }
            XmlNode xmlNodes = this.xUserInfo.CreateElement("User");
            xmlNodes.Attributes.Append(this.xUserInfo.CreateAttribute("UserName")).Value = userInfo.UserName;
            xmlNodes.Attributes.Append(this.xUserInfo.CreateAttribute("Password")).Value = userInfo.Password;
            xmlNodes.Attributes.Append(this.xUserInfo.CreateAttribute("Alias")).Value = userInfo.Alias;
            this.xUserInfo.DocumentElement.AppendChild(xmlNodes);
            this.xUserInfo.Save();
            this.LoadConfig();
        }

        private void 发送到桌面快捷方式DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cbUserName.SelectedItem == null)
            {
                return;
            }
            int num = 0;
            if (frmICONBrowser.Show("选择图标", "选择一个方式图标用于显示在快捷方式上", Application.ExecutablePath, this, out num) == DialogResult.OK)
            {
                this.CreateLink(((UserInfo)this.cbUserName.SelectedItem).GetDisplayName(), Application.ExecutablePath, string.Concat("/user:", ((UserInfo)this.cbUserName.SelectedItem).UserName), string.Concat(((UserInfo)this.cbUserName.SelectedItem).GetDisplayName(), "的 Eve Online 快捷登录."), num);
            }
        }

        private void 发送批量登录快捷方式到桌面BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (frmICONBrowser.Show("选择图标", "选择一个方式图标用于显示在快捷方式上", Application.ExecutablePath, this, out num) == DialogResult.OK)
            {
                this.CreateLink("批量登录", Application.ExecutablePath, "/batch", "Eve Online 批量登录.", num);
            }
        }

        private void 恢复全部账号信息RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (frmInputBox.Show("恢复账号信息", "请输入安全档案密钥\r\n\r\n提示：您在首次建立安全档案时设置了这个密钥", "", true, 256, true, this, out empty) == DialogResult.OK)
            {
                if (!this.xUserInfo.ValidateKey(empty))
                {
                    MessageBox.Show(this, "密钥输入不正确，无法恢复账号信息！", "恢复账号信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (MessageBox.Show(this, "密码验证通过，是否将账号信息明文恢复到剪贴板中？", "恢复账号信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("账号信息恢复");
                    foreach (DictionaryEntry dictionaryEntry in this.htUserInfo)
                    {
                        UserInfo value = (UserInfo)dictionaryEntry.Value;
                        stringBuilder.AppendFormat("角色:{0}\t账号:{1}\t密码:{2}", value.Alias, value.UserName, value.Password);
                        stringBuilder.AppendLine();
                    }
                    Clipboard.Clear();
                    Clipboard.SetText(stringBuilder.ToString(), TextDataFormat.Text);
                    MessageBox.Show(this, "账号信息明文已经被复制到剪贴板中。", "恢复账号信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
        }

        private void 仅获取SSOTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cbUserName.SelectedIndex < 0)
            {
                return;
            }
            this.btRun.Enabled = false;
            this.cbUserName.Enabled = false;
            this.pbLogin.Value = 0;
            this.pbLogin.Style = ProgressBarStyle.Marquee;
            this.bSSOTokenOnly = true;
            this.bgwLogin.RunWorkerAsync(this.cbUserName.SelectedItem);
        }

        private void 精简启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItemSpl.Enabled)
            {
                this.禁用DToolStripMenuItem.Checked = this.禁用DToolStripMenuItem.Equals(sender);
                this.会战模式BToolStripMenuItem.Checked = this.会战模式BToolStripMenuItem.Equals(sender);
                this.标准精简模式SToolStripMenuItem.Checked = this.标准精简模式SToolStripMenuItem.Equals(sender);
                this.占用内存最小MToolStripMenuItem.Checked = this.占用内存最小MToolStripMenuItem.Equals(sender);
                XmlNode xmlNodes = this.xUserInfo.DocumentElement.SelectSingleNode("SimpleLaunchMod") ?? this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("SimpleLaunchMod"));
                string str = "0";
                if (this.禁用DToolStripMenuItem.Checked)
                {
                    str = "0";
                }
                if (this.占用内存最小MToolStripMenuItem.Checked)
                {
                    str = "1";
                }
                if (this.会战模式BToolStripMenuItem.Checked)
                {
                    str = "2";
                }
                if (this.标准精简模式SToolStripMenuItem.Checked)
                {
                    str = "3";
                }
                xmlNodes.InnerText = str;
                this.xUserInfo.Save();
                try
                {
                    string str1 = str;
                    string str2 = str1;
                    if (str1 != null && !(str2 == "0") && !(str2 == "1") && !(str2 == "2"))
                    {
                    }
                    if (this.禁用DToolStripMenuItem.Checked)
                    {
                        this.LockStuff(false, false, false, false);
                    }
                    if (this.占用内存最小MToolStripMenuItem.Checked)
                    {
                        this.LockStuff(true, true, true, true);
                    }
                    if (this.会战模式BToolStripMenuItem.Checked)
                    {
                        this.LockStuff(true, false, false, true);
                    }
                    if (this.标准精简模式SToolStripMenuItem.Checked)
                    {
                        this.LockStuff(true, true, false, false);
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(this, string.Concat("模型屏蔽失败！\r\n\r\n", exception.Message), "无模型启动", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void 批量导出账号信息AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = "elg",
                Filter = "EVE Launcher 账号信息文件(*.elg)|*.elg|所有文件(*.*)|*.*",
                FilterIndex = 0,
                OverwritePrompt = true,
                RestoreDirectory = true,
                SupportMultiDottedExtensions = true,
                Title = "批量导出账号信息",
                ValidateNames = true
            };
            string empty = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                empty = saveFileDialog.FileName;
                string str = string.Empty;
                string empty1 = string.Empty;
                if (frmInputBox.Show("批量导出", "请输入安全档案密钥\r\n\r\n提示：您在首次建立安全档案时设置了这个密钥", "", true, 256, true, this, out str) == DialogResult.OK)
                {
                    if (!this.xUserInfo.ValidateKey(str))
                    {
                        MessageBox.Show(this, "安全档案密钥不正确，批量导出失败！", "批量导出", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (frmInputBox.Show("批量导出", "请输入导出文件密钥\r\n\r\n提示：这个密钥仅对导出文件生效，导入时需要提供", "", true, 256, true, this, out empty1) == DialogResult.OK)
                    {
                        XmlDocumentEx xmlDocumentEx = new XmlDocumentEx(empty1);
                        xmlDocumentEx.AppendChild(xmlDocumentEx.CreateXmlDeclaration("1.0", "GBK", "yes"));
                        xmlDocumentEx.AppendChild(xmlDocumentEx.CreateElement("ExportData"));
                        for (int i = 0; i < this.cbUserName.Items.Count; i++)
                        {
                            UserInfo item = (UserInfo)this.cbUserName.Items[i];
                            xmlDocumentEx.DocumentElement.AppendChild(xmlDocumentEx.CreateElement("UserInfo")).InnerText = this.EncodeUserInfo(item);
                        }
                        xmlDocumentEx.Save(empty);
                        int count = this.cbUserName.Items.Count;
                        MessageBox.Show(this, string.Concat("共 ", count.ToString(), " 条导出成功！\r\n", empty), "批量导出", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }
        }

        private void 批量导入账号信息BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "elg",
                Filter = "账号信息文件(*.elg)|*.elg|所有文件(*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = true,
                SupportMultiDottedExtensions = true,
                Title = "批量导入",
                ValidateNames = true
            };
            string empty = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                empty = openFileDialog.FileName;
                string str = string.Empty;
                if (frmInputBox.Show("批量导入", "请输入导入文件密钥\r\n\r\n提示：您在批量导出时设置了这个密钥", "", true, 256, true, this, out str) == DialogResult.OK)
                {
                    XmlDocumentEx xmlDocumentEx = new XmlDocumentEx(str);
                    try
                    {
                        xmlDocumentEx.Load(empty);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(this, "导入文件密钥不正确，批量导入失败！", "批量导入", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.LoadConfig();
                        return;
                    }
                    XmlNodeList xmlNodeLists = xmlDocumentEx.DocumentElement.SelectNodes("UserInfo");
                    int num = 0;
                    int num1 = 0;
                    foreach (XmlNode xmlNodes in xmlNodeLists)
                    {
                        UserInfo userInfo = this.DecodeUserInfo(xmlNodes.InnerText);
                        if (!this.htUserInfo.ContainsKey(userInfo.UserName))
                        {
                            this.htUserInfo.Add(userInfo.UserName, userInfo);
                            this.cbUserName.Items.Add(userInfo);
                            XmlNode xmlNodes1 = this.xUserInfo.CreateElement("User");
                            xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("UserName")).Value = userInfo.UserName;
                            xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("Password")).Value = userInfo.Password;
                            xmlNodes1.Attributes.Append(this.xUserInfo.CreateAttribute("Alias")).Value = userInfo.Alias;
                            this.xUserInfo.DocumentElement.AppendChild(xmlNodes1);
                            this.xUserInfo.Save();
                            num++;
                        }
                        else
                        {
                            if (MessageBox.Show(this, string.Concat("已经存在账号 ", userInfo.GetDisplayName(), " 是否覆盖？"), "批量导入", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            {
                                continue;
                            }
                            this.cbUserName.Items.Remove(this.htUserInfo[userInfo.UserName]);
                            this.htUserInfo.Remove(userInfo.UserName);
                            this.htUserInfo.Add(userInfo.UserName, userInfo);
                            this.cbUserName.Items.Add(userInfo);
                            this.xUserInfo.DocumentElement.RemoveChild(this.xUserInfo.DocumentElement.SelectSingleNode(string.Concat("User[@UserName='", userInfo.UserName, "']")));
                            XmlNode xmlNodes2 = this.xUserInfo.CreateElement("User");
                            xmlNodes2.Attributes.Append(this.xUserInfo.CreateAttribute("UserName")).Value = userInfo.UserName;
                            xmlNodes2.Attributes.Append(this.xUserInfo.CreateAttribute("Password")).Value = userInfo.Password;
                            xmlNodes2.Attributes.Append(this.xUserInfo.CreateAttribute("Alias")).Value = userInfo.Alias;
                            this.xUserInfo.DocumentElement.AppendChild(xmlNodes2);
                            this.xUserInfo.Save();
                            num1++;
                        }
                    }
                    object[] objArray = new object[] { "导入成功！\r\n共新增 ", num.ToString(), " 条，更新 ", num1, " 条。" };
                    MessageBox.Show(this, string.Concat(objArray), "批量导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void 批量登录BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchLogin.Show(this.htUserInfo, (this.cmRunFrom.Checked ? this.csExeFileSelPath : "bin\\ExeFile.exe"), (this.cmLocalSettings.Checked ? "/noconsole /LUA:OFF /ssoToken=" : "/noconsole /ssoToken="), this.cmAutoMaxWindow.Checked, this);
        }

        private void 启动游戏后关闭登录器CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.启动游戏后关闭登录器CToolStripMenuItem.Checked = !this.启动游戏后关闭登录器CToolStripMenuItem.Checked;
            XmlNode str = this.xUserInfo.DocumentElement.SelectSingleNode("CloseAfterLaunch") ?? this.xUserInfo.DocumentElement.AppendChild(this.xUserInfo.CreateElement("CloseAfterLaunch"));
            str.InnerText = this.启动游戏后关闭登录器CToolStripMenuItem.Checked.ToString();
            this.xUserInfo.Save();
        }

        private void 清除计时器CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cbUserName.SelectedItem != null)
            {
                UserInfo selectedItem = (UserInfo)this.cbUserName.SelectedItem;
                selectedItem.SkillDeadLine = string.Empty;
                XmlElement documentElement = this.xUserInfo.DocumentElement;
                string[] userName = new string[] { "User[@UserName='", selectedItem.UserName, "'][@Password='", selectedItem.Password, "']" };
                XmlNode empty = documentElement.SelectSingleNode(string.Concat(userName));
                if (empty.Attributes["SkillDeadLine"] == null)
                {
                    empty.Attributes.Append(this.xUserInfo.CreateAttribute("SkillDeadLine")).Value = string.Empty;
                }
                else
                {
                    empty.Attributes["SkillDeadLine"].Value = string.Empty;
                }
                this.xUserInfo.Save();
            }
        }

        private void 设定计时器SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cbUserName.SelectedItem != null)
            {
                string empty = string.Empty;
                UserInfo selectedItem = (UserInfo)this.cbUserName.SelectedItem;
                if (frmTimer.Show(this, selectedItem.SkillDeadLine, out empty) == DialogResult.OK)
                {
                    selectedItem.SkillDeadLine = empty;
                    XmlElement documentElement = this.xUserInfo.DocumentElement;
                    string[] userName = new string[] { "User[@UserName='", selectedItem.UserName, "'][@Password='", selectedItem.Password, "']" };
                    XmlNode xmlNodes = documentElement.SelectSingleNode(string.Concat(userName));
                    if (xmlNodes.Attributes["SkillDeadLine"] == null)
                    {
                        xmlNodes.Attributes.Append(this.xUserInfo.CreateAttribute("SkillDeadLine")).Value = empty;
                    }
                    else
                    {
                        xmlNodes.Attributes["SkillDeadLine"].Value = empty;
                    }
                    this.xUserInfo.Save();
                }
            }
        }
    }
}
