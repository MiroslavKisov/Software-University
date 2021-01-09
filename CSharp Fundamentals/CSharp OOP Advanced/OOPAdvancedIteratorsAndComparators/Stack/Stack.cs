using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Stack<T> : IEnumerable<string>
{
    private readonly List<string> list;

    public Stack()
    {
        this.list = new List<string>();
    }

    public void Push(List<string> args)
    {
        //args.Reverse();
        foreach (var item in args)
        {
            list.Insert(0, item);
        }
    }

    public void Pop()
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("No elements");
        }
        list.RemoveAt(0);
    }

    public void PrintAll()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
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

