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
        Created = 1,
        [Description("En proceso")]
        InProgress = 2,
        [Description("Pending")]
        Pending = 3,
        [Description("Archivado")]
        Archived = 4,
        [Description("Terminado")]
        Done = 5
    }
}
