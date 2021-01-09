namespace P01_HarvestingFields
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Linq;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        var privateFields = fields.Where(x => x.IsPrivate).ToArray();
                        PrintFields(privateFields);
                        break;
                    case "protected":
                        var protectedFields = fields.Where(x => x.IsFamily).ToArray();
                        PrintFields(protectedFields);
                        break;
                    case "public":
                        var publicFields = fields.Where(x => x.IsPublic).ToArray();
                        PrintFields(publicFields);
                        break;
                    case "all":
                        PrintFields(fields);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintFields(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                string modifier = field.Attributes.ToString().ToLower();

                if (modifier == "family")
                {
                    modifier = "protected";
                }

                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
