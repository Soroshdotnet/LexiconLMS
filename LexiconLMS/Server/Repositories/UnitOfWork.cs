using LexiconLMS.Server.Controllers;
using LexiconLMS.Server.Data;


namespace LexiconLMS.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public ICoursesRepository coursesRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
            coursesRepository = new CoursesRepository(db);

        }


        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
