using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Courses;

namespace Domain.Interfaces.CouseRepositoryInterfaces
{
    public interface ICourseRepository : IRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task CreateCourseAsync(Course course) ;
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(Guid id);
    }
}
