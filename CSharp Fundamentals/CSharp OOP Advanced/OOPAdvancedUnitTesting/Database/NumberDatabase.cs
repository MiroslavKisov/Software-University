using System;
using System.Collections.Generic;
using System.Text;


public class NumberDatabase
{
    private const int DATABASE_SIZE = 16;
    private List<int> numbers;

    public NumberDatabase(int[] inputNumbers)
    {
        this.Numbers = new List<int>(inputNumbers);
    }

    public List<int> Numbers
    {
        get { return numbers; }
        set
        {
            if (value.Count > 16)
            {
                throw new InvalidOperationException("Invalid database size!");
            }
            numbers = value;
        }
    }

    public void AddInteger(int number)
    {
        if (this.Numbers.Count >= 16)
        {
            throw new InvalidOperationException("Not enough space in database!");
        }

        this.Numbers.Insert(0, number);
    }

    public void RemoveItem()
    {
        if (this.Numbers.Count == 0)
        {
            throw new InvalidOperationException("Database is already empty!");
        }

        this.Numbers.RemoveAt(this.Numbers.Count - 1);
    }

    public int[] Fetch()
    {
        int[] numbersReturned = this.Numbers.ToArray();
        return numbersReturned;
    }
}

