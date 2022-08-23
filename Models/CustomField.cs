using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class CustomField
    {
        public string Id { get; set; } = null!;
        public string? ListingId { get; set; }
        public string KeyName { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string? Description { get; set; }

        public virtual Listing? Listing { get; set; }
    }
}
