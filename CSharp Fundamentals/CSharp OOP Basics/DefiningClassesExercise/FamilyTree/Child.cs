using System;
using System.Collections.Generic;
using System.Text;


public class Child
{
    private string childFirstName;
    private string childLastName;
    private string childBirthDate;      

    public string ChildLastName
    {
        get { return childLastName; }
        set { childLastName = value; }
    }

    public string ChildBirthDate
    {
        get { return childBirthDate; }
        set { childBirthDate = value; }
    }

    public string ChildFirstName
    {
        get { return childFirstName; }
        set { childFirstName = value; }
    }

    public Child()
    {
        ChildFirstName = childFirstName;
        ChildLastName = childLastName;
        ChildBirthDate = childBirthDate;
    }
}

