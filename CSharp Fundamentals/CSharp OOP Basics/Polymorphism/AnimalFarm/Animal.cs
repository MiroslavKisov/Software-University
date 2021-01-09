using System;
using System.Collections.Generic;
using System.Text;


public abstract class Animal
{
    private string name;
    private string type;
    private double weight;
    private long foodEaten;

    public long FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Animal(string name, string type, double weight)
    {
        this.Name = name;
        this.Type = type;
        this.Weight = weight;
        this.FoodEaten = 0L;
    }

    public virtual string MakeSound()
    {
        return "Animal";
    }

    public virtual void EatFood(Food food)
    {
        
    }
}

