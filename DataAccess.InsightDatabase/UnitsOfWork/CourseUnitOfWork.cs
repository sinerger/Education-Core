using DataAccess.InsightDatabase.Repositories;
using Domain.Interfaces.CourseRepositoryInterfaces1;
using Domain.Interfaces.CouseRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.InsightDatabase.UnitsOfWork
{
    public class CourseUnitOfWork : ICourseUnitOfWork
    {
        public IDbConnection DBConnection { get; set; }
        public ICourseRepository CourseRepository { get; set; }

        public CourseUnitOfWork(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            CourseRepository = new CourseRepository(dbConnection);
        }
    }
}
