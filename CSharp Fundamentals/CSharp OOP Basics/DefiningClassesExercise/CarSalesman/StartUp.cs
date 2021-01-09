using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();
        for (int i = 0; i < N; i++)
        {
            var engineInfo = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string engineModel = engineInfo[0];
            double enginePower = double.Parse(engineInfo[1]);
            if (engineInfo.Length == 2)
            {
                engines.Add(new Engine(engineModel, enginePower, "n/a", "n/a"));
            }
            else if (engineInfo.Length == 3)
            {
                if (Char.IsDigit(engineInfo[2][0]))
                {
                    string displacement = engineInfo[2];
                    engines.Add(new Engine(engineModel, enginePower, displacement, "n/a"));
                }
                else
                {
                    string efficiency = engineInfo[2];
                    engines.Add(new Engine(engineModel, enginePower, "n/a", efficiency));
                }
            }
            else if(engineInfo.Length == 4)
            {
                string displacement = engineInfo[2];
                string efficiency = engineInfo[3];
                engines.Add(new Engine(engineModel, enginePower, displacement, efficiency));
            }
        }
        var cars = new List<Car>();
        int M = int.Parse(Console.ReadLine());
        for (int i = 0; i < M; i++)
        {
            var carInfo = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = carInfo[0];
            string engineModel = carInfo[1];
            Engine engine = null;
            if (carInfo.Length == 2)
            {
                foreach (var eng in engines)
                {
                    if (eng.Model == engineModel)
                    {
                        engine = eng;
                        cars.Add(new Car(carModel, engine, "n/a", "n/a"));
                    }
                }
            }
            else if (carInfo.Length == 3)
            {
                if (Char.IsDigit(carInfo[2][0]))
                {
                    string weight = carInfo[2];
                    foreach (var eng in engines)
                    {
                        if (eng.Model == engineModel)
                        {
                            engine = eng;
                            cars.Add(new Car(carModel, engine, weight, "n/a"));
                        }
                    }
                }
                else
                {
                    string color = carInfo[2];
                    foreach (var eng in engines)
                    {
                        if (eng.Model == engineModel)
                        {
                            engine = eng;
                            cars.Add(new Car(carModel, engine, "n/a", color));
                        }
                    }
                }
            }
            else if (carInfo.Length == 4)
            {
                string weight = carInfo[2];
                string color = carInfo[3];
                foreach (var eng in engines)
                {
                    if (eng.Model == engineModel)
                    {
                        engine = eng;
                        cars.Add(new Car(carModel, engine, weight, color));
                    }
                }
            }
        }
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");
        }
    }
}

