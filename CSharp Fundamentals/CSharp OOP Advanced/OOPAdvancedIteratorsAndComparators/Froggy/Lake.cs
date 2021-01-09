using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake : IEnumerable<int>
{
    private readonly List<int> list;

    public Lake(List<int> list)
    {
        this.list = list;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (list.Count % 2 != 0)
        {
            for (int i = 0; i < this.list.Count; i += 2)
            {
                yield return list[i];
            }
            for (int i = list.Count - 2; i > 0; i -= 2)
            {
                yield return list[i];
            }
        }
        else
        {
            for (int i = 0; i < this.list.Count; i += 2)
            {
                yield return list[i];
            }
            for (int i = list.Count - 1; i > 0; i -= 2)
            {
                yield return list[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

