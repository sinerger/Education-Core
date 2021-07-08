using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Groups;
using Domain.Interfaces.GroupRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public IDbConnection DBConnection { get; }

        public GroupRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }
        public async Task<bool> CreateGroupAsync(Group group)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(CreateGroupAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            group.ID,
                            group.Title,
                            group.StartDate,
                            group.FinishDate,
                            //TODO:
                            //group.Teacher,
                            //group.CourseProgram
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<bool> DeleteGroupByIDAsync(Guid id)
        {
            try
            {
                IGroupRepository groupRepository = DBConnection.As<IGroupRepository>();

                return await groupRepository.DeleteGroupByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            try
            {
                IGroupRepository groupRepository = DBConnection.As<IGroupRepository>();

                return await groupRepository.GetAllGroupsAsync();
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<Group> GetGroupByIDAsync(Guid id)
        {
            try
            {
                IGroupRepository groupRepository = DBConnection.As<IGroupRepository>();

                return await groupRepository.GetGroupByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<bool> UpdateGroupAsync(Group group)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(UpdateGroupAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            group.ID,
                            group.Title,
                            group.StartDate,
                            group.FinishDate,
                            //TODO:
                            //group.Teacher,
                            //group.CourseProgram
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }
    }
}
