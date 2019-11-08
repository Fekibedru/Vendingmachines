using System;
using System.Collections.Generic;


namespace Vendingmachines 
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInput;
       
            int userInputValue;
            
            VendingManager vm = new VendingManager();
            Console.WriteLine();
            Console.Write(" Welcome to our vending machine to buy products!");
            Console.Write("\nInsert a valid coin please: ");
            userInput = Console.ReadLine();
           

            while (userInput != "0" )
            {
                //your code goes here...
                
                    userInputValue = int.Parse(userInput);
                  vm.InsertCoin(userInputValue);
                    Console.Write("Insert a coin please: ");
                    userInput = Console.ReadLine();
 
            }

            if (vm.Balance < 1)
            {
                Console.WriteLine("You have no money to buy products");
                Console.Read();
                return;
            }

            else
            {
                Console.WriteLine("\nYour current balance is {0}", vm.Balance);
              
            }
            Console.WriteLine(" \nSelect Product Type from the list: ");
            Console.WriteLine("=========================================");
            vm.BuyProducts();
            Console.WriteLine("=========================================");

            Console.Read();
        }
    }
}
