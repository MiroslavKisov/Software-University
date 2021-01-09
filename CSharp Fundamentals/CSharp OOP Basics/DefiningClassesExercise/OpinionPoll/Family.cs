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
    public List<Person> GetOldestThan30()
    {
        var prsn = Persons.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        return prsn;
    }
}
