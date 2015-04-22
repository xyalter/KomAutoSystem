using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibEveFitting
{
    public class Fittings
    {
        public Fitting this[string name]
        {
            get { return ((List<Fitting>)List).Find(x => x.Name.Equals(name)); }
        }

        public List<Fitting> List { get; set; }
        public Fittings() { List = new List<Fitting>(); }
        public Fittings(string name)
        {
            List = new List<Fitting>();
            XmlDocument doc=new XmlDocument();
            doc.Load(name);
            XmlNodeList nodes = doc.SelectSingleNode("fittings").SelectNodes("fitting");
            foreach (XmlNode node in nodes)
                List.Add(new Fitting(node));
        }

        public void Add(Fitting item) { List.Add(item); }
        public void Clear() { List.Clear(); }
        public bool Contains(Fitting item) { return List.Contains(item); }
        public void CopyTo(Fitting[] array, int arrayIndex) { List.CopyTo(array, arrayIndex); }
        public int Count { get { return List.Count; } }
        public int IndexOf(Fitting item) { return List.IndexOf(item); }
        public void Insert(int index, Fitting item) { List.Insert(index, item); }
        //public bool IsReadOnly { get { return List.IsReadOnly; } }
        public bool Remove(Fitting item) { return List.Remove(item); }
        public void RemoveAt(int index) { List.RemoveAt(index); }
        public IEnumerator<Fitting> GetEnumerator() { return List.GetEnumerator(); }
        //IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)List).GetEnumerator(); }
        public Fitting this[int index] { get { return List[index]; } set { List[index] = value; } }

        public void Merge(string name) { Merge(new Fittings(name)); }
        public void Merge(Fittings fittings) { foreach (Fitting fitting in fittings.List) { List.Add(fitting); } }
    }
}
