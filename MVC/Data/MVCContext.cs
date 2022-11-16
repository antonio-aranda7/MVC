using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using GigHub.Models;
using Configuration;
using Entities.Configuration;
using Microsoft.Extensions.Configuration;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.Entity<User>()
                .HasMany(u => u.Followers);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followees);*/

        /*
        modelBuilder.Entity<Attendance>()
            .HasRequired(a => a.Gig)
            .WithMany()
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Followers)
            .WithRequired(f => f.Followee)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Followees)
            .WithRequired(f => f.Follower)
            .WillCascadeOnDelete(false);*/

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Gig> Gig { get; set; }

        //public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
    }
}
