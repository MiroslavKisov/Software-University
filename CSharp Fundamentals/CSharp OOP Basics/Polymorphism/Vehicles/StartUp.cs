using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var carInfo = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

        var truckInfo = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var commandArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            double distance = double.Parse(commandArgs[2]);

            if (commandArgs[0] == "Drive")
            {
                if (commandArgs[1] == "Car")
                {
                    car.Drive(distance);
                }
                else if (commandArgs[1] == "Truck")
                {
                    truck.Drive(distance);
                }
            }
            else if (commandArgs[0] == "Refuel")
            {
                double fuel = double.Parse(commandArgs[2]);

                if (commandArgs[1] == "Car")
                {
                    car.Refuel(fuel);
                }
                else if (commandArgs[1] == "Truck")
                {
                    truck.Refuel(fuel);
                }
            }
        }
        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}

