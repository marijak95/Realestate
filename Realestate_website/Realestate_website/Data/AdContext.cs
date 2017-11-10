using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Realestate_website.Data.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realestate_website.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Realestate_website.Data
{
    public class AdContext: DbContext
    {

        public AdContext(DbContextOptions<AdContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<Comment> Comments { get; set; }

        //public DbSet<CommentViewModel> Comments1 { get; set; }

        //public DbSet<UploadImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
            modelBuilder.Ignore<ApplicationUser>();

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Advertisement>().ToTable("Advertisement");
            modelBuilder.Entity<Comment>().ToTable("Comment");
        }

       // Database.SetInitializer<AdContext>(new DropCreateDatabaseAlways<AdContext>());

        
    }
}
