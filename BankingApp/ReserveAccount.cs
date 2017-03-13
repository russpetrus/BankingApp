using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class ReserveAccount : Account
    {

        #region properties and fields
        public double autoTransferAmount { get; set; } = 250.00;
        public Account connectedAccount { get; set; }
        #endregion

        #region constructors
        public ReserveAccount(int accountNumber, double balance) : base("Reserve Account")
        {
            this.AccountNumber = accountNumber;
            this.AccountBalance = balance;
        }
        #endregion


        #region methods
        public override void Withdraw(double amount, StreamWriter stream)
        {
            DateTime timeStamp = DateTime.Now;
            AccountBalance -= amount;
            Console.WriteLine("Transaction Time: {0}\nAccount Number: {1}\nWithdrawal: ${2}\nNew Balance: ${3}",
                timeStamp, AccountNumber, amount, AccountBalance);

            stream.WriteLine("{0} Withdrawal -${1}. New balance: ${2} ", timeStamp, amount, AccountBalance);
        }

        public void Transfer(double amount, Account account)
        {
            this.AccountBalance -= amount;
            account.AccountBalance = +amount;
        }
        #endregion




    }
}
