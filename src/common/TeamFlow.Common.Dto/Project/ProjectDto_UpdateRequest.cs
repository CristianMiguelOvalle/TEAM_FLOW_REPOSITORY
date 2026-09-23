using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.enums;

namespace TeamFlow.Common.Dto.Project
{
    public class ProjectDto_UpdateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatusEnum Status  { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsActive { get; set; }
    }
}
