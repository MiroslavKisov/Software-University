using System;
using System.Collections.Generic;
using System.Text;


public class Robot : IID
{
    public Robot(string id, string model)
    {
        this.Id = id;
        this.Model = model;
    }

    public string Id { get; set; }

    public string Model { get; set; }

    public bool GetID(string bannedId)
    {
        if (this.Id.EndsWith(bannedId))
        {
            return true;
        }

        return false;
    }
}

