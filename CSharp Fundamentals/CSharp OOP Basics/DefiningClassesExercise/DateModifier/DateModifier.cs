using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


class DateModifier
{
    string firstDate;
    string secondDate;
    public string FirstDate
    {
        get { return this.firstDate; }
        set { this.firstDate = value; }
    }
    public string SecondDate
    {
        get { return this.secondDate; }
        set { this.secondDate = value; }
    }
    public DateModifier(string firstDate, string secondDate)
    {
        this.FirstDate = firstDate;
        this.SecondDate = secondDate;
    }
    public TimeSpan CalculateDifference(string firstDate, string secondDate)
    {
        DateTime fDate = DateTime.ParseExact(FirstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime sDate = DateTime.ParseExact(SecondDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        if (fDate >= sDate)
        {
            TimeSpan result = fDate.Subtract(sDate);
            return result;
        }
        else
        {
            TimeSpan result = sDate.Subtract(fDate);
            return result;
        }
    }
}

