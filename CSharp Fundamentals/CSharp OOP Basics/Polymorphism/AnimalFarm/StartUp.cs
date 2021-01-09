using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {

            var inputArgs = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs.Length > 2)
            {
                string type = inputArgs[0];
                string name = inputArgs[1];
                double weight = double.Parse(inputArgs[2]);

                if (inputArgs[0] == "Cat")
                {
                    string livingRegion = inputArgs[3];
                    string breed = inputArgs[4];
                    Animal cat = new Cat(name, type, weight, livingRegion, breed);
                    animals.Add(cat);
                }
                else if (inputArgs[0] == "Tiger")
                {
                    string livingRegion = inputArgs[3];
                    string breed = inputArgs[4];
                    Animal tiger = new Tiger(name, type, weight, livingRegion, breed);
                    animals.Add(tiger);
                }
                else if (inputArgs[0] == "Dog")
                {
                    string livingRegion = inputArgs[3];
                    Animal dog = new Dog(name, type, weight, livingRegion);
                    animals.Add(dog);
                }
                else if (inputArgs[0] == "Mouse")
                {
                    string livingRegion = inputArgs[3];
                    Animal mouse = new Mouse(name, type, weight, livingRegion);
                    animals.Add(mouse);
                }
                else if (inputArgs[0] == "Owl")
                {
                    double wingSize = double.Parse(inputArgs[3]);
                    Animal owl = new Owl(name, type, weight, wingSize);
                    animals.Add(owl);
                }
                else if (inputArgs[0] == "Hen")
                {
                    double wingSize = double.Parse(inputArgs[3]);
                    Animal hen = new Hen(name, type, weight, wingSize);
                    animals.Add(hen);
                }
            }
            else
            {
                string foodType = inputArgs[0];
                long foodQuantity = long.Parse(inputArgs[1]);

                Food food = null;

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                    FeedAnimal(animals, food);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                    FeedAnimal(animals, food);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);
                    FeedAnimal(animals, food);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);
                    FeedAnimal(animals, food);
                }
            }
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void FeedAnimal(List<Animal> animal, Food food)
    {
        Console.WriteLine(animal.Last().MakeSound());
        animal.Last().EatFood(food);
    }
}

