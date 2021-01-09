using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Services.Contracts
{
    public interface ILogInService
    {
        void LogIn(string userName);
    }
}
