using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Service
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string RoleId { get; set; } = null!;
        public string? Thumbnail { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
