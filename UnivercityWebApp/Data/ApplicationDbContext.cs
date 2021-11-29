using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UnivercityWebApp.Models;

namespace UnivercityWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudyItem> StudyItems { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Work> Works { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>()
                .HasOne(p => p.Work)
                .WithMany(t => t.Evaluations)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StudyItem>()
                .HasMany(p => p.Groups)
                .WithMany(t => t.StudyItems)
            .UsingEntity<Dictionary<string, object>>(
                "GroupStudyItem",
                j => j.HasOne<Group>().WithMany().OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<StudyItem>().WithMany().OnDelete(DeleteBehavior.ClientCascade));

            base.OnModelCreating(modelBuilder);
        }
    }
}
