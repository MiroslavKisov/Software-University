using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();
        while (true)
        {
            var command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            var commandArgs = command
                .Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
            var cmdType = commandArgs[0];
            switch (cmdType)
            {
                case "Create":
                    CreateAccount(accounts, commandArgs);
                    break;
                case "Deposit":
                    Deposit(accounts, commandArgs);
                    break;
                case "Withdraw":
                    Withdraw(accounts, commandArgs);
                    break;
                case "Print":
                    Print(accounts, commandArgs);
                    break;
                default:
                    break;
            }
        }
    }

    private static void Print(Dictionary<int, BankAccount> accounts, string[] commandArgs)
    {
        var id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id]);
        }
    }

    private static void Withdraw(Dictionary<int, BankAccount> accounts, string[] commandArgs)
    {
        var id = int.Parse(commandArgs[1]);
        var amount = decimal.Parse(commandArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(amount);
            }
        }
    }

    private static void Deposit(Dictionary<int, BankAccount> accounts, string[] commandArgs)
    {
        var id = int.Parse(commandArgs[1]);
        var amount = decimal.Parse(commandArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Deposit(amount);
        }
    }

    private static void CreateAccount(Dictionary<int, BankAccount> accounts, string[] commandArgs)
    {
        int id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            var acc = new BankAccount();
            acc.Id = id;
            accounts.Add(id, acc);
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }
}

