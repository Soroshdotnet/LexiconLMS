using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork unitOfWork;

        public ModulesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.unitOfWork = unitOfWork;
        }

        public object GetModule { get; private set; }

        // POST: api/Modules
        [HttpPost]
        //  [Authorize(Roles ="Teacher")]
        public async Task<ActionResult<ModuleDto>> PostModule(CreateModuleDto dto)
        {
            try
            {
                var module = new Module
                {
                    Name = dto.Name,
                    Desc = dto.Desc,

                };
                _context.Modules.Add(module);
                await _context.SaveChangesAsync();

                //ToDo: FIXED return DTO, Dont expose Course obj


                var courseDto = new CourseDto
                {
                    Id = module.Id,
                    Name = module.Name,
                    Desc = module.Desc,

                };

                // return CreatedAtAction(nameof(GetModule), new { id = moduleDto.Id }, moduleDto);
                return CreatedAtAction(nameof(GetModule), new { id = ModelBinderFactory }, module);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
