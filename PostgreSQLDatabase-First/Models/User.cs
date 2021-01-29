using System;
using System.Collections.Generic;

#nullable disable

namespace PostgreSQLDatabase_First.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
