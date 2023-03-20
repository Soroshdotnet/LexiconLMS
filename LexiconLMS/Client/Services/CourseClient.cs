using LexiconLMS.Shared.DTOs;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LexiconLMS.Client.Services
{
    public class CourseClient : ICourseClient
    {
        private readonly HttpClient httpClient;

        public CourseClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CourseDto>?> GetAsync()
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<CourseDto>>($"api/courses/");
            return res;
        }      
        
        public async Task<int> GetCourseIdAsync()
        {
            var res = await httpClient.GetFromJsonAsync<int>($"api/users/");
            return res;
        }

        public async Task<CourseDto?> GetAsyncId(int courseId)
        {
            var res = await httpClient.GetFromJsonAsync<CourseDto>($"api/courses/{courseId}");
            return res;
        }

        public async Task<CourseDto?> AddCourseAsync(CreateCourseDto dto)
        {
            //ToDo call API 
            //Example below... Simpliest possible
           var res = await  httpClient.PostAsJsonAsync("api/courses", dto);
            return res.IsSuccessStatusCode ?  await res.Content.ReadFromJsonAsync<CourseDto>() : null;
        }
    }
}


