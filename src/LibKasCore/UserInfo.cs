using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibKasCore
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password;
        public string Alias;
        public string UKey;
        private DateTime dtSkillDeadLine;
        public bool HasSkillSpan;

        public string SkillDeadLine
        {
            get
            {
                if (!this.HasSkillSpan)
                {
                    return string.Empty;
                }
                return this.dtSkillDeadLine.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.HasSkillSpan = false;
                    return;
                }
                this.dtSkillDeadLine = DateTime.Parse(value);
                this.HasSkillSpan = true;
            }
        }

        public string SkillSpan
        {
            get
            {
                if (!this.HasSkillSpan)
                {
                    return string.Empty;
                }
                TimeSpan now = this.dtSkillDeadLine - DateTime.Now;
                if (this.SkillHasExpired())
                {
                    return "技能已过期";
                }
                object[] days = new object[] { now.Days, "天", now.Hours, "小时", now.Minutes, "分", now.Seconds, "秒" };
                return string.Concat(days);
            }
        }

        public UserInfo(string pUserName, string pPassword, string pAlias, string pUKey)
        {
            this.UserName = pUserName;
            this.Password = pPassword;
            this.Alias = pAlias;
            this.UKey = pUKey;
        }

        public UserInfo()
        {
        }

        public void ClearSkillSpan()
        {
            this.HasSkillSpan = false;
        }

        public UserInfo Clone()
        {
            return new UserInfo(this.UserName, this.Password, this.Alias, this.UKey);
        }

        public string GetDisplayName()
        {
            string str = "";
            str = (string.IsNullOrEmpty(this.Alias) ? this.UserName : string.Concat(this.Alias, "(", this.UserName, ")"));
            if (this.HasSkillSpan)
            {
                str = string.Concat(str, " - ", this.SkillSpan);
            }
            return str;
        }

        public string GetDisplayNameOnly()
        {
            string str = "";
            str = (string.IsNullOrEmpty(this.Alias) ? this.UserName : string.Concat(this.Alias, "(", this.UserName, ")"));
            return str;
        }

        public bool IsUKey()
        {
            return !string.IsNullOrEmpty(this.UKey);
        }

        public bool SkillHasExpired()
        {
            if (!this.HasSkillSpan)
            {
                return false;
            }
            return (this.dtSkillDeadLine - DateTime.Now).TotalSeconds <= 0;
        }

        public override string ToString()
        {
            return this.GetDisplayName();
        }
    }
}
