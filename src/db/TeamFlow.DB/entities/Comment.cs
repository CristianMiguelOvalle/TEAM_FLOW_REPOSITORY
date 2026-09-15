using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlow.DB.entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
