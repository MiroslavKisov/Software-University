using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Engine
{
    public void Run()
    {
        Controller controller = new Controller();
        string input;
        while((input = Console.ReadLine()) != "END")
        {
            List<string> args = input.Split(';').ToList();

            string weaponName = string.Empty;
            string command = args[0];
            int gemIndex = 0;
            args.RemoveAt(0);

            switch (command)
            {
                case "Create":
                    WeaponFactory weaponFactory = new WeaponFactory();
                    IWeapon weapon = weaponFactory.Create(args);
                    controller.AddWeaponToStash(weapon);
                    break;

                case "Add":
                    weaponName = args[0];
                    string gemInfo = args[2];
                    gemIndex = int.Parse(args[1]);
                    GemFactory gemFactory = new GemFactory();
                    IGem gem = gemFactory.Create(gemInfo);
                    controller.InsertGemToWeapon(weaponName, gem, gemIndex);
                    break;

                case "Remove":
                    weaponName = args[0];
                    gemIndex = int.Parse(args[1]);
                    controller.RemoveGemFromWeapon(weaponName, gemIndex);
                    break;

                default:
                    break;
            }
        }
    }
}

