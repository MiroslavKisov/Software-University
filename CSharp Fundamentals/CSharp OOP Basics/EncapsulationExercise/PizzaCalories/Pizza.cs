using System;
using System.Collections.Generic;
using System.Text;


public class Pizza
{
    private string pizzaName;
    private Dough dough;
    private List<Topping> toppings;

    public List<Topping> Toppings
    {
        get { return toppings; }
        set
        {
            toppings = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public string PizzaName
    {
        get { return pizzaName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15 || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
            }
            pizzaName = value;
        }
    }

    public Pizza(string pizzaName)
    {
        this.PizzaName = pizzaName;
        this.Toppings = new List<Topping>();
        this.Dough = dough;
    }

    public double CalculateTotalCalories(double doughCalories, double toppingCalories)
    {
        return doughCalories + toppingCalories;
    }

    public void ValidateToppingCount()
    {
        if (this.toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}

