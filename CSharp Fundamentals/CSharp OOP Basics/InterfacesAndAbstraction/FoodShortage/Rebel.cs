using System;
using System.Collections.Generic;
using System.Text;


public class Rebel : IBuyer
{
    public Rebel(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public int BuyFood()
    {
        int food = 0;
        return food = 5;
    }
}

