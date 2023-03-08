using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Services
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private ApplicationDbContext db;

        public DocumentsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Document document)
        {
            db.Documents.Add(document);
        }

        public void Remove(Document document)
        {
            db.Documents.Remove(document);
        }
        public bool DocumentExists(int id)
        {
            return (db.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}