using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Family
{
    private List<Person> persons;
    public Family()
    {
        persons = new List<Person>();
    }
    public List<Person> Persons
    {
        get { return this.persons; }
        set { this.persons = value; }
    }
    public void AddMember(Person member)
    {
        Persons.Add(member);
    }
    public Person GetOldestMember()
    {
        return Persons.OrderByDescending(x => x.Age).First();
    }
}

