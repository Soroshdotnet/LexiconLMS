using LexiconLMS.Shared.DTOs;

namespace LexiconLMS.Client.Services
{
    public interface IModuleClient
    {
        Task<CourseDto> AddModuleAsync(CreateModuleDto dto);
    }
}
