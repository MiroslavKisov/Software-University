using System;
using System.Collections.Generic;
using System.Text;


public class Tuple<T1,T2>
{
    private T1 item1;
    private T2 item2;

    public T2 Item2
    {
        get { return item2; }
        set { item2 = value; }
    }

    public T1 Item1
    {
        get { return item1; }
        set { item1 = value; }
    }

    public Tuple(T1 item1, T2 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2}";
    }
}

