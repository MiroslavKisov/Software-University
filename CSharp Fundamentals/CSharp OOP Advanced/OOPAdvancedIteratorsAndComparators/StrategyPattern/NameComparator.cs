using System;
using System.Collections.Generic;
using System.Text;


public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int firstNameLength = x.Name.Length;
        int secondNameLength = y.Name.Length;

        int namesCompared = firstNameLength.CompareTo(secondNameLength);
        if (namesCompared != 0)
        {
            return namesCompared;
        }
        string firstName = x.Name.ToLower();
        string secondName = y.Name.ToLower();

        char firstLetterX = firstName[0];
        char firstLetterY = secondName[0];

        return firstLetterX.CompareTo(firstLetterY);
    }
}

