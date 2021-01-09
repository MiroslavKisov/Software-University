using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    public string TypeName { get; set; }
    public T Value { get; set; }

    public Box(T value)
    {
        this.Value = value;
        this.TypeName = string.Empty;
    }

    public override string ToString()
    {
        return $"{TypeName.GetType().FullName}: {this.Value}";
    }
}

