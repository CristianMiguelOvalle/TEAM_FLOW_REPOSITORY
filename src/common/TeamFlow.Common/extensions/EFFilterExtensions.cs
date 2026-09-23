using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TeamFlow.Common.contracts;

namespace TeamFlow.Common.extensions
{
    public static class EFFilterExtensions
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
              .Invoke(null, new object[] { modelBuilder });
        }

        public static void SetSoftDeleteFilter<TEntity>(
            this ModelBuilder modelBuilder)
            where TEntity : class, IDeleteFlagEntity
        {
            modelBuilder.Entity<TEntity>()
                .HasQueryFilter(entity => !entity.IsDelete);
        }

        private static readonly MethodInfo SetSoftDeleteFilterMethod =
            typeof(EFFilterExtensions)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(method =>
                    method.IsGenericMethod &&
                    method.Name == nameof(SetSoftDeleteFilter));
    }
}
