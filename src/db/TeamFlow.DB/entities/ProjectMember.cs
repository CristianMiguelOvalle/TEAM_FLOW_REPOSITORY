using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.enums;

namespace TeamFlow.DB.entities
{
    public class ProjectMember
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public ProjectMemberRoleEnum Role { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
