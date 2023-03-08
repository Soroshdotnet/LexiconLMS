using LexiconLMS.Server.Controllers;
using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public ICoursesRepository coursesRepository { get; private set; }
        public IActivitiesRepository activitiesRepository { get; private set; }
        public IDocumentsRepository documentsRepository { get; private set; }
        public IModulesRepository modulesRepository { get; private set; }

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
