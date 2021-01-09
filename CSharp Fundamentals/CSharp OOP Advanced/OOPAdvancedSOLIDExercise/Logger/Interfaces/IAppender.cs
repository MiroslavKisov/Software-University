using Logger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        string AppendMessage(string message);

        string LayoutType { get; set; }

        string ReportLevel { get; set; }

        SimpleLayout SimpleLayout { get; set; }

        XmlLayout XmlLayout { get; set; }
    }
}
