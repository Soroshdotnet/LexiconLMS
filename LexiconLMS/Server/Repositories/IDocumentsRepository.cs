using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Services
{
    public interface IDocumentsRepository
    {
        void Add(Document document);
        bool DocumentExists(int id);
        void Remove(Document document);
    }
}