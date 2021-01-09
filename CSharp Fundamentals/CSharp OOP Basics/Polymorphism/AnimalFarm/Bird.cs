using System;
using System.Collections.Generic;
using System.Text;


public abstract class Bird : Animal
{
    private double wingSize;

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

    public Bird(string name, string type, double weight, double wingSize) : base(name, type, weight)
    {
        this.WingSize = wingSize;
    }
}

