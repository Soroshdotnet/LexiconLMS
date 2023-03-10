﻿using LexiconLMS.Server.Models;
using LexiconLMS.Shared.DTOs;

namespace LexiconLMS.Server.Repositories
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<CourseDto>> GetAsync(int? id);
        void Add(Course course);
        bool CourseExists(int id);
        void Remove(Course course);
    }
}