using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Faq
    {
        public string Id { get; set; } = null!;
        public string? ListingId { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;

        public virtual Listing? Listing { get; set; }
    }
}
