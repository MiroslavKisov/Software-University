using System;
using System.Collections.Generic;
using System.Text;


public class Dog : Mammal
{
    public Dog(string name, string type, double weight, string livingRegion) :
        base(name, type, weight, livingRegion)
    {
        this.Name = name;
        this.Type = type;
        this.Weight = weight;
        this.FoodEaten = 0L;
        this.LivingRegion = livingRegion;
    }

    public override string MakeSound()
    {
        return "Woof!";
    }

    public override void EatFood(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            Console.WriteLine($"{this.Type} does not eat {food.GetType().Name}!");
        }
        else
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.40d;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

