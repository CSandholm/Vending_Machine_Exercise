using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine
{
    //Wallet holds the amount of each currency.
    internal class Wallet
    {
        Sound sound = new Sound();
        Stack<int> c1 = new Stack<int>();
        Stack<int> c2 = new Stack<int>();
        Stack<int> c3 = new Stack<int>();
        Stack<int> c4 = new Stack<int>();
        public void StartUp()
        {
            for(int i = 0; i < 10; i++)
            {
                c1.Push(1);
                c2.Push(5);
                c3.Push(10);
                c4.Push(20);
            }
        }
        //methods
        public void ViewWallet()
        {
            int total = 0;

            total = 1 * c1.Count + 5 * c2.Count + 10 * c3.Count + 20 * c4.Count;

            Console.WriteLine();
            Console.WriteLine("Your Wallet:");
            Console.WriteLine("$1 x" + c1.Count);
            Console.WriteLine("$5 x" + c2.Count);
            Console.WriteLine("$10 x" + c3.Count);
            Console.WriteLine("$20 x" + c4.Count);
            Console.WriteLine("Total: $" + total);
            Console.WriteLine();
        }
        public void Refund(int x)
        {
            int[] temp = new int[4];
            foreach(int i in temp)
                temp[i] = 0;
            //Receive money from the vending machine. Highest currency possible to lowest.
            do
            {
                if (x >= 20)
                {
                    c4.Push(20);
                    x -= 20;
                    temp[0]++;
                }
                else if (x >= 10)
                {
                    c3.Push(x);
                    x -= 10;
                    temp[1]++;
                }
                else if (x >= 5)
                {
                    c2.Push(x);
                    x -= 5;
                    temp[2]++;
                }
                else if(x > 0)
                {
                    c1.Push(x);
                    x -= 1;
                    temp[3]++;
                }
            } while (x > 0);
            Console.WriteLine("Refund: " + temp[0] +"x$20");
            Console.WriteLine("Refund: " + temp[1] +"x$10");
            Console.WriteLine("Refund: " + temp[2] +"x$5");
            Console.WriteLine("Refund: " + temp[3] +"x$1");
        }
        public int Update(int x, int y)
        {
            //Remove from corresponding currency stack and return the total value. Value that goes into the vending machine.
            int money = 0;
            
            if(x == 1 && 0 < y && y <= c1.Count)
            {
                PopLoop(y, c1);
            }
            else if (x == 2 && 0 < y && y <= c2.Count)
            {
                PopLoop(y, c2);
            }
            else if (x == 3 && 0 < y && y <= c3.Count)
            {
                PopLoop(y, c3);
            }
            else if (x == 4 && 0 < y && y <= c4.Count)
            {
                PopLoop(y, c4);
            }
            else
            {
                sound.S3();
                Console.WriteLine("Error!");
                Console.ReadLine();
                return 0;
            }
            sound.S1();
            return money;

            void PopLoop(int z, Stack<int> s)
            {
                for(int i = 0; i < z; i++)
                {
                    money += s.Peek();
                    s.Pop();
                }
            }
        }
    }
}
