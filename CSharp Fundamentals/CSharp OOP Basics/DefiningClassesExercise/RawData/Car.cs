using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire tire;

    public Tire Tire
    {
        get { return tire; }
        set { tire = value; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Car(string model, Engine engine, Cargo cargo, Tire tire)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tire = tire;
    }
}

