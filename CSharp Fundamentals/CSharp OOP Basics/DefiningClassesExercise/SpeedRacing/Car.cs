using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distanceTraveled;

    public double DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelConsumption = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
    }
    public void MoveCar(Car car, double targetDistance)
    {
        if (targetDistance * car.FuelConsumption <= car.FuelAmount)
        {
            car.FuelAmount -= targetDistance * car.FuelConsumption;
            car.DistanceTraveled += targetDistance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

