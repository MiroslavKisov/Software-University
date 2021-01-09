using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Engine
{
    private List<Footman> footmenLegion;
    private List<RoyalGuard> royalGuardsLegion;

    public Engine()
    {
        this.footmenLegion = new List<Footman>();
        this.royalGuardsLegion = new List<RoyalGuard>();
    }

    public void Run()
    {
        var kingName = Console.ReadLine();

        var royalGuards = Console.ReadLine().Split().ToList();

        var footmans = Console.ReadLine().Split().ToList();

        King king = new King(kingName);

        AddRoyalGuardsToLegion(royalGuards, royalGuardsLegion, king);
        AddFootManToLegion(footmans, footmenLegion, king);

        string commandInput;
        while ((commandInput = Console.ReadLine()) != "End")
        {
            var commandArgs = commandInput.Split();
            var command = commandArgs[0];
            var name = commandArgs[1];

            switch (command)
            {
                case "Attack":

                    king.KingAttack();

                    break;

                case "Kill":

                    KillGuards(name, royalGuardsLegion, king);
                    KillFootmen(name, footmenLegion, king);
                    break;

                default:
                    break;
            }
        }
    }

    private void KillFootmen(string name, List<Footman> footmenLegion, King king)
    {
        var killedFootman = footmenLegion.FirstOrDefault(x => x.Name == name);
        if (killedFootman != null)
        {
            killedFootman.StopGuardingTheKing(king);
            footmenLegion.RemoveAll(f => f.Name == name);
        }
    }

    private void KillGuards(string name, List<RoyalGuard> royalGuardsLegion, King king)
    {
        var killedRoyalGuard = royalGuardsLegion.FirstOrDefault(x => x.Name == name);
        if (killedRoyalGuard != null)
        {
            killedRoyalGuard.StopGuardingTheKing(king);
            royalGuardsLegion.RemoveAll(r => r.Name == name);
        }
    }

    private void AddRoyalGuardsToLegion(List<string> royalGuards, List<RoyalGuard> royalGuardsLegion, King king)
    {
        foreach (var royalGuard in royalGuards)
        {
            RoyalGuard r = new RoyalGuard(royalGuard);
            r.GuardTheKing(king);
            royalGuardsLegion.Add(r);
        }
    }

    private void AddFootManToLegion(List<string> footmen, List<Footman> footmenLegion, King king)
    {
        foreach (var footman in footmen)
        {
            Footman f = new Footman(footman);
            f.GuardTheKing(king);
            footmenLegion.Add(f);
        }
    }
}


