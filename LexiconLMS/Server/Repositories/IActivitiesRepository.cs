using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Services
{
    public interface IActivitiesRepository
    {
        bool ActivityExists(int id);
        void Add(Activity activity);
        void Remove(Activity activity);
    }
}