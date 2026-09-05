using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TeamFlow.DB.enums
{
    public enum ProjectStatusEnum
    {
        [Description("Ninguno")]
        None = 0,
        [Description("Creado")]
        Created = 0,
        [Description("En proceso")]
        InProgress = 0,
        [Description("Pending")]
        Pending = 0,
        [Description("Terminado")]
        Done = 0
    }
}
