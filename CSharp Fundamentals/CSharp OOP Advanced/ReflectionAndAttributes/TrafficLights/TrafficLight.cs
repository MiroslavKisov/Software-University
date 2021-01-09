using System;
using System.Collections.Generic;
using System.Text;


public class TrafficLight
{
    private string light;

    public TrafficLight(string light)
    {
        this.Light = light;
    }

    public string Light
    {
        get
        {
            return light;
        }
        private set
        {
            light = value;
        }
    }

}

