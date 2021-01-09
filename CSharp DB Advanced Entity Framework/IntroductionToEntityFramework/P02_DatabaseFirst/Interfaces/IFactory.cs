using P02_DatabaseFirst.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_DatabaseFirst.Interfaces
{
    internal interface IFactory
    {
        SoftUniContext CreateContext();
    }
}
