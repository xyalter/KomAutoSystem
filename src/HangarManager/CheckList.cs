using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HangarManager
{
    public class CheckList
    {
        public string Name { get; set; }

        public CheckItem this[string name] { get { return List.Find(x => x.Name.Equals(name)); } }

        public List<CheckItem> List { get; set; }
        public CheckList() { List = new List<CheckItem>(); }

        public void Add(CheckItem item) { List.Add(item); }
        public void Clear() { List.Clear(); }
        public bool Contains(CheckItem item) { return List.Contains(item); }
        public void CopyTo(CheckItem[] array, int arrayIndex) { List.CopyTo(array, arrayIndex); }
        public int Count { get { return List.Count; } }
        public int IndexOf(CheckItem item) { return List.IndexOf(item); }
        public void Insert(int index, CheckItem item) { List.Insert(index, item); }
        //public bool IsReadOnly { get { return List.IsReadOnly; } }
        public bool Remove(CheckItem item) { return List.Remove(item); }
        public void RemoveAt(int index) { List.RemoveAt(index); }
        public IEnumerator<CheckItem> GetEnumerator() { return List.GetEnumerator(); }
        //IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)List).GetEnumerator(); }
        public CheckItem this[int index] { get { return List[index]; } set { List[index] = value; } }
    }
}
