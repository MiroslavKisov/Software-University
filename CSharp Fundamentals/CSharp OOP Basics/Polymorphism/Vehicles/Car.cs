using System;
using System.Collections.Generic;
using System.Text;


public class Car : IVehicle
{
    public Car(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    public void Drive(double distance)
    {
        if (distance * (this.FuelConsumption + 0.9d) <= this.FuelQuantity)
        {
            FuelQuantity -= distance * (this.FuelConsumption + 0.9d);
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }

    public void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }
}

