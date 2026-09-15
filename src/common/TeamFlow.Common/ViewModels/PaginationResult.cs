using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TeamFlow.Common.ViewModels
{
    public class PaginationResult<T>
    {
        public int PageCount { get; set; }
        public int? NumberRecords { get; set; }
        public IEnumerable<T> List { get; set; }
    }

    public static class PaginationResultExtension<T>
    {

        public static PaginationResult<T> SetGridPaginationResult(List<T> list, int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;
            var grid = new PaginationResult<T>();
            var numberRecords = list.Count();
            grid.NumberRecords = numberRecords;
            grid.List = list.Skip(skip).Take(pageSize).ToList();
            int pageCount = grid.NumberRecords.Value / pageSize;
            if (pageCount <= 0 || (grid.NumberRecords % pageSize) != 0)
            {
                pageCount += 1;
            }
            grid.PageCount = pageCount;
            return grid;
        }
        public async static Task<PaginationResult<T>> SetGridPaginationResult(IQueryable<T> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            int skip = (pageNumber - 1) * pageSize;
            var grid = new PaginationResult<T>();
            var numberRecords = await queryable.CountAsync();
            grid.NumberRecords = numberRecords;
            grid.List = await queryable.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);

            int pageCount = grid.NumberRecords.Value / pageSize;
            if (pageCount <= 0 || (grid.NumberRecords % pageSize) != 0)
            {
                pageCount += 1;
            }
            grid.PageCount = pageCount;
            return grid;
        }
    }
}
