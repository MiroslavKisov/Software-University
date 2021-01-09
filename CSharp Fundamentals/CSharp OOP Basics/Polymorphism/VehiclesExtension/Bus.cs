using System;
using System.Collections.Generic;
using System.Text;


public class Bus : IBus
{

    public string DriveType { get; set; }

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

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public void Drive(double distance)
    {
        if (this.DriveType == "DriveEmpty")
        {
            if (distance * (this.FuelConsumption) <= this.FuelQuantity)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        else
        {
            if (distance * (this.FuelConsumption + 1.4d) <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * (this.FuelConsumption + 1.4d);
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }

    public void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (this.TankCapacity < this.FuelQuantity + fuel)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += fuel;
        }
    }
}
