using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.enums;

namespace TeamFlow.Common.Dto.ProjectTask
{
    public class ProjectTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public Guid? AssignedUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
