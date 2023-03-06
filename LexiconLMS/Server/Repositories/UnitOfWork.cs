using LexiconLMS.Server.Controllers;
using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Services
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext db;
        public CoursesRepository coursesRepository { get; private set; }
        public ActivitiesRepository activitiesRepository { get; private set; }
        public DocumentsRepository documentsRepository { get; private set; }
        public ModulesRepository modulesRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
            coursesRepository = new CoursesRepository(db);
            activitiesRepository = new ActivitiesRepository(db);
            documentsRepository = new DocumentsRepository(db);
            modulesRepository = new ModulesRepository(db);
        }


        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
