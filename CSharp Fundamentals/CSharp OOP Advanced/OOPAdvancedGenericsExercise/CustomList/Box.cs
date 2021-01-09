using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Box<T>
    where T : IComparable
{
    public List<T> Values { get; set; }
    public Box()
    {
        this.Values = new List<T>();
    }

    public void AddValue(T element)
    {
        Values.Add(element);
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

    public void Remove(int index)
    {
        this.Values.RemoveAt(index);
    }

    public bool Contains(T element)
    {
        if (this.Values.Contains(element))
        {
            return true;
        }

        return false;
    }

    public void SwapValues(int[] swapParams)
    {
        var temp = this.Values[swapParams[0]];
        this.Values[swapParams[0]] = this.Values[swapParams[1]];
        this.Values[swapParams[1]] = temp;
    }

    public T Max()
    {
        return this.Values.Max();
    }

    public T Min()
    {
        return this.Values.Min();
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, this.Values);
    }
}

