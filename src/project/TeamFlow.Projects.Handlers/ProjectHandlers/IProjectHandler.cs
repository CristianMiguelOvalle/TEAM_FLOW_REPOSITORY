using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.entities;

namespace TeamFlow.Projects.Handlers.ProjectHandlers
{
    public interface IProjectHandler
    {
        public List<Project> GetProjectList();
    }
}
