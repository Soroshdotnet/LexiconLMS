namespace LexiconLMS.Server.Services
{
    public interface IUnitOfWork
    {
        IActivitiesRepository activitiesRepository { get; }
        ICoursesRepository coursesRepository { get; }
        IDocumentsRepository documentsRepository { get; }
        IModulesRepository modulesRepository { get; }

        Task CompleteAsync();
    }
}