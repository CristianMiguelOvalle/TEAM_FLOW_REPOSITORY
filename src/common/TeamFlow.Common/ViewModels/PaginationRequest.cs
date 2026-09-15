using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.Common.ViewModels
{
    public class PaginationRequest<T>
    {
        public T? Params { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
