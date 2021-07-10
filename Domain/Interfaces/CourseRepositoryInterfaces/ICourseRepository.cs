using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Courses;

namespace Domain.Interfaces.CouseRepositoryInterfaces
{
    public interface ICourseRepository: IRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<bool> CreateCourseAsync(Course course) ;
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(Guid id);
    }
}
