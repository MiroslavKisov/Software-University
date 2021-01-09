using AddMinion.Interfaces;
using System;

namespace AddMinion
{
    internal class InputParser : IParser
    {
        public string[] ParseInput(string input)
        {
            string[] inputData = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return inputData;
        }
    }
}
