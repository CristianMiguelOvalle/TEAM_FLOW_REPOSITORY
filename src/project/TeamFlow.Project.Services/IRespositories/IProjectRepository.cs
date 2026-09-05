using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.entities;

namespace TeamFlow.Projects.Repository.IRespositories
{
    public interface IProjectRepository
    {
        List<Project> GetProjectList();
    }
}
