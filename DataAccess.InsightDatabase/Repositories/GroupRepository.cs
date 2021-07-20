using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Groups;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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

        public async Task CreateGroupWithinCourseAsync(Group group)
        {
            try
            {
                group.ID = group.ID == Guid.Empty ? Guid.NewGuid() : group.ID;
                var courseID = group.Course.ID;

                await DBConnection.QueryAsync(nameof(CreateGroupWithinCourseAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        group.ID,
                        group.Title,
                        group.StartDate,
                        group.FinishDate,
                        courseID
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteGroupAsync(Guid id)
        {
            try
            {
                await _groupRepository.DeleteGroupAsync(id);
            }
            catch (Exception e)
            {
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
                throw e;
            }
        }

        public async Task UpdateGroupAsync(Group group)
        {
            try
            {
                group.ID = group.ID == Guid.Empty ? Guid.NewGuid() : group.ID;
                var courseID = group.Course.ID;

                await DBConnection.QueryAsync(nameof(UpdateGroupAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        group.ID,
                        group.Title,
                        group.StartDate,
                        group.FinishDate,
                        courseID
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
