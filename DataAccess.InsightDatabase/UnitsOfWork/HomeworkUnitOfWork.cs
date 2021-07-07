using DataAccess.InsightDatabase.Repositories;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using System.Data;

namespace DataAccess.InsightDatabase.UnitsOfWork
{
    public class HomeworkUnitOfWork : IHomeworkUnitOfWork
    {
        public IDbConnection DBConnection { get; set; }
        public IHomeworkRepository HomeworkRepository { get; set; }

        public HomeworkUnitOfWork(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            HomeworkRepository =  new HomeworkRepository(DBConnection);
        }
    }
}
