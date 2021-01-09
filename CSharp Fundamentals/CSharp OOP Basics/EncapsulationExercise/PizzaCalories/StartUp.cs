using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var container = new List<Pizza>();
        double pizzaCalories = 0.0d;
        double doughCalories = 0.0d;
        double toppingCalories = 0.0d;

        string input;
        try
        {
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split();
                if (inputArgs[0].ToLower() == "pizza")
                {
                    string pizzaName = inputArgs[1];
                    Pizza pizza = new Pizza(pizzaName);
                    container.Add(pizza);
                }
                else if (inputArgs[0].ToLower() == "dough")
                {
                    string flourType = inputArgs[1];
                    string bakingTechnique = inputArgs[2];
                    double weight = double.Parse(inputArgs[3]);

                    Dough dough = new Dough(flourType, bakingTechnique, weight);
                    doughCalories = dough.CalculateCalories();

                    container[0].Dough = dough;
                }
                else if (inputArgs[0].ToLower() == "topping")
                {
                    string toppingType = inputArgs[1];
                    double toppingWeight = double.Parse(inputArgs[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    toppingCalories += topping.CalculateCalories();
                    container[0].ValidateToppingCount();
                    container[0].Toppings.Add(topping);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
        Console.WriteLine($"{container[0].PizzaName} - {container[0].CalculateTotalCalories(doughCalories, toppingCalories):F2} Calories.");
    }
}


