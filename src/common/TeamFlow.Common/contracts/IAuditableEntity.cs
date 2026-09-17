using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.Common.contracts
{
    public interface IAuditableEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastUpdatedDate { get; set; }
    }
}
