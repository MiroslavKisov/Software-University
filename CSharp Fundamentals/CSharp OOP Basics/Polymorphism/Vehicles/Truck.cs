using System;
using System.Collections.Generic;
using System.Text;


public class Truck : IVehicle
{

    public Truck(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    public void Drive(double distance)
    {
        if (distance * (this.FuelConsumption + 1.6d) <= this.FuelQuantity)
        {
            FuelQuantity -= distance * (this.FuelConsumption + 1.6d);
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public void Refuel(double fuel)
    {
        this.FuelQuantity += (fuel * 0.95);
    }
}

