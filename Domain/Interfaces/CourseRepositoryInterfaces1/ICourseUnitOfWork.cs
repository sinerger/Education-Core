using Domain.Interfaces.CouseRepositoryInterfaces;
using System.Data;

namespace Domain.Interfaces.CourseRepositoryInterfaces1
{
    public interface ICourseUnitOfWork
    {
        IDbConnection DBConnection { get; set; }
        ICourseRepository CourseRepository { get; set; }
    }
}
