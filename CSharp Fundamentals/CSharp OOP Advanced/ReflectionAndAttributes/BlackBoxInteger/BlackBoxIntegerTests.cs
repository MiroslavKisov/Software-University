namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            //var type = typeof(BlackBoxInteger);

            object instance = Activator.CreateInstance(type, true);
            var field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var commandAdgs = input.Split('_');

                string command = commandAdgs[0];
                int argument = int.Parse(commandAdgs[1]);

                var currentMethod = methods.First(x => x.Name == command);

                currentMethod.Invoke(instance, new object[] { argument });

                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}
