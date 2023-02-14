using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine
{
    //Product inherit the IProduct interface
    internal abstract class Product : IProduct
    {
        //properties
        public string Desc { get; }
        public string Name { get; }
        public bool Has { get; set; }
        public int Price { get; }

        //constructor
        public Product(string name, string desc, int price)
        {
            Name = name;
            Desc = desc;
            Price = price;
        }
        //methods
        //since we need to Buy() different things depending on the name, we let it be virtual
        public virtual void Buy()
        {
            Console.WriteLine($"Buying a {Name}");
        }
        //since the use method will be different depending on the type of product, it's abstract
        public abstract void Use();
    }
}
