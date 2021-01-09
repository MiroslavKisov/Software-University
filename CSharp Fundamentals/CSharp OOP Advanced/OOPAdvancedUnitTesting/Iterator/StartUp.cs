using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    public class StartUp
    {
        public static void Main()
        {
            ListIterator listIterator = null;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {

                List<string> commandArgs = input.Split(' ').ToList();
                string command = commandArgs[0];
                List<string> elements = null;

                try
                {
                    switch (command)
                    {
                        case "Create":

                            if (commandArgs.Count > 0)
                            {
                                commandArgs.RemoveAt(0);
                                elements = new List<string>(commandArgs);
                            }

                            listIterator = new ListIterator(elements);
                            break;

                        case "Move":

                            Console.WriteLine(listIterator.Move());
                            break;

                        case "HasNext":

                            Console.WriteLine(listIterator.HasNext());
                            break;

                        case "Print":

                            string currentElement = listIterator.PrintElement();
                            Console.WriteLine(currentElement);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e )
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
