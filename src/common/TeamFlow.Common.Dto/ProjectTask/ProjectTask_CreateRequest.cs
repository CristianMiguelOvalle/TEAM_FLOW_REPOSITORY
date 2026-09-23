using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.enums;

namespace TeamFlow.Common.Dto.ProjectTask
{
    public class ProjectTask_CreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public Guid? AssignedUserId { get; set; }
    }
}
