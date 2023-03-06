using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Services
{
    public class DocumentsRepository
    {
        private ApplicationDbContext db;

        public DocumentsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}