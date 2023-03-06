﻿

using LexiconLMS.Client.Models;
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

            //var baseAddress = configuration.GetSection("BaseAddress").Value;

            //ArgumentNullException.ThrowIfNull(baseAddress, nameof(configuration));

            //this.httpClient.BaseAddress = new Uri(baseAddress);
            //this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<CourseDto>?> GetAsync()
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<CourseDto>>("api/courses");
            return res;
        }

        //funkar ej ännu
        //public async Task<Course?> GetAsync(string id)
        //{
        //    return await httpClient.GetFromJsonAsync<Course>("api/devices/" + id);
        //}

        public async Task<Course?> PostAsync(CreateCourse createCourse)
        {
            var response = await httpClient.PostAsJsonAsync("api/devices", createCourse);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Course>() : null;
        }


        public async Task<Course?> DeleteAsync(string id)
        {
            return await httpClient.DeleteFromJsonAsync<Course?>("api/devices/" + id);

            //returnerar bool istället
            //return (await httpClient.DeleteAsync($"api/devices/{id}")).IsSuccessStatusCode;

        }

        public async Task<bool> RemoveAsync(string id)
        {
            return (await httpClient.DeleteAsync($"api/devices/{id}")).IsSuccessStatusCode;
        }


        public async Task<bool> PutAsync(Course Course)
        {
            return (await httpClient.PutAsJsonAsync($"api/devices/{Course.Id}", Course)).IsSuccessStatusCode;
        }


    }
}
