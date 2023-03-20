using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;

using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LexiconLMS.Server.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork unitOfWork;

        public CoursesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            return Ok(await unitOfWork.coursesRepository.GetAsync());



        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
            var email = User.FindFirstValue(ClaimTypes.Email);

            var courseDto = await _context.Courses
               .Select(c => new CourseDto
               {
                   Id = c.Id,
                   Desc = c.Desc,
                   Name = c.Name,
                   Users = c.Users.Select(u => new UserDto
                   {
                       UserName = u.UserName,
                       FullName = u.FullName
                   }),
                   Modules = c.Modules.Select(m => new ModuleDto
                   {
                       Name = m.Name,
                       Desc = m.Desc,
                       Activitys = m.Activitys.Select(a => new ActivityDto
                       {
                           Name = a.Name,
                           Desc = a.Desc,//
                                         //ActivityType = a.ActivityType.Select(b => new ActivityTypeDto
                                         //{
                                         //    Type = b.Type
                                         //})

                           ActivityTypeName = a.ActivityType.Type
                           //ActivityType/*Name*/ = a.ActivityType/*.Type*/

                       })
                   })
               })
               .FirstOrDefaultAsync(c => c.Id == id);


            if (courseDto == null)
            {
                return NotFound();
            }

            return Ok(courseDto);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        [HttpPost]
      //  [Authorize(Roles ="Teacher")]
        public async Task<ActionResult<Course>> PostCourse(CreateCourseDto dto)
        {
            try
            {
                //ToDo: Add startdate and enddate
                var course = new Course
                {
                    Name = dto.Name,
                    Desc = dto.Desc
                }; 
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                //ToDo return DTO, Dont expose Course obj

                return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}