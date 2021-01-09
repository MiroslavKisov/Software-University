using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    string Rarity { get;}

    IGem[] Sockets { get; }

    void AddGem(IGem gem, int index);

    void RemoveGem(int index);
}

