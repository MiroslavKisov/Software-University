using System;
using System.Collections.Generic;
using System.Text;

public class Chicken
{
    private const int MinAge = 0;
    private const int MaxAge = 15;

    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        CalculateProductPerDay(age);
    }

    private string Name
    {
        set
        {
            if (value == null || value == string.Empty || value == " ")
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            this.name = value;
        }
    }

    private int Age
    {
        set
        {
            if (value < MinAge || value > MaxAge)
            {
                throw new ArgumentException("Age should be between 0 and 15.");
            }
            this.age = value;
        }
    }

    private double ProductPerDay
    {
        get
        {
            return this.CalculateProductPerDay(age);
        }
    }

    private double CalculateProductPerDay(int age)
    {
        switch (age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return 1.5;
            case 4:
            case 5:
            case 6:
            case 7:
                return 2;
            case 8:
            case 9:
            case 10:
            case 11:
                return 1;
            default:
                return 0.75;
        }
    }
    public override string ToString()
    {
        return $"Chicken {this.name} (age {this.age}) can produce {CalculateProductPerDay(age)} eggs per day.";
    }
}

