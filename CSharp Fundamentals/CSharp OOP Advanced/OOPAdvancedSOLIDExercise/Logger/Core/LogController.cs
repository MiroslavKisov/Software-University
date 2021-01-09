using Logger.Interfaces;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Core
{
    public class LogController
    {
        private ILogger logger;

        public LogController()
        {
            logger = new Log();
        }

        public void Run()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string appenderInfo = Console.ReadLine();
                var appenderArgs = appenderInfo.Split(' ');

                ValidateInput(appenderArgs);

                logger.Appenders.Add(CreateAppender(appenderArgs));

            }

            StringBuilder sb = new StringBuilder();
            DisplayLogInfo(logger, sb);

            File.WriteAllText("log.txt", sb.ToString());
        }

        private void DisplayLogInfo(ILogger logger, StringBuilder sb)
        {
            int numberOfConsoleMessages = 0;
            int numberOfFileMessages = 0;
            string text;
            while ((text = Console.ReadLine()) != "END")
            {
                foreach (var appender in logger.Appenders.Where(x => x.GetType().Name == "ConsoleAppender"))
                {
                    string appenderLevel = appender.ReportLevel;
                    var textArgs = text.Split('|');

                    if (appenderLevel == null || appenderLevel == "INFO")
                    {
                        Console.WriteLine(appender.AppendMessage(text));
                        numberOfConsoleMessages++;
                    }
                    else if (appenderLevel == "WARNING")
                    {
                        if (!text.Contains("INFO"))
                        {
                            Console.WriteLine(appender.AppendMessage(text));
                            numberOfConsoleMessages++;
                        }
                    }
                    else if (appenderLevel == "ERROR")
                    {
                        if (!text.Contains("INFO") && !text.Contains("WARNING"))
                        {
                            Console.WriteLine(appender.AppendMessage(text));
                            numberOfConsoleMessages++;
                        }
                    }
                    else if (appenderLevel == "CRITICAL")
                    {
                        if (text.Contains("CRITICAL") || text.Contains("FATAL"))
                        {
                            Console.WriteLine(appender.AppendMessage(text));
                            numberOfConsoleMessages++;
                        }
                    }
                    else if (appenderLevel == "FATAL")
                    {
                        if (text.Contains("FATAL"))
                        {
                            Console.WriteLine(appender.AppendMessage(text));
                            numberOfConsoleMessages++;
                        }
                    }

                }
                foreach (var appender in logger.Appenders.Where(x => x.GetType().Name == "FileAppender"))
                {
                    string appenderLevel = appender.ReportLevel;
                    var textArgs = text.Split('|');

                    if (appenderLevel == null || appenderLevel == "INFO")
                    {
                        sb.AppendLine(appender.AppendMessage(text));
                        numberOfFileMessages++;
                    }
                    else if (appenderLevel == "WARNING")
                    {
                        if (!text.Contains("INFO"))
                        {
                            sb.AppendLine(appender.AppendMessage(text));
                            numberOfFileMessages++;
                        }
                    }
                    else if (appenderLevel == "ERROR")
                    {
                        if (!text.Contains("INFO") && !text.Contains("WARNING"))
                        {
                            sb.AppendLine(appender.AppendMessage(text));
                            numberOfFileMessages++;
                        }
                    }
                    else if (appenderLevel == "CRITICAL")
                    {
                        if (text.Contains("CRITICAL") || text.Contains("FATAL"))
                        {
                            sb.AppendLine(appender.AppendMessage(text));
                            numberOfFileMessages++;
                        }
                    }
                    else if (appenderLevel == "FATAL")
                    {
                        if (text.Contains("FATAL"))
                        {
                            sb.AppendLine(appender.AppendMessage(text));
                            numberOfFileMessages++;
                        }
                    }
                }
            }
            logger.GetLoggerInfo(numberOfConsoleMessages, numberOfFileMessages, sb);
        }

        private IAppender CreateAppender(string[] appenderArgs)
        {
            if (appenderArgs[0] == "ConsoleAppender")
            {
                if (appenderArgs[1] == "SimpleLayout")
                {
                    IAppender consoleAppender = new ConsoleAppender(new SimpleLayout());
                    if (appenderArgs.Length > 2)
                    {
                        consoleAppender.ReportLevel = appenderArgs[2];
                    }
                    return consoleAppender;
                }
                else if (appenderArgs[1] == "XmlLayout")
                {
                    IAppender consoleAppender = new FileAppender(new XmlLayout());
                    if (appenderArgs.Length > 2)
                    {
                        consoleAppender.ReportLevel = appenderArgs[2];
                    }
                    return consoleAppender;
                }
            }
            else if (appenderArgs[0] == "FileAppender")
            {
                if (appenderArgs[1] == "SimpleLayout")
                {
                    IAppender fileAppender = new FileAppender(new SimpleLayout());
                    if (appenderArgs.Length > 2)
                    {
                        fileAppender.ReportLevel = appenderArgs[2];
                    }
                    return fileAppender;
                }
                else if (appenderArgs[1] == "XmlLayout")
                {
                    IAppender fileAppender = new FileAppender(new XmlLayout());
                    if (appenderArgs.Length > 2)
                    {
                        fileAppender.ReportLevel = appenderArgs[2];
                    }
                    return fileAppender;
                }
            }
            throw new ArgumentException("No such appender!");
        }

        private void ValidateInput(string[] appenderArgs)
        {
            if (appenderArgs.Length > 3 || appenderArgs.Length < 2)
            {
                throw new ArgumentException("Invalid appender info!");
            }
            else if (string.IsNullOrWhiteSpace(appenderArgs[0])
                && string.IsNullOrWhiteSpace(appenderArgs[1]))
            {
                throw new ArgumentException("Invalid Appender Info!");
            }
        }
    }
}
