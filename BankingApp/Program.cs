using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare additional variables for user interaction
            int mainMenuChoice;
            int optionToContinue;

            //instantiate the usermenu (created menu methods in MenuOperations class to help keep this code readable)
            MenuOperations menu = new MenuOperations();
            
            //open streams
            StreamWriter writeToChecking = new StreamWriter("CheckingAccountSummary.txt");
            StreamWriter writeToSavings = new StreamWriter("SavingsAccountSummary.txt");
            StreamWriter writeToReserve = new StreamWriter("ReserveAccountSummary.txt");
            
            //instantiate new accounts and write basic account information to txt file
            ClientRecordAccount ClientPetrus = new ClientRecordAccount(0056);//client record account is one place to keep track of all client information

            CheckingAccount checkingAccount = new CheckingAccount(1234, 3450.27);
            using (writeToChecking)
            {
                checkingAccount.WriteAccountInfo(writeToChecking);
            }

            SavingsAccount savingsAccount = new SavingsAccount(4321, 10000.00);
            using (writeToSavings)
            {
                savingsAccount.WriteAccountInfo(writeToSavings);
            }

            ReserveAccount reserveAccount = new ReserveAccount(5467, 8000.00);
            using (writeToReserve)
            {
                reserveAccount.WriteAccountInfo(writeToReserve);
            }

            //connect all user accounts into the ClientRecordAccount (not necessary, but seems useful)
            ClientPetrus.ConnectAccounts(checkingAccount, savingsAccount, reserveAccount);

            //begin user interaction and display welcome screen
            menu.WelcomeScreen();

            do
            {
                //open new streams within at the beginning of loop to write transaction details to the txt file without overwriting the information from previous write
                StreamWriter writeCheckingAccountSummary = new StreamWriter("CheckingAccountSummary.txt", true);
                StreamWriter writeSavingsAccountSummary = new StreamWriter("SavingsAccountSummary.txt", true);
                StreamWriter writeReserveAccountSummary = new StreamWriter("ReserveAccountSummary.txt", true);


                //display user main menu
                mainMenuChoice = menu.MainMenu();

                switch (mainMenuChoice)
                {
                    case 1: //display client information 
                        ClientPetrus.ViewClientInformation();
                        break;

                    case 2:// balance: ask for account then display balance
                        int accountForBalance = menu.AccountMenu("to view balance of");

                        if (accountForBalance == 1)
                        {
                            checkingAccount.ShowBalance();
                        }
                        if (accountForBalance == 2)
                        {
                            savingsAccount.ShowBalance();
                        }
                        if (accountForBalance == 3)
                        {
                            reserveAccount.ShowBalance();
                        }
                        if (accountForBalance == 4)
                        {
                            menu.Exit();
                        }
                        break;

                    case 3: //deposit: ask for the account, ask for an amount, then complete deposit
                        int depositAccount = menu.AccountMenu("to deposit into");
                        double depositAmount = menu.GetAmount("deposit");

                        if (depositAccount == 1)
                        {
                            checkingAccount.Deposit(depositAmount, writeCheckingAccountSummary);
                        }
                        if (depositAccount == 2)
                        {
                            savingsAccount.Deposit(depositAmount, writeSavingsAccountSummary);
                        }
                        if (depositAccount == 3)
                        {
                            reserveAccount.Deposit(depositAmount, writeReserveAccountSummary);
                        }
                        if (depositAccount == 4)
                        {
                            menu.Exit();
                        }
                        break;

                    case 4://withdrawal: ask for account, then ask for amount, then complete the withdrawal
                        int withdrawalAccount = menu.AccountMenu("to withdraw from");
                        double withdrawAmount = menu.GetAmount("withdraw");

                        if (withdrawalAccount == 1)
                        {
                            checkingAccount.Withdraw(withdrawAmount, writeCheckingAccountSummary);
                        }
                        if (withdrawalAccount == 2)
                        {
                            savingsAccount.Withdraw(withdrawAmount, writeSavingsAccountSummary);
                        }
                        if (withdrawalAccount == 3)
                        {
                            reserveAccount.Withdraw(withdrawAmount, writeReserveAccountSummary);
                        }
                        if (withdrawalAccount == 4)
                        {
                            menu.Exit();
                        }
                        break;

                    case 5://exit
                        menu.Exit();
                        break;

                    default: //should not run, but here in case
                        Console.WriteLine("Your transaction cannot be completed at this time. We are sorry for the inconvenience.");
                        Environment.Exit(0);
                        break;
                }
                
                //close streams to write transaction to txt file. reopens at top if loop is rerun
                writeCheckingAccountSummary.Close();
                writeSavingsAccountSummary.Close();
                writeReserveAccountSummary.Close();

                Console.WriteLine();
                Console.WriteLine("***Your transaction is complete. Press any key to continue.***");
                Console.ReadKey();
                Console.Clear();

                //ask the user if they would like to make another transaction

                optionToContinue = menu.AskToContinue();
                Console.Clear();

            }
            while (optionToContinue == 1); //this ends the do-while loop begun at the top
        
            Console.WriteLine("Thank you for banking with us today. Good bye.");
            Environment.Exit(0);

            
        }
    }
}
