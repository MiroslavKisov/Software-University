using System;
using System.Collections.Generic;
using System.Text;


public class Cargo
{
    private string cargoType;
    private int cargoWeight;

    public int CargoWeight
    {
        get { return cargoWeight; }
        set { cargoWeight = value; }
    }

    public string CargoType
    {
        get { return cargoType; }
        set { cargoType = value; }
    }
    public Cargo(int cargoWeight, string cargoType)
    {
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
    }
}

