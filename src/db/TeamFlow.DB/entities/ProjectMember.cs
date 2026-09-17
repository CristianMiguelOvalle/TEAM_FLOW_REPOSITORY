using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.contracts;
using TeamFlow.DB.enums;

namespace TeamFlow.DB.entities
{
    public class ProjectMember : IAuditableEntity, IDeleteFlagEntity
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public ProjectMemberRoleEnum Role { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastUpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
