using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.DB.entities
{
    public class ProjectTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
