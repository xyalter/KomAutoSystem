using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibEveFitting
{
    public class Hardware
    {
        public string Slot { get; set; }
        public string Type { get; set; }
        public int Qty { get; set; }

        public Hardware(XmlNode node)
        {
            Slot = node.Attributes["slot"].Value;
            Type = node.Attributes["type"].Value;
            if (node.Attributes["qty"] != null)
                Qty = Int32.Parse(node.Attributes["qty"].Value);
            else
                Qty = 1;
        }
    }
}
