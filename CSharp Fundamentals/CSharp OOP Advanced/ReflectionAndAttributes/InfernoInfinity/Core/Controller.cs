using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;


public class Controller
{
    private List<IWeapon> weapons;

    public Controller()
    {
        this.weapons = new List<IWeapon>();
    }

    public void InsertGemToWeapon(string weaponName, IGem gem, int gemIndex)
    {
        if (this.weapons.Count != 0)
        {
            IWeapon currentWeapon = this.weapons.First(x => x.Name == weaponName);
            currentWeapon.AddGem(gem, gemIndex);
        }
    }

    public void RemoveGemFromWeapon(string weaponName, int gemIndex)
    {
        if (this.weapons.Count != 0)
        {
            IWeapon currentWeapon = this.weapons.First(x => x.Name == weaponName);
            currentWeapon.RemoveGem(gemIndex);
        }
    }

    public void AddWeaponToStash(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public void PrintWeapon(string weaponName)
    {
        var currentWeapon = this.weapons.First(x => x.Name == weaponName);
        Console.WriteLine(currentWeapon);
    }
}