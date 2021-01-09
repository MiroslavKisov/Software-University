using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<object> subjects = new List<object>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var inputArgs = input.Split();

            if (inputArgs.Length == 2)
            {
                string model = inputArgs[0];
                string id = inputArgs[1];

                Robot robot = new Robot(id, model);

                subjects.Add(robot);
            }
            else if (inputArgs.Length == 3)
            {
                string name = inputArgs[0];
                string age = inputArgs[1];
                string id = inputArgs[2];

                Citizen citizen = new Citizen(name, age, id);

                subjects.Add(citizen);
            }
        }
        string fakeID = Console.ReadLine();
        GetDetainees(subjects, fakeID);
    }

    private static void GetDetainees(List<object> subjects,string fakeID)
    {
        for (int i = 0; i < subjects.Count; i++)
        {
            
            if (subjects[i] is Citizen)
            {
                var subjectCitizen = (Citizen)subjects[i];

                if (subjectCitizen.GetID(fakeID))
                {
                    Console.WriteLine(subjectCitizen.Id);
                }
            }
            else
            {
                var subjectRobot = (Robot)subjects[i];

                if (subjectRobot.GetID(fakeID))
                {
                    Console.WriteLine(subjectRobot.Id);
                }
            }
        }
    }
}

