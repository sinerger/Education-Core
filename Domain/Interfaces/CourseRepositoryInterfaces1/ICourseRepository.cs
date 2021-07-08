using Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.CouseRepositoryInterfaces
{
    public interface ICourseRepository: IRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<bool> CreateCourseAsync(Course course) ;
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(Guid id);
    }
}
