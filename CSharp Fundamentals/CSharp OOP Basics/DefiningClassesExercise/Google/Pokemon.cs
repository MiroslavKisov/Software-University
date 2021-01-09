using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    private string pokemonName;
    private string pokemonPower;

    public string PokemonPower
    {
        get { return pokemonPower; }
        set { pokemonPower = value; }
    }

    public string PokemonName
    {
        get { return pokemonName; }
        set { pokemonName = value; }
    }
    public Pokemon(string pokemonName, string pokemonPower)
    {
        PokemonName = pokemonName;
        PokemonPower = pokemonPower;
    }
    public override string ToString()
    {
        return $"{PokemonName} {PokemonPower}";
    }
}

