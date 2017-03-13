using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class MenuOperations
    {

        public void WelcomeScreen()
        {
            Console.WriteLine("Welcome to YouBank...where YOU come first!");
            Console.WriteLine("******************************************");
            Console.WriteLine();
        }

        public int MainMenu() // returns an int to be evaluated in the program main to choose an operation to execute (method call)
        {
            int choice;

            Console.WriteLine("Please Choose An Option from the Menu:");
            Console.WriteLine("\tPress 1 to view your information");
            Console.WriteLine("\tPress 2 view an account balance");
            Console.WriteLine("\tPress 3 to make a deposit");
            Console.WriteLine("\tPress 4 to make a withdrawal");
            Console.WriteLine("\tPress 5 to exit");

            choice = int.Parse(Console.ReadLine());
            Console.Clear();

            while (choice < 1 || choice > 5)
            {
                Console.WriteLine("That is not a valid choice. Please choose from the options below:");
                Console.WriteLine("\tPress 1 to view your information");
                Console.WriteLine("\tPress 2 view an account balance");
                Console.WriteLine("\tPress 3 to make a deposit");
                Console.WriteLine("\tPress 4 to make a withdrawal");
                Console.WriteLine("\tPress 5 to exit");

                choice = int.Parse(Console.ReadLine());
                Console.Clear();
            }

            return choice;

        }


        public int AccountMenu(string transactionDescription) // returns an int to evaluate in the program main to determine which account to call the method upon. Parameter is for user experience. 
        {
            int accountMenuChoice;
            Console.WriteLine("Please Select an Account {0}:", transactionDescription);
            Console.WriteLine();
            Console.WriteLine("\tPress 1 for Checking");
            Console.WriteLine("\tPress 2 for Savings");
            Console.WriteLine("\tPress 3 for Reserve");
            Console.WriteLine("\tor Press 4 to Exit");

            accountMenuChoice = int.Parse(Console.ReadLine());
            Console.Clear();

            while (accountMenuChoice < 1 || accountMenuChoice > 4)
            {
                Console.WriteLine("That is not a valid selection. Please choose an account:");
                Console.WriteLine();
                Console.WriteLine("\tPress 1 for Checking");
                Console.WriteLine("\tPress 2 for Savings");
                Console.WriteLine("\tPress 3 for Reserve");
                Console.WriteLine("\tor press 4 to exit");
                accountMenuChoice = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            return accountMenuChoice;
        }

        public double GetAmount(string withdrawOrDeposit)//asks the user for and returns an amount to deposit or withdraw. Paramater is for user experience only.
        {
            string operation = withdrawOrDeposit;
            Console.WriteLine("Enter the amount you would you like to {0}, exluding the $.", operation);
            double amount = double.Parse(Console.ReadLine());
            return amount;
        }

        public int AskToContinue()
        {
            Console.WriteLine("Would you like another transaction?");
            Console.WriteLine("\t Press 1 to make another transaction");
            Console.WriteLine("\t Press 2 if you are finished.");
            int optionToContinue = int.Parse(Console.ReadLine());

            while (optionToContinue != 1 && optionToContinue != 2)
            {
                Console.WriteLine("I'm sorry, that is not a valid choice.");
                Console.WriteLine("Would you like another transaction?");
                Console.WriteLine("\t Press 1 to make another transaction");
                Console.WriteLine("\t Press 2 if you are finished.");
                optionToContinue = int.Parse(Console.ReadLine());
            }

            return optionToContinue;
        }

        public void Exit()
        {
            Console.WriteLine("Your transaction has been cancelled. The program will now close. Press any key to continue.");
            Environment.Exit(0);
        }

    }
}
