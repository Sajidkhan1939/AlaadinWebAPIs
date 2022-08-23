using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Review
    {
        public string Id { get; set; } = null!;
        public string ReviewerId { get; set; } = null!;
        public string ListingId { get; set; } = null!;
        public string? Feedback { get; set; }
        public int? RecommendationScore { get; set; }
        public int? Skills { get; set; }
        public int? Availability { get; set; }
        public int? QualityOfWork { get; set; }
        public int? Communication { get; set; }
        public int? Coorperation { get; set; }
        public string? Reason { get; set; }

        public virtual Listing Listing { get; set; } = null!;
        public virtual User Reviewer { get; set; } = null!;
    }
}
