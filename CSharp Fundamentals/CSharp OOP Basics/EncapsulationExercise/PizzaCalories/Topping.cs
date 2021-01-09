using System;
using System.Collections.Generic;
using System.Text;


public class Topping
{
    private string toppingType;
    private double weight;

    private double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    private string ToppingType
    {
        //get { return toppingType; }

        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            toppingType = value.ToLower();
        }
    }

    public Topping(string toppingType, double weight)
    {
        this.Weight = weight;
        ValidateWeight(toppingType, weight);
        this.ToppingType = toppingType;
    }

    public double CalculateCalories()
    {
        double caloriesPerGram = 2.0d;
        double totalCalories = 0.0d;
        double meatModifier = 1.2d;
        double veggiesModifier = 0.8d;
        double cheeseModifier = 1.1d;
        double sauceModifier = 0.9d;

        switch (this.toppingType.ToLower())
        {
            case "meat":
                totalCalories = caloriesPerGram * meatModifier * this.weight;
                break;
            case "veggies":
                totalCalories = caloriesPerGram * veggiesModifier * this.weight;
                break;
            case "cheese":
                totalCalories = caloriesPerGram * cheeseModifier * this.weight;
                break;
            case "sauce":
                totalCalories = caloriesPerGram * sauceModifier * this.weight;
                break;
            default:
                break;
        }
        return totalCalories;
    }

    private void ValidateWeight(string type, double weight)
    {
        if (this.weight > 50 || this.weight < 0)
        {
            throw new ArgumentException($"{type} weight should be in the range [1..50].");
        }
    }
}

