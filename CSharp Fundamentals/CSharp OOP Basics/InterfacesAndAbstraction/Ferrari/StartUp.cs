using System;


public class StartUp
{
    public static void Main()
    {
        string driver = Console.ReadLine();

        IFerrari ferrari = new Ferrari(driver);
        Console.WriteLine($"488-Spider/{ferrari.UseBrakes()}/{ferrari.GasPedal()}/{ferrari.Driver}");
    }
}

