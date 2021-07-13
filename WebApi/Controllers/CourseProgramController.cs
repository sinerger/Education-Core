﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.CoursePrograms;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseProgramController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public CourseProgramController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseProgram>> GetAllCourseProgram()
        {
            return await _dbContext.CourseProgramRepository.GetAllCourseProgramAsync();
        }

        [HttpGet("{id}")]
        public async Task<CourseProgram> GetCourseProgramsById(Guid id)
        {
            return await _dbContext.CourseProgramRepository.GetCourseProgramByIDAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateCourseProgramsById(CourseProgram courseProgram)
        {
            return await _dbContext.CourseProgramRepository.UpdateCourseProgramAsync(courseProgram);
        }

        [HttpPost]
        public async Task<bool> CreateCourseProgramsById(CourseProgram courseProgram)
        {
            return await _dbContext.CourseProgramRepository.CreateCourseProgramAsync(courseProgram);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCourseProgramsById(Guid id)
        {
            return await _dbContext.CourseProgramRepository.DeleteCourseProgramAsync(id);
        }
    }
}