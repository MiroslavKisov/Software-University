using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IID
{
    public Citizen(string name, string birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    public string Name { get; set; }

    public string BirthDate { get; set; }
}

