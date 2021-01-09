using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseExtended.Interfaces
{
    public interface IPerson
    {
        long Id { get; }
        string UserName { get; }
    }
}
