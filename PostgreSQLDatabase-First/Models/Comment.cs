using System;
using System.Collections.Generic;

#nullable disable

namespace PostgreSQLDatabase_First.Models
{
    public partial class Comment
    {
        public Comment()
        {
            WorkItemComments = new HashSet<WorkItemComment>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<WorkItemComment> WorkItemComments { get; set; }
    }
}
