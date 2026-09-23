using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.contracts;
using TeamFlow.Common.extensions;
using TeamFlow.DB.entities;

namespace TeamFlow.DB
{
    public class TeamFlowContext : DbContext
    {
        public TeamFlowContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeamFlowContext).Assembly);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IDeleteFlagEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<User> Users { get; set; }

        private void ApplyAudit()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTimeOffset.UtcNow;
                        break;
                }
            }
        }

        private void ApplyEntityRules()
        {
            foreach (var entry in ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added &&
                    entry.Entity.Id == Guid.Empty)
                {
                    entry.Entity.Id = Guid.NewGuid();
                }
            }
        }
        public override int SaveChanges()
        {
            ApplyAudit();
            ApplyEntityRules();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAudit();
            ApplyEntityRules();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
