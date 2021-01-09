using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long stones = 0;
        long money = 0;

        for (int i = 0; i < safe.Length; i += 2)
        {
            string itemName = safe[i];
            long amount = long.Parse(safe[i + 1]);

            string item = string.Empty;

            if (itemName.Length == 3)
            {
                item = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                item = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                item = "Gold";
            }

            if (item == "")
            {
                continue;
            }
            else if (input < bag.Values.Select(treasure => treasure.Values.Sum()).Sum() + amount)
            {
                continue;
            }

            switch (item)
            {
                case "Gem":
                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (amount > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[item].Values.Sum() + amount > bag["Gold"].Values.Sum())
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (amount > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[item].Values.Sum() + amount > bag["Gem"].Values.Sum())
                    {
                        continue;
                    }
                    break;
            }

            if (!bag.ContainsKey(item))
            {
                bag[item] = new Dictionary<string, long>();
            }

            if (!bag[item].ContainsKey(itemName))
            {
                bag[item][itemName] = 0;
            }

            bag[item][itemName] += amount;
            if (item == "Gold")
            {
                gold += amount;
            }
            else if (item == "Gem")
            {
                stones += amount;
            }
            else if (item == "Cash")
            {
                money += amount;
            }
        }

        foreach (var treasure in bag)
        {
            Console.WriteLine($"<{treasure.Key}> ${treasure.Value.Values.Sum()}");
            foreach (var item in treasure.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }
}

