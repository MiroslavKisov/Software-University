﻿using System;
using System.Collections.Generic;
using System.Text;


public class Human
{
    private string firstName;
    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}" + Environment.NewLine
            + $"Last Name: {this.LastName}" + Environment.NewLine;
    }
}

