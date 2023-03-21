using LexiconLMS.Shared.DTOs;
using System.Net.Http.Json;

namespace LexiconLMS.Client.Services
{
    public class ModuleClient : IModuleClient
    {
        
            private readonly HttpClient httpClient;

            public ModuleClient(HttpClient httpClient, IConfiguration configuration)
            {
                this.httpClient = httpClient;
            }
            public async Task<ModuleDto?> AddModuleAsync(CreateModuleDto dto)
            {
                //ToDo call API 
                //Example below... Simpliest possible
                var res = await httpClient.PostAsJsonAsync("api/module", dto);
                return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<ModuleDto>() : null;
            }

        Task<CourseDto> IModuleClient.AddModuleAsync(CreateModuleDto dto)
        {
            throw new NotImplementedException();
        }
    }
    }
