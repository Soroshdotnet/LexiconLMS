using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private ApplicationDbContext db;

        public ActivitiesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Activity activity)
        {
            db.Activities.Add(activity);
        }

        public void Remove(Activity activity)
        {
            db.Activities.Remove(activity);
        }
        public bool ActivityExists(int id)
        {
            return (db.Activities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}