using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();
        while (true)
        {
            string commands = Console.ReadLine();
            if (commands == "end")
            {
                break;
            }
            var commandArgs = commands
                .Split(" ");
            if (commandArgs[0] == "Create")
            {
                if (!accounts.ContainsKey(int.Parse(commandArgs[1])))
                {
                    var acc = new BankAccount();
                    accounts.Add(int.Parse(commandArgs[1]), acc);
                    accounts[int.Parse(commandArgs[1])].Id = int.Parse(commandArgs[1]);
                }
                else
                {
                    Console.WriteLine("Account already exists");
                }
            }
            else if (commandArgs[0] == "Deposit")
            {
                if (!accounts.ContainsKey(int.Parse(commandArgs[1])))
                {
                    Console.WriteLine("Account does not exist");
                }
                else
                {
                    accounts[int.Parse(commandArgs[1])].Deposit(decimal.Parse(commandArgs[2]));
                }
            }
            else if (commandArgs[0] == "Withdraw")
            {
                if (!accounts.ContainsKey(int.Parse(commandArgs[1])))
                {
                    Console.WriteLine("Account does not exist");
                }
                else
                {
                    if (accounts[int.Parse(commandArgs[1])].Balance < decimal.Parse(commandArgs[2]))
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                    else
                    {
                        accounts[int.Parse(commandArgs[1])].Withdraw(decimal.Parse(commandArgs[2]));
                    }
                }
            }
            else if (commandArgs[0] == "Print")
            {
                if (!accounts.ContainsKey(int.Parse(commandArgs[1])))
                {
                    Console.WriteLine("Account does not exist");
                }
                else
                {
                    Console.WriteLine(accounts[int.Parse(commandArgs[1])]);
                }
            }
        }
    }
}
