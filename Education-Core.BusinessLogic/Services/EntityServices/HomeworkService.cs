using Domain.Entities.Homeworks;
using Domain.Interfaces;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class HomeworkService : IHomeworkService
    {
        private IHomeworkRepository _homeworkRepository;

        public HomeworkService(IDBContext dbContext)
        {
            _homeworkRepository = dbContext.HomeworkRepository;
        }

        public async Task<IServiceResponce<bool>> AddHomeworkWithinLessonAsync(Guid lessonID, Homework homework)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _homeworkRepository.AddHomeworkWithinLessonAsync(lessonID, homework);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(HomeworkService) + nameof(AddHomeworkWithinLessonAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> CreateHomeworkAsync(Homework homework)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _homeworkRepository.CreateHomeworkAsync(homework);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(HomeworkService) + nameof(CreateHomeworkAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteHomeworkAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _homeworkRepository.DeleteHomeworkAsync(id);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(HomeworkService) + nameof(DeleteHomeworkAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Homework>>> GetAllHomeworksByCourseIDAsync(Guid courseID)
        {
            var responce = new ServiceResponce<IEnumerable<Homework>>();

            try
            {
                responce.SetValidResponce(obj: await _homeworkRepository.GetAllHomeworksByCourseIDAsync(courseID));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(HomeworkService) + nameof(GetAllHomeworksByCourseIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<Homework>> GetHomeworkByLessonIDAsync(Guid lessonID)
        {
            var responce = new ServiceResponce<Homework>();

            try
            {
                responce.SetValidResponce(obj: await _homeworkRepository.GetHomeworkByLessonIDAsync(lessonID));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(HomeworkService) + nameof(GetHomeworkByLessonIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateHomeworkAsync(Homework homework)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _homeworkRepository.UpdateHomeworkAsync(homework);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(HomeworkService) + nameof(UpdateHomeworkAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
