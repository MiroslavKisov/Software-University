using DateTimeNow.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeNow
{
    public class DateTimeNow : IDateTime
    {
        //public DateTimeNow()
        //{
        //    this.DTNow = DateTime.Now;
        //}

        //public DateTime DTNow { get; set; }
        public DateTime AddDays(int days)
        {
            DateTime dt = DateTime.Now.AddDays(days);
            return dt;
        }
    }
}
