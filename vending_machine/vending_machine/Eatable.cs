using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine
{
    internal class Eatable : Product
    {
        public Eatable(string name, string desc, int price) : base(name, desc, price)
        {

        }
        public override void Use()
        {
            Console.WriteLine($"Eating the {Name}.");
        }
    }
}
