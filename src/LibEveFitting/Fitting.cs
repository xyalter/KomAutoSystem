using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibEveFitting
{
    public class Fitting
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShipType { get; set; }
        public List<Hardware> Hardwares { get; set; }
        public List<Hardware> HardwaresSum { get; set; }

        public Fitting(XmlNode node)
        {
            Name = node.Attributes["name"].Value;
            Description = node.SelectSingleNode("description").Attributes["value"].Value;
            ShipType = node.SelectSingleNode("shipType").Attributes["value"].Value;
            Hardwares = new List<Hardware>();
            XmlNodeList list = node.SelectNodes("hardware");
            foreach (XmlNode child in list)
                Hardwares.Add(new Hardware(child));
            HardwaresSum = new List<Hardware>();
            foreach (Hardware hard in Hardwares)
                if (HardwaresSum.Exists((x) => x.Type.Equals(hard.Type)))
                    HardwaresSum.Single((x) => x.Type.Equals(hard.Type)).Qty += hard.Qty;
                else
                    HardwaresSum.Add(hard);
        }
    }
}
