using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class SavingsAccount : Account

    {
        #region properties and fields
        public double MinimumBalance {get; set;} = 1000;
        private double InterestRate { get; set; } = .005;
        #endregion


        #region constructors
        public SavingsAccount(int accountNumber, double balance) : base("Savings Account")
        {
            this.AccountNumber = accountNumber;
            this.AccountBalance = balance;
        }

        #endregion

        #region methods

        public double ApplyDailyInterest(int days) //calculates the interest earned based on number of days, returns the interest earned, and updates the account balance with the interest
        {
            double dailyInterest = (InterestRate * AccountBalance) / 365;
            double earnedInterest = dailyInterest * days;

            AccountBalance += earnedInterest;

            return earnedInterest;
        }
       
        public override void Withdraw(double amount, StreamWriter stream)
        {
            DateTime timeStamp = DateTime.Now;
            AccountBalance -= amount;
            Console.WriteLine("Transaction Time: {0}\nAccount Number: {1}\nWithdrawal: ${2}\nNew Balance: ${3}",
                timeStamp, AccountNumber, amount, AccountBalance);

            stream.WriteLine("{0} Withdrawal -${1}. New balance: ${2} ", timeStamp, amount, AccountBalance);                
          }            
        #endregion


    }
}
