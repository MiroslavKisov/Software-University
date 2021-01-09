using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private string weight;
    private string color;
    private Engine engine;

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Car(string model, Engine engine, string weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }
}

