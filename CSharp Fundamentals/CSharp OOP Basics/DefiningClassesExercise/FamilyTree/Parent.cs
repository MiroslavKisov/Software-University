using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    private string parentFirstName;
    private string parentBirthDate;
    private string parentLastName;
    
    public string ParentLastName
    {
        get { return parentLastName; }
        set { parentLastName = value; }
    }

    public string ParentBirthDate
    {
        get { return parentBirthDate; }
        set { parentBirthDate = value; }
    }

    public string ParentFirstName
    {
        get { return parentFirstName; }
        set { parentFirstName = value; }
    }

    public Parent()
    {
        ParentFirstName = parentFirstName;
        ParentLastName = parentLastName;
        ParentBirthDate = parentBirthDate;
    }
}

