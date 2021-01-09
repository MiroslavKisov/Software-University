using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string personFirstName;
    private string personLastName;
    private List<Parent> parents;
    private List<Child> children;
    private string personBirthDate;

    public string PersonBirthDate
    {
        get { return personBirthDate; }
        set { personBirthDate = value; }
    }

    public string PersonLastName
    {
        get { return personLastName; }
        set { personLastName = value; }
    }

    public List<Child> Children
    {
        get { return children; }
        set { children = value; }
    }

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public string PersonFirstName
    {
        get { return personFirstName; }
        set { personFirstName = value; }
    }

    public Person()
    {
        PersonFirstName = personFirstName;
        PersonLastName = personLastName;
        PersonBirthDate = personBirthDate;
        Parents = new List<Parent>();
        Children = new List<Child>();
    }
}

