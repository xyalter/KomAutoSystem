using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomTest
{
    public class Role
    {
        public Role(string name) { Name = name; Status = RoleStatus.Offline; }
        public string Name { get; private set; }
        public RoleStatus Status { get; set; }
    }
}
