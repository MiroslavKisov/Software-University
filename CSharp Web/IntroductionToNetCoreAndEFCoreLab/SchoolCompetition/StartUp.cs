namespace SchoolCompetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var students = new Dictionary<string, int>();
            var categories = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var studentName = args[0];
                var category = args[1];
                var score = int.Parse(args[2]);

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = 0;
                }

                students[studentName] += score;

                if (!categories.ContainsKey(studentName))
                {
                    categories[studentName] = new HashSet<string>();
                }

                categories[studentName].Add(category);
            }

            foreach (var student in students.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Value))
            {
                Console.WriteLine($"{student.Key}: {student.Value} [{string.Join(", ",categories[student.Key].OrderBy(x => x))}]");
            }
        }
    }
}
