using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Services
{
    public class ActivitiesRepository
    {
        private ApplicationDbContext db;

        public ActivitiesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}