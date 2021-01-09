using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeNow.Interfaces
{
    public interface IDateTime
    {
        //DateTime DTNow { get; set; }

        DateTime AddDays(int days);
    }
}
