using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string nameOfProduct;
    private double cost;

    public double Cost
    {
        get { return this.cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.cost = value;
        }
    }

    public string NameOfProduct
    {
        get { return this.nameOfProduct; }
        set
        {
            if ((string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.nameOfProduct = value;
        }
    }

    public Product(string nameOfProduct, double cost)
    {
        this.NameOfProduct = nameOfProduct;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return this.nameOfProduct;
    }
}

