using System;
using System.Collections.Generic;
using System.Text;


public abstract class Mammal : Animal
{
    private string livingRegion;

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public Mammal(string name, string type, double weight, string livingRegion)
        : base(name, type, weight)
    {
        this.LivingRegion = livingRegion;
    }
}

