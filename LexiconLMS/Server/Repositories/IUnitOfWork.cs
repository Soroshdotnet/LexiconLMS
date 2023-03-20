namespace LexiconLMS.Server.Repositories
{
    public interface IUnitOfWork
    {
        ICoursesRepository coursesRepository { get; }

        Task CompleteAsync();
    }
}