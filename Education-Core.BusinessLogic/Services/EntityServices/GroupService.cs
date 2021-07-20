using Domain.Entities.Groups;
using Domain.Interfaces;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Domain.Interfaces.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;

        public GroupService(IDBContext dbContext)
        {
            _groupRepository = dbContext.GroupRepository;
        }

        public async Task<IServiceResponce<bool>> CreateGroupWithinCourseAsync(Group group)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _groupRepository.CreateGroupWithinCourseAsync(group);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(CreateGroupWithinCourseAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteGroupAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _groupRepository.DeleteGroupAsync(id);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(DeleteGroupAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Group>>> GetAllGroupsAsync()
        {
            var responce = new ServiceResponce<IEnumerable<Group>>();

            try
            {
                responce.SetValidResponce(obj: await _groupRepository.GetAllGroupsAsync());
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(GetAllGroupsAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<Group>> GetGroupByIDAsync(Guid id)
        {
            var responce = new ServiceResponce<Group>();

            try
            {
                responce.SetValidResponce(obj: await _groupRepository.GetGroupByIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(GetGroupByIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateGroupAsync(Group group)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _groupRepository.UpdateGroupAsync(group);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(UpdateGroupAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
