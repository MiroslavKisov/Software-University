using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_DatabaseFirst.Factories
{
    internal class ContextFactory : IFactory
    {
        public SoftUniContext CreateContext()
        {
            return new SoftUniContext();
        }
    }
}
