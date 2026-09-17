using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.contracts;
using TeamFlow.DB.enums;

namespace TeamFlow.DB.entities
{
    public class ProjectTask : IAuditableEntity, IDeleteFlagEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public Guid? AssignedUserId { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastUpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
