using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace SystemCenter
{
    public class EveHttpLogin
    {
        private const string csLoginUrl = "https://auth.eve-online.com.cn/oauth/authorize?client_id=eveclient&scope=eveClientLogin&response_type=token&redirect_uri=https%3A%2F%2Fauth.eve-online.com.cn%2Flauncher%3Fclient_id%3Deveclient&lang=zh";

        private const string csLoginPost = "https://auth.eve-online.com.cn/Account/LogOn?ReturnUrl=%2Foauth%2Fauthorize%3Fclient_id%3Deveclient%26scope%3DeveClientLogin%26response_type%3Dtoken%26redirect_uri%3Dhttps%253A%252F%252Fauth.eve-online.com.cn%252Flauncher%253Fclient_id%253Deveclient%26lang%3Dzh";

        private const string csLoninRetUrl = "https://auth.eve-online.com.cn/Account/LogOn?ReturnUrl=/oauth/authorize?client_id=eveclient&scope=eveClientLogin&response_type=token&redirect_uri=https%253A%252F%252Fauth.eve-online.com.cn%252Flauncher%253Fclient_id%253Deveclient&lang=zh";

        private const string csLoginTokenUrl = "https://auth.eve-online.com.cn/launcher?client_id=eveclient#access_token=";

        private const string csLoginEULA = "https://auth.eve-online.com.cn/OAuth/Eula";

        private const string csCharacterID = "https://api.eve-online.com.cn/eve/CharacterID.xml.aspx";

        private const string csCharacterInfo = "https://api.eve-online.com.cn/eve/CharacterInfo.xml.aspx";

        private string _USERNAME = "";

        private string _PASSWORD = "";

        private string _CAPTCHATOKEN = "";

        private string _CAPTCHA = "";

        private CookieContainer _COOKIES;

        private Regex regexValidation = new Regex("<div class=\"validation-summary-errors\">.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

        private Regex regexEULA = new Regex("<p class=\"title\">授权协议更新</p>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

        public string Captcha
        {
            get
            {
                return this._CAPTCHA;
            }
            set
            {
                this._CAPTCHA = value;
            }
        }

        public string CaptchaToken
        {
            get
            {
                return this._CAPTCHATOKEN;
            }
            set
            {
                this._CAPTCHATOKEN = value;
            }
        }

        public EveHttpLogin(string username, string password)
        {
            this._USERNAME = username;
            this._PASSWORD = password;
            this._COOKIES = new CookieContainer();
        }

        public bool AcceptEULA(string sEULAHash)
        {
            bool flag;
            HttpWebRequest requestCachePolicy = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Concat("eulaHash=", sEULAHash));
            stringBuilder.Append("&returnUrl=about:blank");
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(stringBuilder.ToString());
            try
            {
                try
                {
                    requestCachePolicy = (HttpWebRequest)WebRequest.Create("https://auth.eve-online.com.cn/OAuth/Eula");
                    requestCachePolicy.Timeout = 30000;
                    requestCachePolicy.AllowAutoRedirect = true;
                    requestCachePolicy.KeepAlive = false;
                    requestCachePolicy.Method = "POST";
                    requestCachePolicy.Referer = "https://auth.eve-online.com.cn/Account/LogOn?ReturnUrl=%2foauth%2fauthorize%3fclient_id%3deveclient%26scope%3deveClientLogin%26response_type%3dtoken%26redirect_uri%3dhttps%253A%252F%252Fauth.eve-online.com.cn%252Flauncher%253Fclient_id%253Deveclient%26lang%3dzh&client_id=eveclient&scope=eveClientLogin&response_type=token&redirect_uri=https%3A%2F%2Fauth.eve-online.com.cn%2Flauncher%3Fclient_id%3Deveclient&lang=zh";
                    requestCachePolicy.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    requestCachePolicy.ContentLength = bytes.LongLength;
                    requestCachePolicy.ContentType = "application/x-www-form-urlencoded";
                    requestCachePolicy.CookieContainer = this._COOKIES;
                    requestCachePolicy.ProtocolVersion = new Version("1.1");
                    requestCachePolicy.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)";
                    requestCachePolicy.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    requestCachePolicy.Headers.Add("Accept-Language: zh-CN");
                    requestCachePolicy.GetRequestStream().Write(bytes, 0, (int)bytes.Length);
                    response = (HttpWebResponse)requestCachePolicy.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    Console.WriteLine(streamReader.ReadToEnd());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    flag = false;
                    return flag;
                }
                return true;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return flag;
        }

        public static int GetCharacterID(string iName)
        {
            int num = -1;
            HttpWebRequest requestCachePolicy = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Concat("names=", iName));
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(stringBuilder.ToString());
            try
            {
                try
                {
                    requestCachePolicy = (HttpWebRequest)WebRequest.Create("https://api.eve-online.com.cn/eve/CharacterID.xml.aspx");
                    requestCachePolicy.Timeout = 30000;
                    requestCachePolicy.AllowAutoRedirect = true;
                    requestCachePolicy.KeepAlive = false;
                    requestCachePolicy.Method = "POST";
                    requestCachePolicy.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    requestCachePolicy.ContentLength = bytes.LongLength;
                    requestCachePolicy.ContentType = "application/x-www-form-urlencoded";
                    requestCachePolicy.ProtocolVersion = new Version("1.1");
                    requestCachePolicy.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)";
                    requestCachePolicy.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    requestCachePolicy.Headers.Add("Accept-Language: zh-CN");
                    requestCachePolicy.GetRequestStream().Write(bytes, 0, (int)bytes.Length);
                    response = (HttpWebResponse)requestCachePolicy.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    string end = streamReader.ReadToEnd();
                    Console.WriteLine(end);
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(end);
                    XmlNode xmlNodes = xmlDocument.DocumentElement.SelectSingleNode("result/rowset/row");
                    if (xmlNodes != null)
                    {
                        num = int.Parse(xmlNodes.Attributes["characterID"].Value);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return num;
        }

        public static string GetCharacterInfo(int iUserID)
        {
            HttpWebRequest requestCachePolicy = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StringBuilder stringBuilder = new StringBuilder();
            string innerText = "";
            stringBuilder.Append(string.Concat("characterID=", iUserID.ToString()));
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(stringBuilder.ToString());
            try
            {
                try
                {
                    requestCachePolicy = (HttpWebRequest)WebRequest.Create("https://api.eve-online.com.cn/eve/CharacterInfo.xml.aspx");
                    requestCachePolicy.Timeout = 30000;
                    requestCachePolicy.AllowAutoRedirect = true;
                    requestCachePolicy.KeepAlive = false;
                    requestCachePolicy.Method = "POST";
                    requestCachePolicy.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    requestCachePolicy.ContentLength = bytes.LongLength;
                    requestCachePolicy.ContentType = "application/x-www-form-urlencoded";
                    requestCachePolicy.ProtocolVersion = new Version("1.1");
                    requestCachePolicy.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)";
                    requestCachePolicy.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    requestCachePolicy.Headers.Add("Accept-Language: zh-CN");
                    requestCachePolicy.GetRequestStream().Write(bytes, 0, (int)bytes.Length);
                    response = (HttpWebResponse)requestCachePolicy.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    string end = streamReader.ReadToEnd();
                    Console.WriteLine(end);
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(end);
                    XmlNode xmlNodes = xmlDocument.DocumentElement.SelectSingleNode("result/characterName");
                    if (xmlNodes != null)
                    {
                        innerText = xmlNodes.InnerText;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return innerText;
        }

        private void GetLoginCookie()
        {
            HttpWebRequest version = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            try
            {
                try
                {
                    version = (HttpWebRequest)WebRequest.Create("https://auth.eve-online.com.cn/oauth/authorize?client_id=eveclient&scope=eveClientLogin&response_type=token&redirect_uri=https%3A%2F%2Fauth.eve-online.com.cn%2Flauncher%3Fclient_id%3Deveclient&lang=zh");
                    version.AllowAutoRedirect = true;
                    version.MaximumAutomaticRedirections = 1;
                    version.KeepAlive = false;
                    version.Method = "GET";
                    version.ProtocolVersion = new Version("1.1");
                    version.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)";
                    version.Accept = "*/*";
                    version.Headers.Add("Accept-Language: zh-CN");
                    version.CookieContainer = this._COOKIES;
                    response = (HttpWebResponse)version.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        public static bool GetServerStatus(out int iPlayers)
        {
            HttpWebResponse response = null;
            bool flag = true;
            int num = 0;
            StreamReader streamReader = null;
            try
            {
                try
                {
                    string end = null;
                    response = (HttpWebResponse)((HttpWebRequest)WebRequest.Create("https://api.eve-online.com.cn/server/ServerStatus.xml.aspx")).GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    end = streamReader.ReadToEnd();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(end);
                    flag = bool.Parse(xmlDocument.SelectSingleNode("eveapi/result/serverOpen").InnerText);
                    num = int.Parse(xmlDocument.SelectSingleNode("eveapi/result/onlinePlayers").InnerText);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            iPlayers = num;
            return flag;
        }

        public bool IsNeedCaptcha()
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse response = null;
            bool flag = true;
            StreamReader streamReader = null;
            try
            {
                try
                {
                    string end = null;
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat("https://captcha.tiancity.com:442/CheckSwitch.ashx?fid=100&uid=", this._USERNAME));
                    response = (HttpWebResponse)httpWebRequest.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    end = streamReader.ReadToEnd();
                    if (end.Trim() == "{\"R\":\"0\"}")
                    {
                        flag = false;
                    }
                    else if (end.Trim() != "{\"R\":\"1\"}")
                    {
                        flag = (end.Trim() != "{\"R\":\"-1\"}" ? false : true);
                    }
                    else
                    {
                        flag = true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return flag;
        }

        public bool Login(out string token, out string title, out string msg)
        {
            bool flag = false;
            HttpWebRequest requestCachePolicy = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StringBuilder stringBuilder = new StringBuilder();
            token = "";
            title = "";
            msg = "";
            stringBuilder.Append(string.Concat("UserName=", this._USERNAME));
            stringBuilder.Append(string.Concat("&Password=", this._PASSWORD));
            stringBuilder.Append(string.Concat("&CaptchaToken=", this._CAPTCHATOKEN));
            stringBuilder.Append(string.Concat("&Captcha=", this._CAPTCHA));
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(stringBuilder.ToString());
            this.GetLoginCookie();
            try
            {
                try
                {
                    requestCachePolicy = (HttpWebRequest)WebRequest.Create("https://auth.eve-online.com.cn/Account/LogOn?ReturnUrl=%2Foauth%2Fauthorize%3Fclient_id%3Deveclient%26scope%3DeveClientLogin%26response_type%3Dtoken%26redirect_uri%3Dhttps%253A%252F%252Fauth.eve-online.com.cn%252Flauncher%253Fclient_id%253Deveclient%26lang%3Dzh");
                    requestCachePolicy.Timeout = 30000;
                    requestCachePolicy.AllowAutoRedirect = true;
                    requestCachePolicy.KeepAlive = false;
                    requestCachePolicy.Method = "POST";
                    requestCachePolicy.Referer = "https://auth.eve-online.com.cn/Account/LogOn?ReturnUrl=%2foauth%2fauthorize%3fclient_id%3deveclient%26scope%3deveClientLogin%26response_type%3dtoken%26redirect_uri%3dhttps%253A%252F%252Fauth.eve-online.com.cn%252Flauncher%253Fclient_id%253Deveclient%26lang%3dzh&client_id=eveclient&scope=eveClientLogin&response_type=token&redirect_uri=https%3A%2F%2Fauth.eve-online.com.cn%2Flauncher%3Fclient_id%3Deveclient&lang=zh";
                    requestCachePolicy.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    requestCachePolicy.ContentLength = bytes.LongLength;
                    requestCachePolicy.ContentType = "application/x-www-form-urlencoded";
                    requestCachePolicy.ProtocolVersion = new Version("1.1");
                    requestCachePolicy.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)";
                    requestCachePolicy.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    requestCachePolicy.Headers.Add("Accept-Language: zh-CN");
                    requestCachePolicy.CookieContainer = this._COOKIES;
                    requestCachePolicy.GetRequestStream().Write(bytes, 0, (int)bytes.Length);
                    response = (HttpWebResponse)requestCachePolicy.GetResponse();
                    Console.WriteLine(response.ResponseUri.ToString());
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    string end = streamReader.ReadToEnd();
                    Console.WriteLine(end);
                    if (this.regexEULA.IsMatch(end))
                    {
                        Regex regex = new Regex("<h3>.+?</h3>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
                        Regex regex1 = new Regex("<div class=\"overview\">.+?</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
                        Regex regex2 = new Regex("<input id=\"eulaHash\" name=\"eulaHash\" type=\"hidden\" value=\".+?\" />", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
                        title = "授权协议更新";
                        msg = string.Concat(regex2.Match(end).Value.Replace("<input id=\"eulaHash\" name=\"eulaHash\" type=\"hidden\" value=\"", "").Replace("\" />", ""), "|", regex1.Match(end).Value.Replace("<b>", "").Replace("</b>", "").Replace("<div class=\"overview\">", "").Replace("</div>", "").Replace("<h3>", "").Replace("<center>", "").Replace("</h3>", "").Replace("</center>", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("<br>", "\r\n"));
                        token = "";
                        flag = true;
                    }
                    else if (response.ResponseUri.ToString().StartsWith("https://auth.eve-online.com.cn/Account/LogOn?ReturnUrl=/oauth/authorize?client_id=eveclient&scope=eveClientLogin&response_type=token&redirect_uri=https%253A%252F%252Fauth.eve-online.com.cn%252Flauncher%253Fclient_id%253Deveclient&lang=zh", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (!this.regexValidation.IsMatch(end))
                        {
                            title = "未知错误";
                            msg = "无法获取报错信息，请联系老鼠大人！";
                        }
                        else
                        {
                            string str = this.regexValidation.Match(end).Value.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                            string[] strArrays = new string[] { "<span>", "</span>", "<li>", "</li>" };
                            string[] strArrays1 = str.Split(strArrays, StringSplitOptions.None);
                            title = strArrays1[1];
                            msg = strArrays1[3];
                        }
                        flag = false;
                    }
                    else if (response.ResponseUri.ToString().StartsWith("https://auth.eve-online.com.cn/launcher?client_id=eveclient#access_token=", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string str1 = response.ResponseUri.ToString();
                        char[] chrArray = new char[] { '?' };
                        string str2 = str1.Split(chrArray)[1];
                        char[] chrArray1 = new char[] { '&' };
                        string str3 = str2.Split(chrArray1)[0];
                        char[] chrArray2 = new char[] { '=' };
                        token = str3.Split(chrArray2)[2];
                        flag = true;
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    title = "系统错误";
                    msg = exception.Message;
                    flag = false;
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return flag;
        }
    }
}