using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine
{
    //For an interactive feel, the app playes a sound based on type of choice.
    internal class Sound
    {
        public void S1()
        {
            Console.Beep();
        }
        public void S2()
        {
            Console.Beep();
            Console.Beep();
        }
        public void S3()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
        }
    }
}
