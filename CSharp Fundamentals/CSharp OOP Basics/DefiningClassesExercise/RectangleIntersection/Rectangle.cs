using System;
using System.Collections.Generic;
using System.Text;


class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double pointX;
    private double pointY;

    public double PointY
    {
        get { return pointY; }
        set { pointY = value; }
    }

    public double PointX
    {
        get { return pointX; }
        set { pointX = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public Rectangle(string id, double width, double height, double pointX, double pointY)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.PointX = pointX;
        this.PointY = pointY;
    }
}

