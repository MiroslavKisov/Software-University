using System;
using System.Collections.Generic;
using System.Text;


public class Child
{
    private string childName;
    private string childBirthDate;

    public string ChildBirthDate
    {
        get { return childBirthDate; }
        set { childBirthDate = value; }
    }

    public string ChildName
    {
        get { return childName; }
        set { childName = value; }
    }

    public Child(string childName, string childBirthDate)
    {
        ChildName = childName;
        ChildBirthDate = childBirthDate;
    }

    public override string ToString()
    {
        return $"{ChildName} {ChildBirthDate}";
    }
}

