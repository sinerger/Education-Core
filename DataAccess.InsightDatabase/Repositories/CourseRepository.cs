﻿using Domain.Entities.Courses;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Insight.Database;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public IDbConnection DBConnection { get; }

        public CourseRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<bool> CreateCourseAsync(Course course)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.CreateCourseAsync(course);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.DeleteCourseAsync(id);
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
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.GetAllCoursesAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.GetCourseByIdAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.UpdateCourseAsync(course);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
