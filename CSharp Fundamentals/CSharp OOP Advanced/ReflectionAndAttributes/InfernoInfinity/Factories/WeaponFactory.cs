using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WeaponFactory
{
    public IWeapon Create(List<string> args)
    {
        var weaponInfo = args[0].Split();

        string weaponRarity = weaponInfo[0];
        string weaponType = weaponInfo[1];
        string weaponName = args[1];

        //Type type = typeof(IWeapon);

        //IWeapon weapon = null;

        switch (weaponType)
        {
            case "Axe":
                Type typeAxe = typeof(Axe);
                var axe = (Axe)Activator.CreateInstance(typeAxe, new object[] { weaponRarity, weaponName });
                return axe;

            case "Sword":
                Type typeSword = typeof(Sword);
                var sword = (Sword)Activator.CreateInstance(typeSword, new object[] { weaponRarity, weaponName });
                return sword;

            case "Knife":
                Type typeKnife = typeof(Knife);
                var knife = (Knife)Activator.CreateInstance(typeKnife, new object[] { weaponRarity, weaponName });
                return knife;

            default:
                break;
        }

        throw new ArgumentException("Incorrect weapon data!");
    }
}

