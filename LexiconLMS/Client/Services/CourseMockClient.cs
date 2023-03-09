using Bogus.DataSets;
using LexiconLMS.Client.Models;
using System.Reflection;

namespace LexiconLMS.Client.Services
{
    public class CourseMockClient : ICourseClient
    {
        private readonly HttpClient httpClient;

        public CourseMockClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<CourseDto>?> GetAsync()
        {
            return new List<CourseDto>()
            { 
                new CourseDto()
                {
                    Name = "Mjölk",
                    Desc = "beskrivning",
                    Modules = new List<ModuleDto>() {

                        new ModuleDto()
                        {
                            Name = "Module 1",
                            Desc = "Beskrivning modul 1",
                            Activitys= new List<ActivityDto>()
                            {
                                new ActivityDto()
                                {
                                    Name= "Activity 1",
                                    Desc = "Beskrivning activity 1"
                                },
                                new ActivityDto()
                                {
                                    Name= "Activity 2",
                                    Desc = "Beskrivning activity 2"
                                }
                            }

                        },
                        new ModuleDto()
                        {
                            Name = "Module 2",
                            Desc = "Beskrivning modul 2",
                            Activitys= new List<ActivityDto>()
                            {
                                new ActivityDto()
                                {
                                    Name= "Activity 1",
                                    Desc = "Beskrivning activity 1"
                                },
                                new ActivityDto()
                                {
                                    Name= "Activity 2",
                                    Desc = "Beskrivning activity 2"
                                }
                            }

                        }

                    }
                }
                
            };
        }
    }
}
