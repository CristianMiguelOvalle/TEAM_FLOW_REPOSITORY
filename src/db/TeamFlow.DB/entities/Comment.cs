using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.contracts;

namespace TeamFlow.DB.entities
{
    public class Comment : IAuditableEntity, IDeleteFlagEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastUpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
