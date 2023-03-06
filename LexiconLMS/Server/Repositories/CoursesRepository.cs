using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Services
{
    public class CoursesRepository
    {
        private readonly ApplicationDbContext db;

        public CoursesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}