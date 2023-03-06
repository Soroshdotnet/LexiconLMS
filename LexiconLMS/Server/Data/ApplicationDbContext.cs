using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMS.Server.Models;
using LexiconLMS.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LexiconLMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        //**  LÅT STÅ **// 
        //public DbSet<LexiconLMS.Shared.User> Users { get; set; } = default!;
        //public DbSet<LexiconLMS.Shared.Module> Modules { get; set; } = default!;

        //public DbSet<LexiconLMS.Shared.Course> Courses { get; set; } = default!;

        //public DbSet<LexiconLMS.Shared.Activity> Activitys { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder
        //        .Entity<Document>()
        //        .HasOne(d => d.Module)
        //        .WithMany(a => a.Activitys )
        //        .HasForeignKey(m => m.module)
        //        .OnDelete(DeleteBehavior.NoAction);

        //}
    }
}