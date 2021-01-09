using System;
using System.Collections.Generic;
using System.Text;


public interface IID
{
    string Id { get; set; }

    bool GetID(string bannedId);
}

