using LexiconLMS.Shared.DTOs;

namespace LexiconLMS.Client.Services
{
    public interface ICourseClient
    {

        Task<IEnumerable<CourseDto>?> GetAsync();

        Task<CourseDto?> GetAsyncId(int courseId);

        Task<int> GetCourseIdAsync();


        /*

        Task<Course?> DeleteAsync(string id);
        
        Task<Course?> PostAsync(CreateCourse createCourse);
        Task<bool> PutAsync(Course course);
        Task<bool> RemoveAsync(string id);
        */
    }
}