using System;
using System.Collections.Generic;
using System.Text;


 public class Trainer
{
    private string name;
    private List<Pokemon> pokemons;
    private int numberOfBadges;

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public Trainer(string name)
    {
        Name = name;
        Pokemons = new List<Pokemon>();
    }
}

