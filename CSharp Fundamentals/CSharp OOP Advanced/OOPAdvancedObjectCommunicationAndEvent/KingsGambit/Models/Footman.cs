using System;
using System.Collections.Generic;
using System.Text;


public class Footman : Guard
{
    public Footman(string name) : base(name)
    {

    }

    public override void RespondToAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}

