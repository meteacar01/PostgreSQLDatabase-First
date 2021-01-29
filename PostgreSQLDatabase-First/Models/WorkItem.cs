using System;
using System.Collections.Generic;

#nullable disable

namespace PostgreSQLDatabase_First.Models
{
    public partial class WorkItem
    {
        public WorkItem()
        {
            WorkItemComments = new HashSet<WorkItemComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int WorkItemTypeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IterationId { get; set; }
        public int AssignedTo { get; set; }
        public int WorkItemStateId { get; set; }

        public virtual Iteration Iteration { get; set; }
        public virtual WorkItemState WorkItemState { get; set; }
        public virtual WorkItemType WorkItemType { get; set; }
        public virtual ICollection<WorkItemComment> WorkItemComments { get; set; }
    }
}
