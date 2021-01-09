using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : IFerrari
{
    public string Driver { get; set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }
}

