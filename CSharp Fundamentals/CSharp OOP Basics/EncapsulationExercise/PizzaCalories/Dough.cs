using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    private double Weight
    {
        //get { return weight; }
        set
        {
            if (value < 0 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }

    private string BakingTechnique
    {
        //get { return bakingTechnique; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    private string FlourType
    {
        //get { return flourType; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double CalculateCalories()
    {
        double caloriesPerGram = 2.0d;
        double totalCalories = 0.0d;
        double whiteDoughModifier = 1.5d;
        double wholegrainDoughModifier = 1.0;
        double crispyTechniqueModifier = 0.9d;
        double chewyTechniqueModifier = 1.1d;
        double homemadeTechniqueModifier = 1.0d;

        switch (this.flourType.ToLower())
        {
            case "white":
                totalCalories = caloriesPerGram * this.weight * whiteDoughModifier;
                break;
            case "wholegrain":
                totalCalories = caloriesPerGram * this.weight * wholegrainDoughModifier;
                break;
            default:
                break;
        }
        switch (this.bakingTechnique.ToLower())
        {
            case "chewy":
                totalCalories = totalCalories * chewyTechniqueModifier;
                break;

            case "crispy":
                totalCalories = totalCalories * crispyTechniqueModifier;
                break;

            case "homemade":
                totalCalories = totalCalories * homemadeTechniqueModifier;
                break;

            default:
                break;
        }
        return totalCalories;
    }
}

