using System;
using System.Collections.Generic;
using System.Text;


public class Fruit : Food
{
    public Fruit(long quantity):base(quantity)
    {
        this.Quantity = quantity;
    }
}

