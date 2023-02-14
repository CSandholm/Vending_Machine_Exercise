using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine
{
    internal interface IProduct
    {
        //Properties
        string Desc
        {get;}
        string Name
        {get;}
        int Price
        {get;}
        bool Has
        {get;
         set;}
        //Methods
        public void Use();
        public void Buy();
    }
}
