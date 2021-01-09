using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        List<IAppender> Appenders { get; set; }

        void GetLoggerInfo(int numberOfConsoleMessages, int numberOfFileMessages, StringBuilder sb);
    }
}
