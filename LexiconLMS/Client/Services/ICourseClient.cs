using LexiconLMS.Client.Models;


namespace LexiconLMS.Client.Services
{
    public interface ICourseClient
    {

        Task<IEnumerable<CourseDto>?> GetAsync();

        /*

        Task<Course?> DeleteAsync(string id);
        
        Task<Course?> PostAsync(CreateCourse createCourse);
        Task<bool> PutAsync(Course course);
        Task<bool> RemoveAsync(string id);
        */
    }
}