using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class StartUp
{
    public static void Main()
    {
        List<string> relativesPartialInfo = new List<string>();
        List<string> relativesFullInfo = new List<string>();
        Person person = new Person();

        string targetPerson = Console.ReadLine();
        if (Char.IsDigit(targetPerson[0]))
        {
            person.PersonBirthDate = targetPerson;
        }
        else
        {
            var targetInfoNames = targetPerson
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string targetFirstName = targetInfoNames[0];
            string targetLastName = targetInfoNames[1];
            person.PersonFirstName = targetFirstName;
            person.PersonLastName = targetLastName;
        }
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            if (input.Contains('-'))
            {
                relativesPartialInfo.Add(input);
            }
            else
            {
                relativesFullInfo.Add(input);
            }
                
        }
        GettingTargetPersonFullInfo(person, relativesFullInfo,targetPerson);
        GettingParentsAndChildren(person, relativesPartialInfo);
        SettingRelativesFullInfo(person, relativesFullInfo);
        PrintFamilyTree(person);
    }

    private static void PrintFamilyTree(Person person)
    {
        Console.WriteLine($"{person.PersonFirstName} {person.PersonLastName} {person.PersonBirthDate}");
        Console.WriteLine("Parents:");
        foreach (var parent in person.Parents)
        {
            Console.WriteLine($"{parent.ParentFirstName} {parent.ParentLastName} {parent.ParentBirthDate}");
        }
        Console.WriteLine("Children:");
        foreach (var child in person.Children)
        {
            Console.WriteLine($"{child.ChildFirstName} {child.ChildLastName} {child.ChildBirthDate}");
        }
    }

    private static void SettingRelativesFullInfo(Person person, List<string> relativesFullInfo)
    {
        for (int i = 0; i < relativesFullInfo.Count; i++)
        {
            var relativesInfo = relativesFullInfo[i]
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string relativeFirstName = relativesInfo[0];
            string relativeLastName = relativesInfo[1];
            string relativeBirthDate = relativesInfo[2];

            for (int j = 0; j < person.Parents.Count; j++)
            {
                if (person.Parents[j].ParentFirstName == relativeFirstName 
                    && person.Parents[j].ParentLastName == relativeLastName 
                    && person.Parents[j].ParentBirthDate == null)
                {
                    person.Parents[j].ParentBirthDate = relativeBirthDate;
                }
                else if (person.Parents[j].ParentBirthDate == relativeBirthDate 
                    && person.Parents[j].ParentFirstName == null 
                    && person.Parents[j].ParentLastName == null)
                {
                    person.Parents[j].ParentFirstName = relativeFirstName;
                    person.Parents[j].ParentLastName = relativeLastName;
                }
            }

            for (int j = 0; j < person.Children.Count; j++)
            {
                if (person.Children[j].ChildFirstName == relativeFirstName 
                    && person.Children[j].ChildLastName == relativeLastName 
                    && person.Children[j].ChildBirthDate == null)
                {
                    person.Children[j].ChildBirthDate = relativeBirthDate;
                }
                else if (person.Children[j].ChildFirstName == null
                    && person.Children[j].ChildLastName == null 
                    && person.Children[j].ChildBirthDate == relativeBirthDate)
                {
                    person.Children[j].ChildFirstName = relativeFirstName;
                    person.Children[j].ChildLastName = relativeLastName;
                }
            }
        }
    }

    private static void GettingParentsAndChildren(Person person, List<string> relativesPartialInfo)
    {
        for (int i = 0; i < relativesPartialInfo.Count; i++)
        {
            Parent parent = new Parent();
            Child child = new Child();

            if (Char.IsDigit(relativesPartialInfo[i][0]))
            {
                var partialInfoArgs = relativesPartialInfo[i]
                    .Split(new string[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);

                if (partialInfoArgs.Length == 2)
                {
                    string parentDate = partialInfoArgs[0];
                    string childDate = partialInfoArgs[1];
                    if (parentDate == person.PersonBirthDate)
                    {
                        child.ChildBirthDate = childDate;
                        person.Children.Add(child);
                    }
                    else if (childDate == person.PersonBirthDate)
                    {
                        parent.ParentBirthDate = parentDate;
                        person.Parents.Add(parent);
                    }
                }
                else if (partialInfoArgs.Length == 3)
                {
                    string parentDate = partialInfoArgs[0];
                    string childFirstName = partialInfoArgs[1];
                    string childLastName = partialInfoArgs[2];
                    if (parentDate == person.PersonBirthDate)
                    {
                        child.ChildFirstName = childFirstName;
                        child.ChildLastName = childLastName;
                        person.Children.Add(child);
                    }
                    else if (childFirstName == person.PersonFirstName && childLastName == person.PersonLastName)
                    {
                        parent.ParentBirthDate = parentDate;
                        person.Parents.Add(parent);
                    }
                }
            }
            else if(Char.IsLetter(relativesPartialInfo[i][0]))
            {
                var partialInfoArgs = relativesPartialInfo[i]
                    .Split(new string[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);

                if (partialInfoArgs.Length == 3)
                {
                    string parentFirstName = partialInfoArgs[0];
                    string parentLastName = partialInfoArgs[1];
                    string childDate = partialInfoArgs[2];
                    if (parentFirstName == person.PersonFirstName && parentLastName == person.PersonLastName)
                    {
                        child.ChildBirthDate = childDate;
                        person.Children.Add(child);
                    }
                    else if (person.PersonBirthDate == childDate)
                    {
                        parent.ParentFirstName = parentFirstName;
                        parent.ParentLastName = parentLastName;
                        person.Parents.Add(parent);
                    }
                }
                else if (partialInfoArgs.Length == 4)
                {
                    string parentFirstName = partialInfoArgs[0];
                    string parentLastName = partialInfoArgs[1];
                    string childFirstName = partialInfoArgs[2];
                    string childLastName = partialInfoArgs[3];
                    if (person.PersonFirstName == parentFirstName && person.PersonLastName == parentLastName)
                    {
                        child.ChildFirstName = childFirstName;
                        child.ChildLastName = childLastName;
                        person.Children.Add(child);
                    }
                    else if (person.PersonFirstName == childFirstName && person.PersonLastName == childLastName)
                    {
                        parent.ParentFirstName = parentFirstName;
                        parent.ParentLastName = parentLastName;
                        person.Parents.Add(parent);
                    }
                }
            }
        }
    }

    private static void GettingTargetPersonFullInfo(Person person, List<string> relativesFullInfo,string targetPerson)
    {
        if (Char.IsDigit(targetPerson[0]))
        {
            string targetPersonInfo = relativesFullInfo.First(x => x.Contains(targetPerson)).ToString();
            var targetPersonInfoArgs = targetPersonInfo
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string targetPersonFirstName = targetPersonInfoArgs[0];
            string targetPersonLastName = targetPersonInfoArgs[1];
            person.PersonFirstName = targetPersonFirstName;
            person.PersonLastName = targetPersonLastName;
        }
        else
        {
            string targetPersonInfo = relativesFullInfo.First(x => x.Contains(targetPerson)).ToString();
            var targetPersonInfoArgs = targetPersonInfo
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string targetPersonBirthDate = targetPersonInfoArgs[2];
            person.PersonBirthDate = targetPersonBirthDate;
        }
    }
}

