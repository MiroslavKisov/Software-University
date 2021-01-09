using System;
using System.Collections.Generic;
using System.Text;


public class Hen : Bird
{
    public Hen(string name, string type, double weight, double wingSize)
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
        return "Cluck";
    }

    public override void EatFood(Food food)
    {
        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * 0.35d;
    }

    public override string ToString()
    {
        return $"{this.Type} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

