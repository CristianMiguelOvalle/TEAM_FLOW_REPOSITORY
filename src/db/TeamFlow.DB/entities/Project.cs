using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.contracts;
using TeamFlow.DB.enums;

namespace TeamFlow.DB.entities
{
    public class Project : IAuditableEntity, IDeleteFlagEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastUpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
