using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TeamFlow.DB.enums
{
    public enum ProjectMemberRoleEnum
    {
        [Description("Dueño")]
        Owner = 0,
        [Description("Administrador")]
        Admin = 1,
        [Description("Mienbro")]
        Member = 2,
        [Description("Viewer")]
        Viewer = 3,

    }
}
