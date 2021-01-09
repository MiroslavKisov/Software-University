using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            Match match = Regex.Match(value, @"^[A-Za-z\d]{5,10}$");

            if (!match.Success)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) 
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}" + Environment.NewLine +
               $"Last Name: {this.LastName}" + Environment.NewLine +
               $"Faculty number: {this.FacultyNumber}";
    }
}

