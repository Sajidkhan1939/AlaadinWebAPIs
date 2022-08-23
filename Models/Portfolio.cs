using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Portfolio
    {
        public string Id { get; set; } = null!;
        public string? Type { get; set; }
        public string? Media { get; set; }
        public string Title { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? Description { get; set; }
        public string? ServicesIds { get; set; }
        public string? ListingId { get; set; }

        public virtual Listing? Listing { get; set; }
    }
}
