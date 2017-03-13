using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class ClientRecordAccount : Account

    {
        public int ClientNumber { get; set; }
        public CheckingAccount Checking { get; set; }
        public int ChkAccountNumber { get; set; }
        public double ChkAccountBalance { get; set; }
        public SavingsAccount Savings { get; set; }
        public int SavAccountNumber { get; set; }
        public double SavAccountBalance { get; set; }
        public ReserveAccount Reserve { get; set; }
        public int ResAccountNumber { get; set; }
        public double ResAccountBalance { get; set; }

        public double TotalClientAssets
        {
            get { return this.ChkAccountBalance + this.SavAccountBalance + this.ResAccountBalance; }
        }

        public ClientRecordAccount(int clientNumber) : base("Client Account")
        {
            this.ClientNumber = clientNumber;
        }

        public override void Withdraw(double amount, StreamWriter stream)
        {
        }

        public override void Deposit(double amount, StreamWriter stream)
        {
        }

        public override void ShowBalance()
        {
            Console.WriteLine(TotalClientAssets);
        }

        public void ConnectAccounts(CheckingAccount chk, SavingsAccount sav, ReserveAccount res)
        {
            this.ChkAccountNumber = chk.AccountNumber;
            this.ChkAccountBalance = chk.AccountBalance;
            this.SavAccountNumber = sav.AccountNumber;
            this.SavAccountBalance = sav.AccountBalance;
            this.ResAccountNumber = res.AccountNumber;
            this.ResAccountBalance = res.AccountBalance;
        }

        public virtual void ViewClientInformation()
        {
            Console.WriteLine("Client Name: {0} {1}", ClientFirstName, ClientLastName);
            Console.WriteLine("Client Address: {0} {1}", ClientHouseNumber, ClientStreet);
            Console.WriteLine("                {0}, {1} {2}", ClientCity, ClientState, ClientZip);
            Console.WriteLine("Client Email: {0}", ClientEmail);
            Console.WriteLine("Client Phone Number: {0}", ClientPhone);
            Console.WriteLine();

            Console.WriteLine("Accounts with YouBank:");
            Console.WriteLine();
            Console.WriteLine("\tChecking Account #: {0}", ChkAccountNumber);
            Console.WriteLine("\tSavings Account #: {0}", SavAccountNumber);
            Console.WriteLine("\tReserve Account #: {0}", ResAccountNumber);
            
        }

    }


}
