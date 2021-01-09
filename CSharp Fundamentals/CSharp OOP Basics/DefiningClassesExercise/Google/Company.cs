using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    private string companyName;
    private string department;
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }
    public Company(string companyName, string department, decimal salary)
    {
        CompanyName = companyName;
        Department = department;
        Salary = salary;
    }
    public override string ToString()
    {
        return $"{CompanyName} {Department} {Salary:F2}";
    }
}

