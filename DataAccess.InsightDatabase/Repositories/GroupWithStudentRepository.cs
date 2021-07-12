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

        public GroupWithStudentRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<GroupWithStudent> GetGroupWithStudentByIdAsync(Guid id)
        {
            try
            {
                IGroupWithStudentRepository groupWithStudentRepository = DBConnection.As<IGroupWithStudentRepository>();

                return await groupWithStudentRepository.GetGroupWithStudentByIdAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
