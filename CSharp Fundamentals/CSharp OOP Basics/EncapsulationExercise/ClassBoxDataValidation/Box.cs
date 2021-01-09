using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    private double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }

            height = value;
        }
    }

    private double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }

            width = value;
        }
    }

    private double Length
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }

            length = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double CalculateLateralSurface()
    {
        return 2 * (height * length) + 2 * (height * width);
    }

    public double CalculateFullSurface()
    {
        return 2 * (width * length) + 2 * (height * length) + 2 * (height * width);
    }

    public double CalculateVolume()
    {
        return width * height * length;
    }
}

