namespace vending_machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConOpt con = new ConOpt();
            Sound sound = new Sound();
            Wallet wallet = new Wallet();

            IProduct[] products = ProductList();
            
            int money = 0;
            bool showMenu = true;

            con.StartUp();
            wallet.StartUp();

            while (showMenu)
            {
                showMenu = MainMenu();
            }

            bool MainMenu()
            {
                Console.Clear();
                wallet.ViewWallet();

                Console.WriteLine("******************** The Vending Machine ********************");
                Console.WriteLine("*********** First add Money, then choose a product **********");
                Console.WriteLine("*************************************************************");
                for(int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine(i+1 + ": " + products[i].Name + " $" + products[i].Price);
                }
                Console.WriteLine();
                Console.WriteLine("0: Add Money");
                Console.WriteLine("i: Inventory");
                Console.WriteLine("c: Cancel & Refund");
                Console.WriteLine("e: Exit");
                Console.WriteLine();
                Console.WriteLine("Money in the vending machine: $" + money);
                Console.WriteLine("*************************************************************");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "c":
                        sound.S2();
                        Cancel();
                        return true;
                    case "0":
                        sound.S1();
                        MoneyMenu();
                        return true;
                    case "i":
                        sound.S1();
                        Inventory(products);
                        return true;
                    case "e":
                        sound.S1();
                        Cancel();
                        return false;
                    default:
                        BuyMenu(products, input);
                        return true;
                }
            }
            void MoneyMenu()
            {
                //User choose currency and amount of that currency.
                //Wallets pop-method is called to remove money from the wallet and return the amount to the machines money
                Console.WriteLine("First choose the currency you'd like to add.");
                Console.WriteLine("1: $1, 2: $5, 3: $10, 4: $20");

                string input = Console.ReadLine();
                int x;
                int y;

                if (Int32.TryParse(input, out x))
                {
                    if (x < 1 || x > 4)
                    {
                        sound.S3();
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        sound.S1();
                        Console.WriteLine("How many do you wish to use?");
                        input = Console.ReadLine();
                        if (Int32.TryParse(input, out y))
                        {
                            money += wallet.Update(x, y);
                        }
                        else
                            sound.S3();
                    }
                }
                else
                    sound.S3();
            }
            void BuyMenu(IProduct[] products, string input)
            {
                //Check if the input is valid, show description of the product and give the choice to buy it.
                //Won't let you by a second of the same item

                int x = -1;

                if(Int32.TryParse(input,out x))
                {
                    x = x - 1;
                    if (x < products.Length && x >= 0)
                    {
                        sound.S1();
                        Console.WriteLine($"You've chosen the " + products[x].Name);
                        Console.WriteLine(products[x].Desc);
                        Console.WriteLine($"Buy? (y/n)");
                        switch (Console.ReadLine())
                        {
                            case "y":
                                if (money >= products[x].Price)
                                {
                                    if (products[x].Has)
                                    {
                                        sound.S2();
                                        Console.WriteLine("You already have: " + products[x].Name);
                                    }
                                    else
                                    {
                                        sound.S1();
                                        products[x].Buy();
                                        products[x].Has = true;
                                        money -= products[x].Price;
                                    }
                                }
                                else
                                {
                                    sound.S3();
                                    Console.WriteLine("Insufficient funds!");
                                }
                                EnterToContinue();
                                break;
                            case "n":
                                sound.S2();
                                break;
                            default:
                                sound.S3();
                                break;
                        }
                    }
                }
                else
                {
                    sound.S3();
                    Console.WriteLine("Invalid input!");
                }
            }

            void Inventory(IProduct[] products)
            {
                //Writes what user have bought and gives the option to use the item

                bool hasItem = false;

                foreach (IProduct product in products)
                {
                    if (product.Has)
                    {
                        hasItem = true;
                        Console.WriteLine("You have: " + product.Name);
                        Console.WriteLine("Use item? (y/n)");
                        switch (Console.ReadLine())
                        {
                            case "y":
                                sound.S1();
                                product.Use();
                                product.Has = false;
                                EnterToContinue();
                                break;
                            case "n":
                                sound.S2();
                                break;
                            default :
                                sound.S3();
                                break;
                        }
                    }
                }
                if (!hasItem)
                {
                    Console.WriteLine("You don't have any items.");
                    EnterToContinue();
                }
            }

            void Cancel()
            {
                //removes money from the vending machine and refund to wallet
                wallet.Refund(money);
                Console.WriteLine("Refund total: $" + money);
                EnterToContinue();
                money = 0;
            }
            //Fill IProduct array with buyable products
            static IProduct[] ProductList()
            {
                return new IProduct[]
                {
                    new Eatable("Fresh Fish","It's a... pike?", 10),
                    new Eatable("Choco Bar", "Choclate bar with nuts.", 5),
                    new Eatable("Borscht", "A suspicious can of Borscht soup.", 16),

                    new Wearable("Cap", "90's NHL Cap.", 15),
                    new Wearable("Sweater", "Ugly christmas sweater. Questionable quiality.", 33),
                    new Wearable("Gloves", "A pair of black gloves.", 6),

                    new Smashable("Vase", "A very smashable vase.", 199),
                    new Smashable("Phone", "Smashable phone. We've all felt it, and this one is MADE for it.", 99),
                    new Smashable("Bottle", "A regular, boring glas bottle. Made for smashing.", 1)
                };
            }
            void EnterToContinue()
            {
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
