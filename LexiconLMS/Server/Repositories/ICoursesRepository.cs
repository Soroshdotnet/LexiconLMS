using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Services
{
    public interface ICoursesRepository
    {
        void Add(Course course);
        bool CourseExists(int id);
        void Remove(Course course);
    }
}