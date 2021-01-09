using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private double money;
    private List<Product> bag;

    public List<Product> Bag
    {
        get { return bag; }
        set { bag = value; }
    }

    public double Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if ((string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }
}

