using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Knife : IWeapon
{
    private const int MIN_DAMAGE = 3;
    private const int MAX_DAMAGE = 4;

    private string name;
    private int rarityMultiplier;
    private int minDamage;
    private int maxDamage;
    private string rarity;
    private IGem[] sockets;

    public Knife(string rarity, string name)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.MinDamage = MIN_DAMAGE;
        this.MaxDamage = MAX_DAMAGE;
        this.Sockets = new IGem[2];
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int MinDamage
    {
        get
        {
            return this.minDamage;
        }
        private set
        {
            this.minDamage = value * SetRarityMultiplier();
        }
    }

    public int MaxDamage
    {
        get
        {
            return this.maxDamage;
        }
        private set
        {
            this.maxDamage = value * SetRarityMultiplier();
        }
    }

    public string Rarity
    {
        get
        {
            return this.rarity;
        }
        private set
        {
            this.rarity = value;
        }
    }

    public IGem[] Sockets
    {
        get
        {
            return this.sockets;
        }
        set
        {
            this.sockets = value;
        }
    }

    public void AddGem(IGem gem, int index)
    {
        if (index >= 0 && index < this.sockets.Length)
        {
            if (this.sockets[index] != null)
            {
                RemoveGem(index);
            }

            this.sockets[index] = gem;
            this.maxDamage += SetMaxDamage(gem);
            this.minDamage += SetMinDamage(gem);
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.sockets.Length)
        {
            IGem gem = this.sockets[index];
            this.sockets[index] = null;
            this.maxDamage -= SetMaxDamage(gem);
            this.minDamage -= SetMinDamage(gem);
        }
    }

    private int SetRarityMultiplier()
    {
        switch (this.Rarity)
        {
            case "Common":
                this.rarityMultiplier = 1;
                break;
            case "Uncommon":
                this.rarityMultiplier = 2;
                break;
            case "Rare":
                this.rarityMultiplier = 3;
                break;
            case "Epic":
                this.rarityMultiplier = 5;
                break;
            default:
                break;
        }
        return this.rarityMultiplier;
    }

    private int SetMinDamage(IGem gem)
    {
        if (gem != null)
        {
            int totalMinDamagePoints = (gem.Strength * 2) + (gem.Agility * 1);
            return totalMinDamagePoints;
        }
        return 0;
    }

    private int SetMaxDamage(IGem gem)
    {
        if (gem != null)
        {
            int totalMaxDamagePoints = (gem.Strength * 3) + (gem.Agility * 4);
            return totalMaxDamagePoints;
        }
        return 0;
    }

    private int GetVitality()
    {
        int totalVitality = 0;
        foreach (var gem in this.Sockets.Where(s => s != null))
        {
            totalVitality += gem.Vitality;
        }
        return totalVitality;
    }

    private int GetAgility()
    {
        int totalAgility = 0;
        foreach (var gem in this.Sockets.Where(s => s != null))
        {
            totalAgility += gem.Agility;
        }
        return totalAgility;
    }

    private int GetStrength()
    {
        int totalStrength = 0;
        foreach (var gem in this.Sockets.Where(s => s != null))
        {
            totalStrength += gem.Strength;
        }
        return totalStrength;
    }

    public override string ToString()
    {
        int totalStrength = GetStrength();
        int totalAgility = GetAgility();
        int totalVitality = GetVitality();
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";
    }
}

