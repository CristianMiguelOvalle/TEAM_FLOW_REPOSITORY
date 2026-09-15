using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.enums;

namespace TeamFlow.DB.entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
