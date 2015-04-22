using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemCenter
{
    internal class PasswordLevelKit
    {
        public PasswordLevelKit()
        {
        }

        public static PasswordLevelKit.PasswordLevel GetPasswordLevel(string paswword)
        {
            int passwordScore = PasswordLevelKit.GetPasswordScore(paswword);
            if (passwordScore >= 0 && passwordScore < 20)
            {
                return PasswordLevelKit.PasswordLevel.Very_Week;
            }
            if (passwordScore >= 20 && passwordScore < 40)
            {
                return PasswordLevelKit.PasswordLevel.Week;
            }
            if (passwordScore >= 40 && passwordScore < 60)
            {
                return PasswordLevelKit.PasswordLevel.Good;
            }
            if (passwordScore >= 60 && passwordScore < 80)
            {
                return PasswordLevelKit.PasswordLevel.Strong;
            }
            if (passwordScore >= 80)
            {
                return PasswordLevelKit.PasswordLevel.Very_Strong;
            }
            return PasswordLevelKit.PasswordLevel.None;
        }

        public static int GetPasswordScore(string password)
        {
            password = (new Regex("\\s+")).Replace(password, "");
            if (password.Length == 0)
            {
                return 0;
            }
            string lower = password.ToLower();
            int num = 0;
            int length = password.Length;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            for (int i = 0; i < length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    if (num13 != 0 && num13 + 1 == i)
                    {
                        num8++;
                    }
                    num13 = i;
                    num1++;
                }
                else if (char.IsLower(password[i]))
                {
                    if (num14 != 0 && num14 + 1 == i)
                    {
                        num9++;
                    }
                    num14 = i;
                    num2++;
                }
                else if (!char.IsNumber(password[i]))
                {
                    if (i > 0 && i < length - 1)
                    {
                        num5++;
                    }
                    num4++;
                }
                else
                {
                    if (i > 0 && i < length - 1)
                    {
                        num5++;
                    }
                    if (num15 != 0 && num15 + 1 == i)
                    {
                        num10++;
                    }
                    num15 = i;
                    num3++;
                }
                for (int j = 0; j < length; j++)
                {
                    if (i != j && lower[i].Equals(lower[j]))
                    {
                        num7++;
                    }
                }
            }
            string str = "abcdefghijklmnopqrstuvwxyz";
            string str1 = "01234567890";
            int num16 = 3;
            for (int k = 0; k < str.Length - num16; k++)
            {
                string str2 = str.Substring(k, num16);
                char[] charArray = str2.ToCharArray();
                Array.Reverse(charArray);
                if (lower.IndexOf(str2) != -1 || lower.IndexOf(charArray.ToString()) != -1)
                {
                    num11++;
                }
            }
            for (int l = 0; l < str1.Length - num16; l++)
            {
                string str3 = str1.Substring(l, num16);
                char[] chrArray = str3.ToCharArray();
                Array.Reverse(chrArray);
                if (lower.IndexOf(str3) != -1 || lower.IndexOf(chrArray.ToString()) != -1)
                {
                    num12++;
                }
            }
            num = num + length * 4;
            num = num + num1 * 2;
            num = num + num2 * 2;
            num = num + num3 * 4;
            num = num + num4 * 6;
            num = num + num5 * 2;
            if (num1 > 0)
            {
                num6++;
            }
            if (num2 > 0)
            {
                num6++;
            }
            if (num3 > 0)
            {
                num6++;
            }
            if (num4 > 0)
            {
                num6++;
            }
            if (length >= 8 && num6 >= 3)
            {
                num = num + (num6 + 1) * 2;
            }
            if ((num2 > 0 || num1 > 0) && num4 == 0 && num3 == 0)
            {
                num = num - length;
            }
            if (num2 == 0 && num1 == 0 && num4 == 0 && num3 > 0)
            {
                num = num - length;
            }
            num = num - num7 * (num7 - 1);
            num = num - num8 * 2;
            num = num - num9 * 2;
            num = num - num10 * 2;
            num = num - num11 * 3;
            num = num - num12 * 3;
            if (num < 0)
            {
                num = 0;
            }
            if (num > 100)
            {
                num = 100;
            }
            return num;
        }

        public enum PasswordLevel
        {
            None,
            Very_Week,
            Week,
            Good,
            Strong,
            Very_Strong
        }
    }
}
