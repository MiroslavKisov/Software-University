using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private decimal weekSalary;
    private decimal workingHours;

    public decimal WorkingHours
    {
        get { return workingHours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            workingHours = value;
        }
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            weekSalary = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }

    public decimal GetSalaryPerHour()
    {
        decimal salaryPerHour = this.WeekSalary / (this.WorkingHours * 5.0m);
        return salaryPerHour;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}" + Environment.NewLine +
               $"Last Name: {this.LastName}" + Environment.NewLine +
               $"Week Salary: {this.WeekSalary:F2}" + Environment.NewLine +
               $"Hours per day: {this.WorkingHours:F2}" + Environment.NewLine +
               $"Salary per hour: {GetSalaryPerHour():F2}";
    }
}

