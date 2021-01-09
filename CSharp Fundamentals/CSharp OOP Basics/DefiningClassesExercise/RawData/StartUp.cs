using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfCargos = int.Parse(Console.ReadLine());
        var cars = new Dictionary<string, List<Car>>();
        for (int i = 0; i < numberOfCargos; i++)
        {
            string inputCargo = Console.ReadLine();
            var cargoArgs = inputCargo
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string model = cargoArgs[0];

            int engineSpeed = int.Parse(cargoArgs[1]);
            int enginePower = int.Parse(cargoArgs[2]);

            int cargoWeight = int.Parse(cargoArgs[3]);
            string cargoType = cargoArgs[4];

            double tire1Pressure = double.Parse(cargoArgs[5]);
            int tire1Age = int.Parse(cargoArgs[6]);

            double tire2Pressure = double.Parse(cargoArgs[7]);
            int tire2Age = int.Parse(cargoArgs[8]);

            double tire3Pressure = double.Parse(cargoArgs[9]);
            int tire3Age = int.Parse(cargoArgs[10]);

            double tire4Pressure = double.Parse(cargoArgs[11]);
            int tire4Age = int.Parse(cargoArgs[12]);

            Tire tire = new Tire(tire1Age, tire2Age, tire3Age, tire4Age, tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Engine engine = new Engine(engineSpeed, enginePower);
            Car car = new Car(model, engine, cargo, tire);
            AddCars(cars, cargoType,car);
        }
        string printCommand = Console.ReadLine();
        if (printCommand == "fragile")
        {
            foreach (var car in cars[printCommand].Where(x => x.Tire.Tire1Pressure < 1 
            || x.Tire.Tire2Pressure < 1 
            || x.Tire.Tire3Pressure < 1
            || x.Tire.Tire4Pressure < 1))
            {
                Console.WriteLine($"{car.Model}");
            }
        }
        else
        {
            foreach (var car in cars[printCommand].Where(x => x.Engine.EnginePower > 250))
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }

    private static void AddCars(Dictionary<string, List<Car>> cars, string cargoType, Car car)
    {
        if (!cars.ContainsKey(cargoType))
        {
            cars.Add(cargoType, new List<Car>());
            cars[cargoType].Add(car);
        }
        else
        {
            cars[cargoType].Add(car);
        }
    }
}

