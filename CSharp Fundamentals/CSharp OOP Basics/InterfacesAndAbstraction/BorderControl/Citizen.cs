using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IID
{
    public Citizen(string name, string age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }

    public string Age { get; set; }

    public string Name { get; set; }

    public string Id { get; set; }

    public bool GetID(string bannedId)
    {
        if (this.Id.EndsWith(bannedId))
        {
            return true;
        }

        return false;
    }
}

