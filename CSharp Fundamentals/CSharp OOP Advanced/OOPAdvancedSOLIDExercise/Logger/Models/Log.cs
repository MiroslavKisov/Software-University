using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Models
{
    public class Log : ILogger
    {
        public Log()
        {
            Appenders = new List<IAppender>();
        }

        public List<IAppender> Appenders { get; set; }

        public void GetLoggerInfo(int numberOfConsoleMessages ,int numberOfFileMessages, StringBuilder sb)
        {
            foreach (var appender in Appenders)
            {
                string appenderType = appender.GetType().Name;
                string layoutType = appender.LayoutType;
                string reportLevel = appender.ReportLevel;
                int sum = 0;
                if (appenderType == "FileAppender")
                {
                    foreach (var s in sb.ToString())
                    {
                        if (Char.IsLetter(s))
                        {
                            sum += s;
                        }
                    }
                }
                if (appenderType == "ConsoleAppender")
                {
                    Console.WriteLine($"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, Messages appended: {numberOfConsoleMessages}");
                }
                else if (appenderType == "FileAppender")
                {
                    Console.WriteLine($"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, Messages appended: {numberOfFileMessages}, File size: {sum}");
                }
            }
        }
    }
}
