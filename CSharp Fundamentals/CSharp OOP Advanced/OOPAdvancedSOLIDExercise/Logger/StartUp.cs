using Logger.Core;
using Logger.Interfaces;
using Logger.Models;
using System;

namespace Logger
{
    public class StartUp
    {
        public static void Main()
        {
            LogController logController = new LogController();
            logController.Run();
        }
    }
}
