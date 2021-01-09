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
        get { return height; }
        set { height = value; }
    }

    private double Width
    {
        get { return width; }
        set { width = value; }
    }

    private double Length
    {
        get { return length; }
        set { length = value; }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double CalculateLateralSurface()
    {
        return 2 * (Height * Length) + 2 * (Height * Width);
    }

    public double CalculateFullSurface()
    {
        return 2 * (Width * Length) + 2 * (Height * Length) + 2 * (Height * Width);
    }

    public double CalculateVolume()
    {
        return Width * Height * Length;
    }
}

