using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Repositories
{
    public interface IActivitiesRepository
    {
        bool ActivityExists(int id);
        void Add(Activity activity);
        void Remove(Activity activity);
    }
}