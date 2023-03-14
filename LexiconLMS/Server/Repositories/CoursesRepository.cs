
using Bogus.DataSets;
using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;
using LexiconLMS.Shared.DTOs;
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
            var courseDtos = db.Courses.Include(c => db.ActivityTypes)
                .Select(c => new CourseDto
                {
                    Desc = c.Desc,
                    Name = c.Name,
                    /*Attila Starkenius try
                     * to do Hämta AktivityType tillsammans med ModulAktiviteter*/
                    //Activities = c.Modules.Select(m => new ActivityDto)
                    Users = c.Users.Select(u => new UserDto
                    {
                        UserName = u.UserName
                    }),
                    Modules = c.Modules.Select(m => new ModuleDto
                    {
                        Name = m.Name,
                        Desc = m.Desc,
                        Activitys = m.Activitys.Select(a => new ActivityDto
                        {
                            Name = a.Name,
                            Desc = a.Desc,
                            ActivityTypes = c.ActivityTypes.Select(a => new ActivityTypeDto
                            {
                                Type = a.Type
                                //Desc = a.Desc
                            })
                        })
                    })
                });
               

            return await courseDtos.ToListAsync();
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
            return (db.Courses?
                .Any(e => e.Id == id))
                .GetValueOrDefault();
        }

        public async Task<IEnumerable<CourseDto>> GetAsync(int? id)
        {
            var courseDtos = db.Courses
                            .Include(c => c.Modules)
                            .Select(c => new CourseDto
                            {
                                Desc = c.Desc,
                                Name = c.Name,
                                Users = c.Users.Select(u => new UserDto
                                {
                                    UserName = u.UserName,

                                    //10.3.2023. Attila Starkenius
                                    //Ändra ApiControllers till att returnera
                                    //och ha returntype DTO's och
                                    //gör i public async Task<IEnumerable<CourseDto>> GetAsync()
                                    // i CoursesRepository.cs classen 
                                    //omvänt Select.(c => new CourseDto{
                                    // Desc = c.Desc,
                                    //Name = c.Name,
                                    //Users = c.Users.Select(u => new UserDto
                                    //{
                                    //    UserName = u.UserName,
                                    //}





                                    //Course =  c
                                    //Desc = m.Desc,
                                    //Course =  u.Course
                                    //Modules = c.Modules.Select(m => new ModuleDto
                                    //{
                                    //    Name = m.Name,
                                    //    Desc = m.Desc,
                                    //    Activitys = m.Activitys.Select(a => new ActivityDto
                                    //    {
                                    //        Name = a.Name,
                                    //        Desc = a.Desc
                                    //    })
                                    //})
                                })
                            });

            return await courseDtos.ToListAsync();
        }
    }
}