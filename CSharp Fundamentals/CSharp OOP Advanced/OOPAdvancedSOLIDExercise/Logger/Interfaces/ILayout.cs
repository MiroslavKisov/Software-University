using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    public interface ILayout
    {
        string SetFormat(string[] text);
    }
}
