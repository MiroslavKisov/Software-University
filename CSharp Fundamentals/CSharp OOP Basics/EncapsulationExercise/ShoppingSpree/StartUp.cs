using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var persons = new Dictionary<string, Person>();
        var products = new Dictionary<string, Product>();

        string inputPersons = Console.ReadLine();
        string inputProducts = Console.ReadLine();

        try
        {
            var inputPersonSplit = inputPersons
                .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputPersonSplit.Length; i++)
            {
                var inputPersonArgs = inputPersonSplit[i]
                    .Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                string personName = inputPersonArgs[0];
                double money = double.Parse(inputPersonArgs[1]);

                Person person = new Person(personName, money);
                persons.Add(personName, person);

            }

            var inputProductsSplit = inputProducts
           .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputProductsSplit.Length; i++)
            {
                var inputProductsArgs = inputProductsSplit[i]
                    .Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                string productName = inputProductsArgs[0];
                double productCost = double.Parse(inputProductsArgs[1]);

                Product product = new Product(productName, productCost);
                products.Add(productName, product);

            }

            while (true)
            {
                string commandBuy = Console.ReadLine();

                if (commandBuy == "END")
                {
                    break;
                }

                var commandBuyArgs = commandBuy
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string personName = commandBuyArgs[0];
                string productName = commandBuyArgs[1];

                if (persons[personName].Money >= products[productName].Cost)
                {
                    persons[personName].Money -= products[productName].Cost;
                    Console.WriteLine($"{personName} bought {productName}");
                    persons[personName].Bag.Add(products[productName]);
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        foreach (var person in persons)
        {
            Console.Write($"{person.Key} - ");
            if (person.Value.Bag.Count == 0)
            {
                Console.Write("Nothing bought");
            }
            else
            {
                Console.WriteLine(string.Join(", ", person.Value.Bag));
            }
        }
    }
}
