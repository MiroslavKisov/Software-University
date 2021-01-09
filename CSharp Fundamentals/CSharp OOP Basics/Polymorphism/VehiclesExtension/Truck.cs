using System;
using System.Collections.Generic;
using System.Text;


public class Truck : IVehicle
{

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    private double fuelQuantity;

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            fuelQuantity = value;
        }
    }

    public double FuelConsumption { get; set; }

    private double tankCapacity;

    public double TankCapacity
    {
        get { return tankCapacity; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                tankCapacity = value;
            }
        }
    }

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
        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (this.TankCapacity < this.FuelQuantity + (fuel * 0.95d))
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += (fuel * 0.95d);
        }
    }
}
