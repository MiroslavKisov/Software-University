using System;

public class StartUp
{
    public static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

