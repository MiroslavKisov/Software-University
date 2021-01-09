using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class SmartPhone : IBrowsable, ICalable
{

    private string url;

    private string phoneNumber;

    Regex regex = new Regex(@"\D");

    public string PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
        set
        {
            Match match = Regex.Match(value, @"\D");

            if (match.Success)
            {
                throw new ArgumentException("Invalid number!");
            }

            phoneNumber = value;
        }
    }

    public string Url
    {
        get
        {
            return url;
        }
        set
        {
            Match match = Regex.Match(value, @"\d+");

            if (match.Success)
            {
                throw new ArgumentException("Invalid URL!");
            }

            url = value;
        }
    }

    public string Browse(string Url)
    {
        return $"Browsing: {this.Url}!";
    }

    public string Calling(string PhoneNumber)
    {
        return $"Calling... {this.PhoneNumber}";
    }
}

