using System;
using System.Collections.Generic;
using System.Text;

namespace TyrePressureMonitoringSystem.Interfaces
{
    public interface IAlarm
    {
        void Check();

        bool AlarmOn { get; }
    }
}
