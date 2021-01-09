using System;
using System.Collections.Generic;
using System.Text;


public class Book
{
    private string author;
    private string title;
    private decimal price;

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            string[] fullName = value.Split();
            if (fullName.Length == 2)
            {
                char firstCh = fullName[1][0];
                if (Char.IsDigit(firstCh))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine +
            $"Title: {this.Title}" + Environment.NewLine +
            $"Author: {this.Author}" + Environment.NewLine +
            $"Price: {this.Price:F2}";
    }
}

