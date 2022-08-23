using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Listing
    {
        public Listing()
        {
            CustomFields = new HashSet<CustomField>();
            Faqs = new HashSet<Faq>();
            ListingClaims = new HashSet<ListingClaim>();
            Portfolios = new HashSet<Portfolio>();
            Reviews = new HashSet<Review>();
        }

        public string Id { get; set; } = null!;
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string RoleId { get; set; } = null!;
        public string? BussinessName { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? PhoneNumber2 { get; set; }
        public string? PhoneNumber3 { get; set; }
        public string? FaxNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string Tehsil { get; set; } = null!;
        public string District { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string? Latlong { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Fb { get; set; }
        public string? Insta { get; set; }
        public string? Yt { get; set; }
        public string? Tw { get; set; }
        public string? Tt { get; set; }
        public string? Slug { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? CoverPhoto { get; set; }
        public string? Media { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Overview { get; set; }
        public bool IsAddressVerified { get; set; }
        public bool IsIdentityVerified { get; set; }
        public bool IsListingVerified { get; set; }
        public bool IsPhone1Verified { get; set; }
        public bool IsPhone2Verified { get; set; }
        public bool IsPhone3Verified { get; set; }
        public bool IsPhoneEmailVerified { get; set; }
        public bool IsPhoneWebsiteVerified { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
        public virtual ICollection<Faq> Faqs { get; set; }
        public virtual ICollection<ListingClaim> ListingClaims { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
