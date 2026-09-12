using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.enums;

namespace TeamFlow.Common.Dto.Project
{
    public class ProjectDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public bool IsActive { get; set; }

    }
}
