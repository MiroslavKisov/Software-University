using System;


public class StartUp
{
    public static void Main()
    {
        try
        {
            string inputStudent = Console.ReadLine();
            var inputArgsStudent = inputStudent.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string firstNameStudent = inputArgsStudent[0];
            string lastNameStudent = inputArgsStudent[1];
            string facultyNumberStudent = inputArgsStudent[2];

            Student student = new Student(firstNameStudent, lastNameStudent, facultyNumberStudent);

            string inputWorker = Console.ReadLine();
            var inputArgsWorker = inputWorker.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string firstNameWorker = inputArgsWorker[0];
            string lastNameWorker = inputArgsWorker[1];
            decimal weekSalary = decimal.Parse(inputArgsWorker[2]);
            decimal workingHours = decimal.Parse(inputArgsWorker[3]);

            Worker worker = new Worker(firstNameWorker, lastNameWorker, weekSalary, workingHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

