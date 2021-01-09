using System;

public class StartUp
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);

            double lateralSurface = box.CalculateLateralSurface();
            double fullSurface = box.CalculateFullSurface();
            double volume = box.CalculateVolume();
            Console.WriteLine($"Surface Area - {fullSurface:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurface:F2}");
            Console.WriteLine($"Volume - {volume:F2}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

