using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace P01_BillsPaymentSystem
{
    public class Engine
    {
        private const string PleaseEnterId = "Please enter User ID between 1 and 21";
        private const string PaymentFailed = "Payment Failed!";
        private const string PaymentSuccessful = "Payment successful";
        private const string PaymentAmount = "Please enter Amount To Pay:";
        private const string IncorectCommand = "Incorrect command please Try Again!";
        private const string StartMsg = "Please Type \"Info\" for Information About users, \"Payment\" for payment operations or \"End\" for ending the program.";

        public void Run()
        {
            BillsPaymentSystemContext context = new BillsPaymentSystemContext();

            DatabaseInit databaseInit = new DatabaseInit();
            DataSeed dataSeed = new DataSeed();

            using (context)
            {
                databaseInit.CreateDatabase(context);
                dataSeed.Seed(context);

                //databaseInit.DeleteDatabase(context);

                Console.WriteLine(StartMsg);

                string command = Console.ReadLine();

                while (command != "End")
                {
                    if (command == "Info")
                    {
                        User user = GetUser(context);
                        PrintInfo(user);
                    }
                    else if (command == "Payment")
                    {
                        try
                        {
                            while (true)
                            {
                                Console.WriteLine(PleaseEnterId);
                                int userId = int.Parse(Console.ReadLine());

                                if (userId < 1 || userId > 21)
                                {
                                    continue;
                                }

                                Console.WriteLine(PaymentAmount);
                                decimal amount = decimal.Parse(Console.ReadLine());
                                PayBills(userId, amount, context);
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }

                    }
                    else
                    {
                        Console.WriteLine(IncorectCommand);
                    }
                    Console.WriteLine(StartMsg);
                    command = Console.ReadLine();
                }
            }
        }

        private void PrintInfo(User user)
        {
            var bankAccounts = user.PaymentMethods.Where(e => e.BankAccount != null).Select(e => e.BankAccount).ToList();

            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine("Bank Accounts: ");

            foreach (var payment in bankAccounts.OrderBy(e => e.BankAccountId))
            {
                Console.WriteLine($"-- ID: {payment.BankAccountId}");
                Console.WriteLine($"--- Balance: {payment.Balance:F2}");
                Console.WriteLine($"--- Bank: {payment.BankName}");
                Console.WriteLine($"--- SWIFT: {payment.SwiftCode}");
            }

            var culture = CultureInfo.InvariantCulture;
            var creditCards = user.PaymentMethods.Where(e => e.CreditCard != null).Select(e => e.CreditCard).ToList();
            Console.WriteLine("Credit Cards: ");

            foreach (var card in creditCards.OrderBy(e => e.CreditCardId))
            {
                Console.WriteLine($"-- ID: {card.CreditCardId}");
                Console.WriteLine($"--- Limit: {card.Limit:F2}");
                Console.WriteLine($"--- Money Owed: {card.MoneyOwed}");
                Console.WriteLine($"--- Limit Left: {card.LimitLeft}");
                Console.WriteLine($"--- Expiration Date: {card.ExpirationDate.ToString("yyyy/MM", culture)}");
            }
        }

        private User GetUser(BillsPaymentSystemContext context)
        {
            User user = null;

            Console.WriteLine(PleaseEnterId + " or \"End\" command");

            string command = Console.ReadLine();
            int id = 0;

            while (command != "End")
            {
                try
                {
                    id = int.Parse(command);

                    user = context.Users.Where(e => e.UserId == id)
                                  .Include(e => e.PaymentMethods)
                                  .ThenInclude(e => e.BankAccount)
                                  .Include(e => e.PaymentMethods)
                                  .ThenInclude(e => e.CreditCard)
                                  .FirstOrDefault();

                    if (user != null)
                    {
                        break;
                    }

                    Console.WriteLine($"User with Id {id} not found please try again or enter \"End\" command");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine(IncorectCommand);
                command = Console.ReadLine();
            }

            if (user == null)
            {
                Environment.Exit(0);
            }

            return user;
        }

        private void PayBills(int userId, decimal billsToPay, BillsPaymentSystemContext context)
        {
            User user = null;

            while (true)
            {
                user = context.Users.Where(e => e.UserId == userId)
                              .Include(e => e.PaymentMethods)
                              .ThenInclude(e => e.BankAccount)
                              .Include(e => e.PaymentMethods)
                              .ThenInclude(e => e.CreditCard)
                              .FirstOrDefault();

                if (user != null)
                {
                    break;
                }

                Console.WriteLine($"User with id {userId} not found please try again");
            }

            decimal moneyOwned = 0.0m;

            var bankAccounts = user.PaymentMethods.Where(e => e.BankAccount != null).Select(e => e.BankAccount);
            var creditCards = user.PaymentMethods.Where(e => e.CreditCard != null).Select(e => e.CreditCard);
            bool isSuccessful = false;

            foreach (var bankAccount in bankAccounts.OrderBy(e => e.BankAccountId))
            {
                moneyOwned += bankAccount.Balance;

                if (moneyOwned < billsToPay)
                {
                    bankAccount.Withdraw(bankAccount.Balance);
                }

                if (moneyOwned >= billsToPay)
                {
                    bankAccount.Withdraw(moneyOwned - billsToPay);
                    context.SaveChanges();
                    isSuccessful = true;
                    Console.WriteLine(PaymentSuccessful);
                    break;
                }
            }

            if (!isSuccessful)
            {
                foreach (var creditCard in creditCards.OrderBy(e => e.CreditCardId))
                {
                    moneyOwned += creditCard.LimitLeft;
                    if (moneyOwned < billsToPay)
                    {
                        creditCard.Withdraw(creditCard.LimitLeft);
                    }

                    if (moneyOwned >= billsToPay)
                    {
                        creditCard.Withdraw(moneyOwned - billsToPay);
                        context.SaveChanges();
                        Console.WriteLine(PaymentSuccessful);
                        break;
                    }
                }
            }
        }
    }
}
