using System;
using System.Collections.Generic;
using System.Linq;


namespace Vendingmachines
{
    class VendingManager
    {
        public List<int> CoinList { get; set; }
        public List<Product> AvailableItems { get; set; }
        public List<Product> SelectedItems { get; set; }
        public int Balance { get; set; }
        public int ReturnChangevalue { get; set; }  

        public VendingManager()
        {
            CoinList = new List<int>();
            InitializeCoins();

            SelectedItems = new List<Product>();

            AvailableItems = new List<Product>();
            InitializeProductList();

        }

        public void InitializeCoins()
        {
            CoinList.Add(1);
            CoinList.Add(5);
            CoinList.Add(10);
            CoinList.Add(20);
            CoinList.Add(50);
            CoinList.Add(100);
            CoinList.Add(200);
            CoinList.Add(500);
            CoinList.Add(1000);
        }
        public void InitializeProductList()
        {
            Console.WriteLine("Food");
            Product pro = new Product("fish        ", 65);
            pro = new Product("sallad              ", 45);
            AvailableItems.Add(pro);
            pro = new Product("pasta               ", 45);
            AvailableItems.Add(pro);
            pro = new Product("sandiwch            ", 60);
            AvailableItems.Add(pro);
            pro = new Product("potato salad        ", 45);
            AvailableItems.Add(pro);
            pro = new Product("sushi               ", 45);
            AvailableItems.Add(pro);

            Console.WriteLine("Beverage");

            pro = new Product("Coca Cola           ", 25);
            AvailableItems.Add(pro);
            pro = new Product("Nestea Lemon        ", 18);
            AvailableItems.Add(pro);
            pro = new Product("Nestea Peach        ", 24);
            AvailableItems.Add(pro);
            pro = new Product("Tonic Water         ", 20);
            AvailableItems.Add(pro);
            pro = new Product("Sprite              ", 21);
            AvailableItems.Add(pro);
            pro = new Product("Ginger Ale          ", 27);
            AvailableItems.Add(pro);
           
            Console.WriteLine("Snack");
            pro = new Product("potato Chips        ", 18);
            AvailableItems.Add(pro);
            pro = new Product("Fruit Dip.          ", 20);
            AvailableItems.Add(pro);
            pro = new Product("Cheesy Chex Mix     ", 24);
            AvailableItems.Add(pro);
            pro = new Product("Caramel Popcorn.    ", 18);
            AvailableItems.Add(pro);
            pro = new Product("Sesame Potato Chips.", 30);
            AvailableItems.Add(pro);
            pro = new Product("Curry Potato Chips  ", 29);
            AvailableItems.Add(pro);

        }

        public void DisplayAvailableProductList()
        {
            Console.WriteLine("Article no.\tName\t\t\tPrice");
            foreach (var item in AvailableItems)
            {
                
                Console.WriteLine("{0}----\t{1}----\t{2}", AvailableItems.IndexOf(item) + 1, item.Name, item.Price);
            }

        }
        public void DisplayCurrentCredit()
        {
            Console.Write("\nYou have bought {0} items", SelectedItems.Count);
            Console.WriteLine("\nYou have {0} kr left", Balance);
           


        }

        public void InsertCoin(int coinValue)
        {
            Balance = Balance + coinValue;

        }
        public void UpdateSelectedArticles(int articleNo)
        {
            //Add selected item to the list
            Product article = AvailableItems[articleNo - 1];
            if (Balance >= article.Price)
            {
                SelectedItems.Add(article);
                Balance -= article.Price;
                
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe item you are trying to buy is too expensive!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nYou have no enough money to buy more product" +
                    " \nThank you for your purchase!");
            }

        }
       
        public void DisplaySelectedArticles()
        {
            Console.Write("\nYour items so far: ");
            foreach (var item in SelectedItems)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" \n {0} ", item.Name.Trim().ToUpper());
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
        public void BuyProducts()
        {
            int selectedArticle;
            DisplayAvailableProductList();

            Console.Write("\nSelect an article (End with 0): ");
            string articleString = Console.ReadLine();
            while (articleString != "0")
            {


                try
                {
                    selectedArticle = int.Parse(articleString);
                    //We are only goig to allow VALID integer numbers in a range defined by
                    //the total number of existing items inside the vending machine
                    //We are using the method "Count" on the list of items to get the maximum limit
                    //So we are basically saying that we only allow numbers from 1-6 (if the total of items in the list is 6)
                    if (selectedArticle > AvailableItems.Count || selectedArticle < 0)
                    {
                        Console.Write("\nWrite a VALID article number: ");
                    }
                    else
                    {
                        //We need to make a final check to see if the current credit is sufficient to
                        //allow the next purchase

                        UpdateSelectedArticles(selectedArticle);
                        DisplaySelectedArticles();
                        DisplayCurrentCredit();
                        Console.WriteLine("===========================================");
                        DisplayAvailableProductList();
                        Console.WriteLine("===========================================");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("\nWrite a VALID article number: ");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("\nArticle number too large: ");
                }
                Console.Write("Select an article (End with 0): ");
                articleString = Console.ReadLine();
            }

        }
    }
}

