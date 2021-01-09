using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    public Owl(string name, string type, double weight, double wingSize)
        : base(name, type, weight, wingSize)
    {
        this.Name = name;
        this.Type = type;
        this.Weight = weight;
        this.FoodEaten = 0L;
        this.WingSize = wingSize;
    }

    public override string MakeSound()
    {
        return "Hoot Hoot";
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
            this.Weight += food.Quantity * 0.25d;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

