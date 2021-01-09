using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    public List<T> Values { get; set; }
    public Box()
    {
        this.Values = new List<T>();
    }

    public void AddValue(T value)
    {
        Values.Add(value);
    }

    public void SwapValues(int[] swapParams)
    {
        var temp = this.Values[swapParams[0]];
        this.Values[swapParams[0]] = this.Values[swapParams[1]];
        this.Values[swapParams[1]] = temp;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var v in this.Values)
        {
            sb.AppendLine($"{v.GetType().FullName}: {v}");
        }
        return sb.ToString();
    }
}

