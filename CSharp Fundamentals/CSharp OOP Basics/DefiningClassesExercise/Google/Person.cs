using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;

    public List<Child> Children
    {
        get { return children; }
        set { children = value; }
    }

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public Person(string name)
    {
        Name = name;
        Parents = new List<Parent>();
        Children = new List<Child>();
        Pokemons = new List<Pokemon>();
    }
}

