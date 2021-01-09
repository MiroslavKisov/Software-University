using System;

namespace MinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Enter villain Id: ");
            int villainId = int.Parse(Console.ReadLine());

            Connection connection = new Connection();

            connection.RunConnection(villainId);
        }
    }
}
