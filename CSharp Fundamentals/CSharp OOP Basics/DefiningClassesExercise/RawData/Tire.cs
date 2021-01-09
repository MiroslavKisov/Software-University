using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    private int tire1Age;
    private int tire2Age;
    private int tire3Age;
    private int tire4Age;
    private double tire1Pressure;
    private double tire2Pressure;
    private double tire3Pressure;
    private double tire4Pressure;

    public double Tire4Pressure
    {
        get { return tire4Pressure; }
        set { tire4Pressure = value; }
    }

    public double Tire3Pressure
    {
        get { return tire3Pressure; }
        set { tire3Pressure = value; }
    }

    public double Tire2Pressure
    {
        get { return tire2Pressure; }
        set { tire2Pressure = value; }
    }

    public double Tire1Pressure
    {
        get { return tire1Pressure; }
        set { tire1Pressure = value; }
    }

    public int Tire4Age
    {
        get { return tire4Age; }
        set { tire4Age = value; }
    }

    public int Tire3Age
    {
        get { return tire3Age; }
        set { tire3Age = value; }
    }

    public int Tire2Age
    {
        get { return tire2Age; }
        set { tire2Age = value; }
    }

    public int Tire1Age
    {
        get { return tire1Age; }
        set { tire1Age = value; }
    }
    public Tire(int tire1Age, int tire2Age, int tire3Age, int tire4Age, double tire1Pressure, double tire2Pressure, double tire3Pressure, double tire4Pressure)
    {
        this.Tire1Age = tire1Age;
        this.Tire2Age = tire2Age;
        this.Tire3Age = tire3Age;
        this.Tire3Age = tire4Age;
        this.Tire1Pressure = tire1Pressure;
        this.Tire2Pressure = tire2Pressure;
        this.Tire3Pressure = tire3Pressure;
        this.Tire4Pressure = tire4Pressure;
    }
}

