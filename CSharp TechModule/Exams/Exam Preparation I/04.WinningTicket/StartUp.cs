using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.WinningTicket
{
    public class StartUp
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string patternAt = @"(\@{6,10})";
            string patternDs = @"(\#{6,10})";
            string patternNor = @"(\^{6,10})";
            string patternDollar = @"(\${6,10})";

            Regex regexAt = new Regex(patternAt);
            Regex regexDs = new Regex(patternDs);
            Regex regexNor = new Regex(patternNor);
            Regex regexDollar = new Regex(patternDollar);

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                int symbolCount = 0;
                string firstPart = tickets[i].Substring(0, 10);
                string secondPart = tickets[i].Substring(10);
                Match matchFirstPartAt = regexAt.Match(firstPart);
                Match matchSecondPartAt = regexAt.Match(secondPart);
                Match matchFirstPartDs = regexDs.Match(firstPart);
                Match matchSecondPartDs = regexDs.Match(secondPart);
                Match matchFirstPartNor = regexNor.Match(firstPart);
                Match matchSecondPartNor = regexNor.Match(secondPart);
                Match matchFirstPartDollar = regexDollar.Match(firstPart);
                Match matchSecondPartDollar = regexDollar.Match(secondPart);

                if (matchFirstPartAt.Success && matchSecondPartAt.Success)
                {
                    symbolCount = ProcessTicket(tickets[i], '@');
                    PrintTicket(symbolCount, tickets[i], '@');
                }
                else if (matchFirstPartDs.Success && matchSecondPartDs.Success)
                {
                    symbolCount = ProcessTicket(tickets[i], '#');
                    PrintTicket(symbolCount, tickets[i], '#');
                }
                else if (matchFirstPartNor.Success && matchSecondPartNor.Success)
                {
                    symbolCount = ProcessTicket(tickets[i], '^');
                    PrintTicket(symbolCount, tickets[i], '^');
                }
                else if (matchFirstPartDollar.Success && matchSecondPartDollar.Success)
                {
                    symbolCount = ProcessTicket(tickets[i], '$');
                    PrintTicket(symbolCount, tickets[i], '$');
                }
                else
                {
                    Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                }
            }
        }
        public static int ProcessTicket(string currentTicket,char symbol)
        {
            string firstPart = currentTicket.Substring(0, 10);
            string secondPart = currentTicket.Substring(10);
            int symbolCount = 0;
            int symbolCountFirstPart = 0;
            int symbolCountSecondPart = 0;
            symbolCountFirstPart = firstPart.Where(x => x == symbol).Count();
            symbolCountSecondPart = secondPart.Where(x => x == symbol).Count();
            symbolCount = Math.Min(symbolCountFirstPart, symbolCountSecondPart);
            return symbolCount;
        }

        public static void PrintTicket(int symbolCount,string currentTicket,char symbol)
        {
            if (symbolCount >= 1 && symbolCount <= 9)
            {
                Console.WriteLine($"ticket \"{currentTicket}\" - {symbolCount}{symbol}");
            }
            else
            {
                Console.WriteLine($"ticket \"{currentTicket}\" - {symbolCount}{symbol} Jackpot!");
            }
        }
    }
}
