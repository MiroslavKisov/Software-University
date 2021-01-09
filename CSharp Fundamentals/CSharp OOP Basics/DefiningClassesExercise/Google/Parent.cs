using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    private string parentName;
    private string parentBirthDate;

    public string ParentBirthDate
    {
        get { return parentBirthDate; }
        set { parentBirthDate = value; }
    }

    public string ParentName
    {
        get { return parentName; }
        set { parentName = value; }
    }

    public Parent(string parentName,string parentBirthDate)
    {
        ParentName = parentName;
        ParentBirthDate = parentBirthDate;
    }

    public override string ToString()
    {
        return $"{ParentName} {ParentBirthDate}";
    }
}

