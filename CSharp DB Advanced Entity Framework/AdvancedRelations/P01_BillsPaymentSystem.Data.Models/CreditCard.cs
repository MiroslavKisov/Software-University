using System.Collections.Generic;
using System;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        private const string insufficientFunds = "Insufficient funds";
        private const string negativeAmount = "Cannot operate with negative amount of money!";
        private const string exceededLimit = "You have exceeded you limit!";

        public CreditCard()
        {

        }

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expDate;
        }

        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(negativeAmount);
            }
            if (this.LimitLeft - amount < 0)
            {
                throw new InvalidOperationException(exceededLimit);
            }

            this.Limit -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(negativeAmount);
            }

            this.Limit += amount;
        }
    }
}
    