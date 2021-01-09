using System;
using System.Collections.Generic;
using System.Text;


public abstract class Guard : IGuard
{
    private string name;

    public Guard(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public void GuardTheKing(King king)
    {
        king.AttackOnKing += RespondToAttack;
    }

    public void StopGuardingTheKing(King king)
    {
        king.AttackOnKing -= RespondToAttack;
    }

    public abstract void RespondToAttack(object sender, EventArgs e);
}

