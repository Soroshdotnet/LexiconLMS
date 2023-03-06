using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Services
{
    public class ModulesRepository
    {
        private ApplicationDbContext db;

        public ModulesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}