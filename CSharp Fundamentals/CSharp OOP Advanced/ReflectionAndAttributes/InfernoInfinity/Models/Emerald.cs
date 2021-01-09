using System;
using System.Collections.Generic;
using System.Text;


public class Emerald : IGem
{
    private const int STRENGTH = 1;
    private const int AGILITY = 4;
    private const int VITALITY = 9;

    private int clarityMultiplier;
    private int strength;
    private int agility;
    private int vitality;
    private string clarity;

    public Emerald(string clarity)
    {
        this.Clarity = clarity;
        this.Strength = STRENGTH;
        this.Agility = AGILITY;
        this.Vitality = VITALITY;
    }

    public int Strength
    {
        get
        {
            return this.strength;
        }
        set
        {
            this.strength = value + SetClarityMultiplier();
        }
    }
    public int Agility
    {
        get
        {
            return this.agility;
        }
        set
        {
            this.agility = value + SetClarityMultiplier();
        }
    }
    public int Vitality
    {
        get
        {
            return this.vitality;
        }
        set
        {
            this.vitality = value + SetClarityMultiplier();
        }
    }
    public string Clarity
    {
        get
        {
            return this.clarity;
        }
        set
        {
            this.clarity = value;
        }
    }

    private int SetClarityMultiplier()
    {
        switch (this.Clarity)
        {
            case "Chipped":
                this.clarityMultiplier = 1;
                break;

            case "Regular":
                this.clarityMultiplier = 2;
                break;

            case "Perfect":
                this.clarityMultiplier = 5;
                break;

            case "Flawless":
                this.clarityMultiplier = 10;
                break;
            default:
                break;
        }
        return this.clarityMultiplier;
    }
}

