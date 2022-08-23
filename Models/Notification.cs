using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Notification
    {
        public string Id { get; set; } = null!;
        public string? UserId { get; set; }
        public string Msg { get; set; } = null!;
        public string? Thumb { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Nstatus { get; set; }

        public virtual User? User { get; set; }
    }
}
