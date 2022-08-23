using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class ListingClaim
    {
        public string Id { get; set; } = null!;
        public string? UserId { get; set; }
        public string? ListingId { get; set; }
        public string Msg { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool ClaimStatus { get; set; }
        public string ProofDocument { get; set; } = null!;
        public string ProofDocumentType { get; set; } = null!;

        public virtual Listing? Listing { get; set; }
        public virtual User? User { get; set; }
    }
}
