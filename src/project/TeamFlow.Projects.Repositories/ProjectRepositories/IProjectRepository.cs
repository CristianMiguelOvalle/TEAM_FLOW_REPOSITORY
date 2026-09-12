using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.entities;

namespace TeamFlow.Projects.Repositories.ProjectRepositories
{
    public interface IProjectRepository
    {
        List<Project> GetProjectList();
    }
}
