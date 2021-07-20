using Domain.Entities.GroupWithStudents;
using Domain.Interfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Domain.Interfaces.Services;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class GroupWithStudentsService : IGroupWithStudentsService
    {
        private IGroupWithStudentsRepository _groupWithStudentsRepository;

        public GroupWithStudentsService(IDBContext dbContext)
        {
            _groupWithStudentsRepository = dbContext.GroupWithStudentsRepository;
        }

        public async Task<IServiceResponce<GroupWithStudents>> GetGroupWithStudentsByIDAsync(Guid id)
        {
            var responce = new ServiceResponce<GroupWithStudents>();

            try
            {
                responce.SetValidResponce(await _groupWithStudentsRepository.GetGroupWithStudentsByIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(GroupWithStudentsService) + nameof(GetGroupWithStudentsByIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
