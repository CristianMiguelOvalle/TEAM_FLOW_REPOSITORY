using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.Common.contracts
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
