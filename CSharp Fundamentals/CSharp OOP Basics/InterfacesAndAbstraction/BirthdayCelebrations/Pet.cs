using System;
using System.Collections.Generic;
using System.Text;


public class Pet : IID
{
    public Pet(string name, string birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    public string Name { get; set; }

    public string BirthDate { get; set; }
}

