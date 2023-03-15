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

        public async Task<IEnumerable<CourseDto>?> GetAsyncId(int courseId)
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<CourseDto>>($"api/courses/{courseId}");
            return res;
        }
    }
}


