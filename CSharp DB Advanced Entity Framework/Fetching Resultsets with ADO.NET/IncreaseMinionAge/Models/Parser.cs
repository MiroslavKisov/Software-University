using IncreaseMinionAge.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IncreaseMinionAge.Madels
{
    internal class Parser : IParser
    {
        public int[] ParseInput(string input)
        {
            return input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
        }
    }
}
