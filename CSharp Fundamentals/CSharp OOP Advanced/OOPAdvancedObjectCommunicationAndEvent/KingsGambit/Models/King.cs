using System;
using System.Collections.Generic;
using System.Text;



public class King
{
    public event EventHandler AttackOnKing;

    private string name;

    public King(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            name = value;
        }
    }

    public void KingAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        if (AttackOnKing != null)
        {
            this.AttackOnKing(this, new EventArgs());
        }
    }
}
