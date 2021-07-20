using System;
using System.Data;
using Insight.Database;
using System.Threading.Tasks;
using Domain.Entities.GroupWithStudents;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    public class GroupWithStudentsRepository : IGroupWithStudentsRepository
    {
        private readonly IGroupWithStudentsRepository _groupWithStudentsRepository;
        public IDbConnection DBConnection { get; }

        public GroupWithStudentsRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _groupWithStudentsRepository = DBConnection.As<IGroupWithStudentsRepository>();
        }

        public async Task<GroupWithStudents> GetGroupWithStudentsByIDAsync(Guid id)
        {
            try
            {
                return await _groupWithStudentsRepository.GetGroupWithStudentsByIDAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
