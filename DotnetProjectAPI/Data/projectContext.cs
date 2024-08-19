using Microsoft.EntityFrameworkCore;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Services;
using DotnetProjectAPI.Repositories;



namespace DotnetProjectAPI.Data
{
    public class projectContext : DbContext
    {
        // One to One             Place - PlaceRating
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceRating> PlaceRatings { get; set; }

        // One to Many              User - Like
        // One to Many              User - Comment
        // One to Many              Visit - Like
        // One to Many              Visit - Comment


        public DbSet<Visit> Visits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        // Many to Many              User - Place
        // Separated by Visit into two One to Many
        // relations:   User - Visit and Place - Visit

        public projectContext(DbContextOptions<projectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // One to One
            modelBuilder.Entity<Place>()
                .HasOne(p => p.placeRating)
                .WithOne(pr => pr.place)
                .HasForeignKey<PlaceRating>(pr => pr.placeId);


            // One to Many

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.visit)
                .WithMany(v => v.comments)
                .HasForeignKey(c => c.visitId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.visit)
                .WithMany(v => v.likes)
                .HasForeignKey(l => l.visitId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.user)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.userId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.user)
                .WithMany(u => u.likes)
                .HasForeignKey(l => l.userId);


            // Many to Many
            modelBuilder.Entity<Visit>()
                .HasKey(v => new { v.userId, v.placeId });

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.user)
                .WithMany(u => u.visits)
                .HasForeignKey(v => v.userId);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.place)
                .WithMany(p => p.visits)
                .HasForeignKey(v => v.placeId);


        }

    }
}
