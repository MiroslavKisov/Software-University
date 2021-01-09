using DatabaseExtended.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Person : IPerson
{
    private long id;
    private string userName;

    public Person(string userName, long id)
    {
        this.UserName = userName;
        this.Id = id;
    }

    public string UserName
    {
        get
        {
            return userName;
        }
        set
        {
            userName = value;
        }
    }

    public long Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
}

