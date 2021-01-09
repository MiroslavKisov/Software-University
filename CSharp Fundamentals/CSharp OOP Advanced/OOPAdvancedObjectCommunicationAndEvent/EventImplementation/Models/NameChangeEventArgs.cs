using System;
using System.Collections.Generic;
using System.Text;

public class NameChangeEventArgs : EventArgs
{
    private string name;

    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return name;
        }

        private set
        {
            name = value;
        }
    }

}

