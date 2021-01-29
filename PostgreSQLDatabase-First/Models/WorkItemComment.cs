using System;
using System.Collections.Generic;

#nullable disable

namespace PostgreSQLDatabase_First.Models
{
    public partial class WorkItemComment
    {
        public int Id { get; set; }
        public int WorkItemId { get; set; }
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual WorkItem WorkItem { get; set; }
    }
}
