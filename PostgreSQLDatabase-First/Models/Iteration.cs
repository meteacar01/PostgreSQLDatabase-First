using System;
using System.Collections.Generic;

#nullable disable

namespace PostgreSQLDatabase_First.Models
{
    public partial class Iteration
    {
        public Iteration()
        {
            WorkItems = new HashSet<WorkItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkItem> WorkItems { get; set; }
    }
}
