using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.entities;
using TeamFlow.DB.enums;

namespace TeamFlow.Projects.Repositories.ProjectRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        public List<Project> GetProjectList()
        {

            return new List<Project>()
            {
                new Project()
                {
                    CreatedAt = DateTime.Today,
                    Id = Guid.NewGuid(),
                    Description = "Description",
                    Name = "Fiury",
                    Status = ProjectStatusEnum.Created,
                    UpdateAt = null
                },

                new Project()
                {
                    CreatedAt = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    Description = "Description",
                    Name = "Caja fuerte",
                    Status = ProjectStatusEnum.InProgress,
                    UpdateAt = null
                },

                new Project()
                {
                    CreatedAt = DateTime.Now,
                    Id = Guid.NewGuid(),
                    Description = "Description",
                    Name = "SGM",
                    Status = ProjectStatusEnum.Done,
                    UpdateAt = null
                }
            };

        }
    }
}
