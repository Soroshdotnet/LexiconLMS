using LexiconLMS.Client.Models;
using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDbContext db;

        public CoursesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseDto>> GetAsync()
        { 

        }


        public void Add(Course course)
        {
            db.Courses.Add(course);
        }

        public void Remove(Course course)
        {
            db.Courses.Remove(course);

        }
        public bool CourseExists(int id)
        {
            return (db.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}