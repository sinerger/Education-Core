using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Groups;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IGroupRepository _groupRepository;
        public IDbConnection DBConnection { get; }

        public GroupRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _groupRepository = DBConnection.As<IGroupRepository>();
        }

        public async Task<bool> CreateGroupWithinCourseAsync(Guid courseId, Group group)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(CreateGroupWithinCourseAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            group.ID,
                            group.Title,
                            group.StartDate,
                            group.FinishDate,
                            courseId
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> DeleteGroupAsync(Guid id)
        {
            try
            {
                return await _groupRepository.DeleteGroupAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            try
            {
                return await _groupRepository.GetAllGroupsAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Group> GetGroupByIDAsync(Guid id)
        {
            try
            {
                return await _groupRepository.GetGroupByIDAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> UpdateGroupAsync(Group group)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(UpdateGroupAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        group.ID,
                        group.Title,
                        group.StartDate,
                        group.FinishDate
                    });

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
