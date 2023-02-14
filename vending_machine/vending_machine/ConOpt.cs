using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine
{
    internal class ConOpt
    {
        public void StartUp()
        {
            //Gives the console window color & a new title
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "The Vending Machine Superb";
        }
    }
}
