using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Sorter<T>
    where T : IComparable
{
    public static void Sort(List<T> values)
    {
        values.Sort();
    }
}

