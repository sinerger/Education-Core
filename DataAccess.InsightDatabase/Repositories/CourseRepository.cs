using Serilog;
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Courses;
using Domain.Interfaces.CouseRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ICourseRepository _courseRepository; 
        public IDbConnection DBConnection { get; }

        public CourseRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _courseRepository = DBConnection.As<ICourseRepository>();
        }

        public async Task CreateCourseAsync(Course course)
        {
            try
            {
                course.ID = course.ID == Guid.Empty ? Guid.NewGuid() : course.ID;
                await _courseRepository.CreateCourseAsync(course);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            try
            {
                 await _courseRepository.DeleteCourseAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            try
            {
                return await _courseRepository.GetAllCoursesAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task UpdateCourseAsync(Course course)
        {
            try
            {
                await _courseRepository.UpdateCourseAsync(course);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
