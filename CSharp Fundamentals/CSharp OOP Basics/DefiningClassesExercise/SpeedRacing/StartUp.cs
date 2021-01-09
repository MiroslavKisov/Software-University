using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var cars = new Dictionary<string, Car>();
        int numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            string inputCar = Console.ReadLine();
            var carArgs = inputCar
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string model = carArgs[0];
            double fuelAmount = double.Parse(carArgs[1]);
            double fuelConsumption = double.Parse(carArgs[2]);
            Car car = new Car(model, fuelAmount, fuelConsumption);
            AddCars(car, cars);
        }
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            var commandArgs = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string model = commandArgs[1];
            double targetDistance = double.Parse(commandArgs[2]);
            cars[model].MoveCar(cars[model], targetDistance);
        }
        PrintCars(cars);
    }

    private static void PrintCars(Dictionary<string, Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.DistanceTraveled}");
        }
    }

    private static void AddCars(Car car, Dictionary<string, Car> cars)
    {
        cars.Add(car.Model, car);
    }
}

