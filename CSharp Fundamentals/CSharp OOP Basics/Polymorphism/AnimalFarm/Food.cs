using System;
using System.Collections.Generic;
using System.Text;


public abstract class Food
{
    private long quantity;

    public long Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Food(long quantity)
    {
        this.Quantity = quantity;
    }
}

