using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.Common.Dto.Project
{
    public class ProjectDto_UpdateRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
