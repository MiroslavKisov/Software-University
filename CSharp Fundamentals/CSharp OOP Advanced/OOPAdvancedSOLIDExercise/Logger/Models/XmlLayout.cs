using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class XmlLayout : ILayout
    {
        public string SetFormat(string[] text)
        {
            return string.Format("<log>" + Environment.NewLine
                + "    <date>{1}</date>" + Environment.NewLine
                + "    <level>{0}</level>" + Environment.NewLine
                + "    <message>{2}</message>" + Environment.NewLine
                + "</log>"
                + Environment.NewLine, text);
        }
    }
}
