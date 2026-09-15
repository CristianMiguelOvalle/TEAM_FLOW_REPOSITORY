using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.DB
{
    public class TeamFlowContext : DbContext
    {
        public TeamFlowContext(DbContextOptions options) : base(options)
        {
        }
    }
}
