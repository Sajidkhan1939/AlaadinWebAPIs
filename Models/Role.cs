using System;
using System.Collections.Generic;

namespace AlaadinWebAPIs.Models
{
    public partial class Role
    {
        public Role()
        {
            Listings = new HashSet<Listing>();
            Services = new HashSet<Service>();
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
