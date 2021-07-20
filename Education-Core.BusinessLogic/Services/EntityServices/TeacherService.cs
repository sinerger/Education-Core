using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Interfaces.UserRepositoryInterfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherService(IDBContext dbContext)
        {
            _teacherRepository = dbContext.TeacherRepository;
        }

        public async Task<IServiceResponce<bool>> AddTeacherToGroupAsync(Guid groupId, Guid userID)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _teacherRepository.AddTeacherToGroupAsync(groupId, userID);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(AddTeacherToGroupAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> AddTeacherToLessonAsync(Guid lessonID, Guid teacherID)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _teacherRepository.AddTeacherToGroupAsync(lessonID, teacherID);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(AddTeacherToLessonAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> CreateTeacherAsync(Teacher teacher)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _teacherRepository.CreateTeacherAsync(teacher);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(CreateTeacherAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteTeacherAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _teacherRepository.DeleteTeacherAsync(id);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(DeleteTeacherAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Teacher>>> GetAllTeachersAsync()
        {
            var responce = new ServiceResponce<IEnumerable<Teacher>>();

            try
            {
                responce.SetValidResponce(obj: await _teacherRepository.GetAllTeachersAsync());
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(GetAllTeachersAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<Teacher>> GetTeacherByIDAsync(Guid id)
        {
            var responce = new ServiceResponce<Teacher>();

            try
            {
                responce.SetValidResponce(obj: await _teacherRepository.GetTeacherByIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(GetTeacherByIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateTeacherAsync(Teacher teacher)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _teacherRepository.UpdateTeacherAsync(teacher);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(TeacherService) + nameof(UpdateTeacherAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
