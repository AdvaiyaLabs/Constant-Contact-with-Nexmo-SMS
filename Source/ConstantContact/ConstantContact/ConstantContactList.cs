using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantContact
{
    class ConstantContactList
    {
        public ConstantContactList(string _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
