using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IBuyer
{
    public Citizen(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public int BuyFood()
    {
        int food = 0;
        return food = 10;
    }
}

