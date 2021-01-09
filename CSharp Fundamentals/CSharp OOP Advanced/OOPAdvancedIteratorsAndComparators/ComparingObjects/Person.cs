using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Town { get; set; }

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }
    public int CompareTo(Person other)
    {
        int namesCompared = this.Name.CompareTo(other.Name);
        int ageCompared = this.Age.CompareTo(other.Age);
        int townCompared = this.Town.CompareTo(other.Town);

        if (namesCompared != 0)
        {
            return namesCompared;
        }

        if (ageCompared != 0)
        {
            return ageCompared;
        }

        return townCompared;
    }
}

