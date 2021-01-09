using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.RoliTheCoder
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<EventAndParticipants>> participants = new Dictionary<string, List<EventAndParticipants>>();
            string pattern = @"([0-9]\s{1}#)(\w+\s{1})(?:@\w+\s{1})+";
            Regex regex = new Regex(pattern);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    break;
                }
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {

                }
            }
        }
    }
    class EventAndParticipants
    {
        public string EventName { get; set; }
        public List<string> Participants { get; set; }
        public EventAndParticipants()
        {
            Participants = new List<string>();
        }
    }
}
