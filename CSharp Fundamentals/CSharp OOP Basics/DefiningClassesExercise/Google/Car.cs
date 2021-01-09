using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private string speed;

    public string Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Car(string model,string speed)
    {
        Model = model;
        Speed = speed;
    }
    public override string ToString()
    {
        return $"{Model} {Speed}";
    }
}

