using Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICourseService
    {
        Task<IServiceResponce< IEnumerable<Course>>> GetAllCoursesAsync();
        Task<IServiceResponce<bool>> CreateCourseAsync(Course course);
        Task<IServiceResponce<bool>> UpdateCourseAsync(Course course);
        Task<IServiceResponce<bool>> DeleteCourseAsync(Guid id);
    }
}
