using System;
using System.Collections.Generic;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        private const string insufficientFunds = "Insufficient funds";
        private const string negativeAmount = "Cannot operate with negative amount of money!";

        public BankAccount()
        {

        }

        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SwiftCode = swiftCode;
        }

        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(negativeAmount);
            }
            if (this.Balance - amount < 0)
            {
                throw new InvalidOperationException(insufficientFunds);
            }
            else
            {
                this.Balance -= amount;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(negativeAmount);
            }

            this.Balance += amount;
        }   
    }
}
