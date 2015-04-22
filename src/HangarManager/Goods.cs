using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HangarManager
{
    public class Goods
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Limit { get; set; }
        public string Group { get; set; }
        public string Size { get; set; }
        public string Slot { get; set; }
        public float Volume { get; set; }

        public Goods() { }

        public Goods(string[] data)
        {
            try
            {
                Name = data[0];
                string tmp = data[1].Replace(",", "");
                if (tmp.Equals(""))
                    Count = 1;
                else
                    Count = Convert.ToInt32(tmp);
                Group = data[2];
                Size = data[3];
                Slot = data[4];
                Volume = Convert.ToSingle(data[5].Replace(",", ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "数据异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
