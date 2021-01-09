using Hack.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hack
{
    public class MathHack : IMath
    {
        public int Abs(double inputNumber)
        {
            return (int)Math.Abs(inputNumber);
        }

        public int Floor(double inputNumber)
        {
            return (int)Math.Floor(inputNumber);
        }
    }
}
