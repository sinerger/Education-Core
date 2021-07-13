using System;
using System.Data;
using Insight.Database;
using System.Threading.Tasks;
using Domain.Entities.GroupWithStudents;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    public class GroupWithStudentRepository : IGroupWithStudentRepository
    {
        public IDbConnection DBConnection { get; }
        private IGroupWithStudentRepository _groupWithStudentRepository;

        public GroupWithStudentRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _groupWithStudentRepository = DBConnection.As<IGroupWithStudentRepository>();
        }

        public async Task<GroupWithStudent> GetGroupWithStudentByIdAsync(Guid id)
        {
            try
            {
                return await _groupWithStudentRepository.GetGroupWithStudentByIdAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
