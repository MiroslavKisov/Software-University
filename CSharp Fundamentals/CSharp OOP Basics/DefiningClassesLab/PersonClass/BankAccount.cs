﻿using System;
using System.Collections.Generic;
using System.Text;


public class BankAccount
{
    private int id;
    private decimal balance;
    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }
    public decimal Withdraw(decimal amount)
    {
        return this.Balance -= amount;
    }
    public decimal Deposit(decimal amount)
    {
        return this.Balance += amount;
    }
    //public override string ToString()
    //{
    //    return $"Account ID{this.Id}, balance {this.Balance:F2}";
    //}
}

