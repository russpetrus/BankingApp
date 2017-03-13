using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankingApp
{
    class CheckingAccount : Account
    {


        #region properties and fields
        public double TransactionFee { get; set; } = 2.50;
        public bool OverDaftProtection { get; set; } = true;
        #endregion

        #region constructors
        public CheckingAccount(int accountNumber, double balance) : base("Checking Account")
        {
            this.AccountNumber = accountNumber;
            this.AccountBalance = balance;
        }
        #endregion

        
        #region methods
        public override void Withdraw(double amount, StreamWriter stream) //needed to add transaction fee to withdrawal
        {
            DateTime timeStamp = DateTime.Now;
            this.AccountBalance -= (amount + TransactionFee);

            Console.WriteLine("Transaction Time: {0}\nAccount Number: {1}\nWithdrawal: ${2} + Transaction fee: {3}\nNew Balance: ${4}",
                timeStamp, AccountNumber, amount, TransactionFee, AccountBalance);

            stream.WriteLine("{0} Withdrawal -${1}. ${2} transaction fee. New balance: ${3} ", timeStamp, amount, TransactionFee, AccountBalance);
        }

        #endregion


    }
}
