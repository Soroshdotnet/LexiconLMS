using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMS.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LexiconLMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
//        public DbSet<GymClass> GymClasses => Set<GymClass>();
//        public DbSet<ApplicationUserGymClass> AppUserGymClass => Set<ApplicationUserGymClass>();
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            base.OnModelCreating(builder);

//            builder.Entity<ApplicationUserGymClass>().HasKey(a => new { a.ApplicationUserId, a.GymClassId });

//            builder.Entity<GymClass>().HasQueryFilter(g => g.StartTime > DateTime.UtcNow);
//        }
//    }
//}
public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}