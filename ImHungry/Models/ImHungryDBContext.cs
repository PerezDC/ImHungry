using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ImHungry.Models
{
    public partial class ImHungryDBContext : DbContext
    {
        public ImHungryDBContext()
        {
        }

        public ImHungryDBContext(DbContextOptions<ImHungryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PrefCategories> PrefCategories { get; set; }
        public virtual DbSet<NewUser> RegUser { get; set; }
        public virtual DbSet<RestaurantCategories> RestaurantCategories { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<VisitedRestaurant> VisitedRestaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MSI;Database=ImHungryDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrefCategories>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CategoryId });

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PrefCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrefCategories_Categories");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PrefCategories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrefCategories_User");
            });

            modelBuilder.Entity<NewUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmail).HasMaxLength(80);

                entity.Property(e => e.UserPassword).HasMaxLength(40);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<RestaurantCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Restaurants>(entity =>
            {
                entity.HasKey(e => e.RestId);

                entity.Property(e => e.RestId).HasColumnName("RestID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.RestAddress).HasMaxLength(60);

                entity.Property(e => e.RestCity).HasMaxLength(20);

                entity.Property(e => e.RestCountry).HasMaxLength(15);

                entity.Property(e => e.RestName).HasMaxLength(80);

                entity.Property(e => e.RestPhone).HasMaxLength(24);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurants_Categories");
            });

            modelBuilder.Entity<VisitedRestaurant>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RestId });

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RestId).HasColumnName("RestID");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.VisitedRestaurant)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedRestaurant_Restaurants");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VisitedRestaurant)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedRestaurant_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
