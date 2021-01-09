using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        public string SetFormat(string[] text)
        {
            return string.Format("{1} - {0} - {2}", text);
        }
    }
}
