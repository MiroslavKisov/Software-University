using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    where T : IComparable
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

    public int CountGreaterThan(T element)
    {
        int counter = 0;
        foreach (var v in this.Values)
        {
            if (v.CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
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
