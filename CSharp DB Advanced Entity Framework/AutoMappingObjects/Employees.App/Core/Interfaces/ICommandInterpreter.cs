using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string ReadCommand(string[] args);
    }
}
