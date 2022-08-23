using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class User
    {
        public User()
        {
            ListingClaims = new HashSet<ListingClaim>();
            Listings = new HashSet<Listing>();
            Notifications = new HashSet<Notification>();
            Reviews = new HashSet<Review>();
        }

        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? IdCard { get; set; }
        public long? PhoneNo { get; set; }
        public string? Servicetype { get; set; }
        public string RoleId { get; set; } = null!;
        public string? StreetAddress { get; set; }
        public string? LocalName { get; set; }
        public string? Tehsil { get; set; }
        public string? District { get; set; }
        public string AccountStatus { get; set; } = null!;
        public string AvailabilityStatus { get; set; } = null!;
        public string? State { get; set; }
        public string? Lattitude { get; set; }
        public string? Longitude { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? CoverPhoto { get; set; }
        public string? About { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<ListingClaim> ListingClaims { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
