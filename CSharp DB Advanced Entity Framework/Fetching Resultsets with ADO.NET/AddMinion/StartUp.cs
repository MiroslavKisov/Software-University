using AddMinion.Interfaces;
using System;

namespace AddMinion
{
    public class StartUp
    {
        public static void Main()
        {

            Console.Write("Minion: ");
            string minionInfo = Console.ReadLine();

            Console.Write("Villain: ");
            string villainInfo = Console.ReadLine();

            IParser parser = new InputParser();
            IConnection connection = new Connection(parser, minionInfo, villainInfo);

            connection.RunConnection();

        }
    }
}
