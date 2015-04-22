using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HangarManager
{
    public class CheckLists
    {
        public CheckList this[string name]
        {
            get { return ((List<CheckList>)List).Find(x => x.Name.Equals(name)); }
        }

        //[XmlAttribute("List")]
        public List<CheckList> List { get; set; }
        public CheckLists() { List = new List<CheckList>(); }

        public void Add(CheckList item) { List.Add(item); }
        public void Clear() { List.Clear(); }
        public bool Contains(CheckList item) { return List.Contains(item); }
        public void CopyTo(CheckList[] array, int arrayIndex) { List.CopyTo(array, arrayIndex); }
        public int Count { get { return List.Count; } }
        public int IndexOf(CheckList item) { return List.IndexOf(item); }
        public void Insert(int index, CheckList item) { List.Insert(index, item); }
        //public bool IsReadOnly { get { return List.IsReadOnly; } }
        public bool Remove(CheckList item) { return List.Remove(item); }
        public void RemoveAt(int index) { List.RemoveAt(index); }
        public IEnumerator<CheckList> GetEnumerator() { return List.GetEnumerator(); }
        //IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)List).GetEnumerator(); }
        public CheckList this[int index] { get { return List[index]; } set { List[index] = value; } }
    }
}
