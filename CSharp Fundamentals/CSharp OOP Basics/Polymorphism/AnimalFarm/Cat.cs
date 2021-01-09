using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Feline
{
    private string breed;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public Cat(string name, string type, double weight, string livingRegion, string breed)
        : base(name, type, weight, livingRegion)
    {
        this.Name = name;
        this.Type = type;
        this.Weight = weight;
        this.FoodEaten = 0L;
        this.LivingRegion = livingRegion;
        this.Breed = breed;
    }

    public override string MakeSound()
    {
        return "Meow";
    }

    public override void EatFood(Food food)
    {
        if (food.GetType().Name != "Meat" && food.GetType().Name != "Vegetable")
        {
            Console.WriteLine($"{this.Type} does not eat {food.GetType().Name}!");
        }
        else
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.30d;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

