using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var lights = Console.ReadLine().Split().ToArray();

        int numberOfChanges = int.Parse(Console.ReadLine());

        Type type = typeof(TrafficLight);
        var trafficLightsList = new List<TrafficLight>();

        AddTraficLights(type, lights, trafficLightsList);

        ChangeLights(trafficLightsList, type, numberOfChanges);
        
    }

    private static void ChangeLights(List<TrafficLight> trafficLightsList, Type type, int numberOfChanges)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < numberOfChanges; i++)
        {
            foreach (var trafficLight in trafficLightsList)
            {
                var property = trafficLight
                    .GetType()
                    .GetProperty("Light", BindingFlags.Public | BindingFlags.Instance);

                string light = property.GetValue(trafficLight).ToString();

                if (light == "Red")
                {
                    property.SetValue(trafficLight, "Green");
                    sb.Append(property.GetValue(trafficLight).ToString() + " ");
                }
                else if (light == "Green")
                {
                    property.SetValue(trafficLight, "Yellow");
                    sb.Append(property.GetValue(trafficLight).ToString() + " ");
                }
                else if (light == "Yellow")
                {
                    property.SetValue(trafficLight, "Red");
                    sb.Append(property.GetValue(trafficLight).ToString() + " ");
                }
            }

            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
    }

    private static void AddTraficLights(Type type, string[] lights, List<TrafficLight> trafficLightsList)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            TrafficLight currentTrafficLight = (TrafficLight)Activator.CreateInstance(type, new object[] { lights[i] });
            trafficLightsList.Add(currentTrafficLight);
        }
    }
}

