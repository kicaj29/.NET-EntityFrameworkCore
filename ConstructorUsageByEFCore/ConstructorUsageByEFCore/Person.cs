using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorUsageByEFCore
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string SecondName { get; private set; }
        public string Address { get; private set; }

        private Person(string name)
        {
            // this.Id = id;
            this.Name = name;
            // this.SecondName = secondName;
            // this.Address = address;
        }
    }
}
