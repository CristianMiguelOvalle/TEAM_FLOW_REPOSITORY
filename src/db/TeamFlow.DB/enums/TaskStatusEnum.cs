using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TeamFlow.DB.enums
{
    public enum TaskStatusEnum
    {
        [Description("En espera")]
        Todo = 0,
        [Description("En progreso")]
        InProgress = 1,
        [Description("Bloqueada")]
        Blocked = 2,
        [Description("Terminada")]
        Done = 3,

    }
}
