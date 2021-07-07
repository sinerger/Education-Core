using Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.CouseRepositoryInterfaces
{
    public interface ICourseRepository: IRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(Guid id);
        Task<bool> CreateCourse(Course course) ;
        Task<bool> UpdateCourse(Course course);
        Task<bool> DeleteCourse(Guid id);
    }
}
