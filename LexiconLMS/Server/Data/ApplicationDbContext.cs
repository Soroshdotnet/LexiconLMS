using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMS.Server.Models;
using LexiconLMS.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace LexiconLMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
    DbContextOptions options,
    IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<ActivityType> ActivityTypes => Set<ActivityType>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Module> Modules => Set<Module>();
        //public DbSet<User> User => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Seed();

        }

    }
}