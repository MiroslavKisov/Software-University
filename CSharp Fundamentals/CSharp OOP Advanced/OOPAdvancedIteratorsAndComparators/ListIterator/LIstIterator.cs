using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ListEnumerator : IEnumerable<string>
{
    private readonly List<string> list;
    private int currentIndex = 0;

    public ListEnumerator()
    {
        this.list = new List<string>();
    }

    public void Create(List<string> args)
    {
        list.AddRange(args);
    }

    public void Print()
    {
        if (this.list.Count == 0)
        {
            throw new Exception("Invalid Operation!");
        }
        Console.WriteLine(list[currentIndex]);
    }

    public bool Move()
    {
        if (this.currentIndex >= this.list.Count - 1)
        {
            return false;
        }

        ++this.currentIndex;
        return true;
    }

    public bool HasNext()
    {
        if (list.Count - 1 > this.currentIndex)
        {
            return true;
        }
        return false;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

