using LexiconLMS.Client.Models;
using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Repositories
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<CourseDto>> GetAsync();
        void Add(Course course);
        bool CourseExists(int id);
        void Remove(Course course);
    }
}