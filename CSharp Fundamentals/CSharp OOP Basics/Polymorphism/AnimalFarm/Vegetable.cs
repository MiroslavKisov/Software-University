using System;
using System.Collections.Generic;
using System.Text;


public class Vegetable : Food
{
    public Vegetable(long quantity) : base(quantity)
    {
        this.Quantity = quantity;
    }
}

