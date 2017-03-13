using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    abstract class Account
    {
        #region properties and therefore fields
        public string ClientFirstName { get; set; } = "Russell";
        public string ClientLastName { get; set; } = "Petrus";
        public int ClientHouseNumber { get; set; } = 5555;
        public string ClientStreet { get; set; } = "West 25th Street";
        public string ClientCity { get; set; } = "Cleveland";
        public string ClientState { get; set; } = "Ohio";
        public int ClientZip { get; set; } = 44135;
        public string ClientEmail { get; set; } = "russpetrus@gmail.com";
        public string ClientPhone { get; set; } = "(216).533.2462";
        public int AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public string AccountType { get; set; }
        #endregion


        #region constructors
        public Account(string type)
        {
            this.AccountType = type;
        }
        #endregion


        #region methods
       
        public virtual void ShowBalance()
        {
            Console.WriteLine("Balance for account {0} {1}: ${2}", this.AccountType, this.AccountNumber, this.AccountBalance);
        }

        public virtual void WriteAccountInfo(StreamWriter stream) //taking a streamwriter as a parameter will allow flexibility for writing files, while still handling the writing in the methods. It also assisted in using streamwriter in the program with loops, etc.  
        {

            stream.WriteLine("Client Name: {0} {1}", ClientFirstName, ClientLastName);
            stream.WriteLine("Client Address: {0} {1}", ClientHouseNumber, ClientStreet);
            stream.WriteLine("                {0}, {1} {2}", ClientCity, ClientState, ClientZip);
            stream.WriteLine("Client Email: {0}", ClientEmail);
            stream.WriteLine("Client Phone Number: {0}", ClientPhone);
            stream.WriteLine();
            stream.WriteLine("Account Type: {0}", AccountType);
            stream.WriteLine("Account Number: {0}", AccountNumber);
            stream.WriteLine("Statement Period Beginning Balance: ${0}", AccountBalance);
            stream.WriteLine();
            stream.WriteLine();
        }

        public virtual void Deposit(double amount, StreamWriter stream)
        {
            DateTime timeStamp = DateTime.Now;
            this.AccountBalance += amount;

            Console.WriteLine("Transaction Time: {0}\nAccount Number: {1}\nDeposit: ${2}\nNew Balance: ${3}",
                timeStamp, AccountNumber, amount, AccountBalance);
            stream.WriteLine("{0} Deposit + ${1}. New balance: ${2} ", timeStamp, amount, AccountBalance);
        }

        public abstract void Withdraw(double amount, StreamWriter stream); //using an abstract method instead of virtual just to show that I know how

        #endregion

    }
}
