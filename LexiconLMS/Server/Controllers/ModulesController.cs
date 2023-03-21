using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;
using LexiconLMS.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ModulesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<ActionResult<CreateModuleDto>> AddModuleToCourse(CreateModuleDto dto)
        {
            try
            {
              
                var course = new Module
                {
                    Name = dto.Name,
                    Desc = dto.Desc,
                    StartTime = dto.StartDate,
                    CourseId= dto.CourseId,
                    Duration= dto.Duration
                };

                db.Modules.Add(course);
                await db.SaveChangesAsync();

                //ToDo return DTO, Dont expose Course obj

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
