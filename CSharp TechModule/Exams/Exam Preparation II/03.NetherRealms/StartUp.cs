using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.NetherRealms
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> result = new List<string>();
            string healthPattern = @"[^0-9\.\-\+\*\/]";
            string damagePattern = @"((\+|\-)?(\d+)(\.\d+)?)";
            var demons = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Regex regexHealth = new Regex(healthPattern);
            Regex regexDamage = new Regex(damagePattern);
            for (int i = 0; i < demons.Count; i++)
            {
                int totalHealth = 0;
                double totalDamage = 0.0d;
                MatchCollection healthMatches = Regex.Matches(demons[i], healthPattern);
                MatchCollection damageMatches = Regex.Matches(demons[i], damagePattern);
                int mult = demons[i].Where(c => c == '*').Count();
                int dev = demons[i].Where(c => c == '/').Count();
                totalHealth = GetHealth(totalHealth, healthMatches);
                totalDamage = GetDamage(totalDamage, damageMatches, mult, dev);
                result.Add(demons[i] + " " + "-" + " " + totalHealth + " health, " + totalDamage.ToString(string.Format("F2")) + " damage");
            }
            foreach (var demon in result.OrderBy(x => x))
            {
                Console.WriteLine(demon);
            }
        }

        private static int GetHealth(int totalHealth, MatchCollection healthMatches)
        {
            foreach (Match match in healthMatches)
            {
                string m = match.Value;
                totalHealth += Convert.ToChar(m);
            }

            return totalHealth;
        }

        private static double GetDamage(double totalDamage, MatchCollection damageMatches, int mult, int dev)
        {
            foreach (Match match in damageMatches)
            {
                double damage = double.Parse(match.Value);
                totalDamage += damage;
            }
            if (mult > 0)
            {
                for (int j = 0; j < mult; j++)
                {
                    totalDamage *= 2;
                }
            }
            if (dev > 0)
            {
                for (int j = 0; j < dev; j++)
                {
                    totalDamage /= 2;
                }
            }

            return totalDamage;
        }
    }
}
