using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlaadinWebAPIs.Models
{
    public partial class Aladin_prp_dbContext : DbContext
    {
        public Aladin_prp_dbContext()
        {
        }

        public Aladin_prp_dbContext(DbContextOptions<Aladin_prp_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomField> CustomFields { get; set; } = null!;
        public virtual DbSet<Faq> Faqs { get; set; } = null!;
        public virtual DbSet<Listing> Listings { get; set; } = null!;
        public virtual DbSet<ListingClaim> ListingClaims { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Portfolio> Portfolios { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Aladin_prp_db;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomField>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.KeyName).HasMaxLength(128);

                entity.Property(e => e.ListingId).HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(128);

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.CustomFields)
                    .HasForeignKey(d => d.ListingId)
                    .HasConstraintName("FK__CustomFie__Listi__22AA2996");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQs");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Answer).HasMaxLength(500);

                entity.Property(e => e.ListingId).HasMaxLength(128);

                entity.Property(e => e.Question).HasMaxLength(255);

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Faqs)
                    .HasForeignKey(d => d.ListingId)
                    .HasConstraintName("FK__FAQs__ListingId__25869641");
            });

            modelBuilder.Entity<Listing>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.BussinessName).HasMaxLength(255);

                entity.Property(e => e.CoverPhoto).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(128);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FaxNumber).HasMaxLength(255);

                entity.Property(e => e.Fb).HasMaxLength(255);

                entity.Property(e => e.Insta).HasMaxLength(255);

                entity.Property(e => e.Latlong).HasMaxLength(500);

                entity.Property(e => e.Overview).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber3).HasMaxLength(255);

                entity.Property(e => e.ProfilePhoto).HasMaxLength(500);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.Tehsil).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Tt)
                    .HasMaxLength(255)
                    .HasColumnName("TT");

                entity.Property(e => e.Tw)
                    .HasMaxLength(255)
                    .HasColumnName("TW");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.WebsiteUrl).HasMaxLength(255);

                entity.Property(e => e.Yt)
                    .HasMaxLength(255)
                    .HasColumnName("YT");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Listings__RoleId__164452B1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Listings__UserId__15502E78");
            });

            modelBuilder.Entity<ListingClaim>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.ListingId).HasMaxLength(128);

                entity.Property(e => e.Msg).HasMaxLength(500);

                entity.Property(e => e.PhoneNumber).HasMaxLength(128);

                entity.Property(e => e.ProofDocument).HasMaxLength(255);

                entity.Property(e => e.ProofDocumentType).HasMaxLength(255);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.ListingClaims)
                    .HasForeignKey(d => d.ListingId)
                    .HasConstraintName("FK__ListingCl__Listi__32E0915F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ListingClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ListingCl__UserI__31EC6D26");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Msg).HasMaxLength(500);

                entity.Property(e => e.Nstatus).HasColumnName("NStatus");

                entity.Property(e => e.Thumb).HasMaxLength(500);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__36B12243");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("Portfolio");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.ListingId).HasMaxLength(128);

                entity.Property(e => e.ServicesIds).HasMaxLength(1000);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasMaxLength(128)
                    .HasColumnName("_Type");

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.ListingId)
                    .HasConstraintName("FK__Portfolio__Listi__2B3F6F97");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Feedback).HasMaxLength(500);

                entity.Property(e => e.ListingId).HasMaxLength(128);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.ReviewerId).HasMaxLength(128);

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ListingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__Listing__2F10007B");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__Reviewe__2E1BDC42");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Thumbnail).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.Thumbnail).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Services__RoleId__286302EC");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.AccountStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AvailabilityStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverPhoto).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.IdCard)
                    .HasMaxLength(255)
                    .HasColumnName("ID_Card");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Lattitude).HasMaxLength(255);

                entity.Property(e => e.LocalName).HasMaxLength(255);

                entity.Property(e => e.Longitude).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.ProfilePhoto).HasMaxLength(255);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.Servicetype).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.StreetAddress).HasMaxLength(255);

                entity.Property(e => e.Tehsil).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleId__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
