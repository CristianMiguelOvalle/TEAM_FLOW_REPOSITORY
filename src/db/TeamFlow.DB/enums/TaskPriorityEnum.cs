using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TeamFlow.DB.enums
{
    public enum TaskPriorityEnum
    {
        [Description("Baja")]
        Low = 0,
        [Description("Media")]
        Medium = 1,
        [Description("Alta")]
        High = 2,
        [Description("Crtica")]
        Critical = 3,
    }
}
