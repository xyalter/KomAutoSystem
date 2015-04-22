using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HangarManager
{
    public class Parser
    {
        public static IList<CheckItem> GetCheckItems(string data)
        {
            data = data.Replace("高能量", "");
            data = data.Replace("中级能量", "");
            data = data.Replace("低能量", "");
            data = data.Replace("改装件插槽", "");
            data = data.Replace("子系统", "");
            data = data.Replace("弹药", "");
            data = data.Replace("无人机", "");
            data = data.Replace(",", "");
            string[] rows = data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            IList<CheckItem> result = new List<CheckItem>(rows.Length);
            try
            {
                foreach (string str in rows)
                {
                    string[] row = str.Split(new string[] { "x " }, StringSplitOptions.RemoveEmptyEntries);
                    result.Add(new CheckItem() { Name = row[1], Limit = Convert.ToInt32(row[0]) });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "数据异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
