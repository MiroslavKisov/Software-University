using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var commands = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        int N = int.Parse(commands[0]);
        int M = int.Parse(commands[1]);
        var rectangles = new Dictionary<string,Rectangle>();

        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            var triangleArgs = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string id = triangleArgs[0];
            double width = double.Parse(triangleArgs[1]);
            double height = double.Parse(triangleArgs[2]);
            double pointX = double.Parse(triangleArgs[3]);
            double pointY = double.Parse(triangleArgs[4]);
            Rectangle rectangle = new Rectangle(id, width, height, pointX, pointY);
            rectangles.Add(id, rectangle);
        }
        for (int i = 0; i < M; i++)
        {
            string command = Console.ReadLine();
            var commandArgs = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            bool areIntersecting = CheckForIntersection(commandArgs[0], commandArgs[1], rectangles);
            if (areIntersecting)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }

    private static bool CheckForIntersection(string firstRectangle, string secondRectangle, Dictionary<string,Rectangle> rectangles)
    {
        if (rectangles[firstRectangle].PointX + rectangles[firstRectangle].Width >= rectangles[secondRectangle].PointX &&
            rectangles[firstRectangle].PointX <= rectangles[secondRectangle].PointX + rectangles[secondRectangle].Width &&
            rectangles[firstRectangle].PointY + rectangles[firstRectangle].Height >= rectangles[secondRectangle].PointY &&
            rectangles[firstRectangle].PointY <= rectangles[firstRectangle].PointY + rectangles[secondRectangle].Height)
        {
            return true;
        }
        return false;
    }
}
