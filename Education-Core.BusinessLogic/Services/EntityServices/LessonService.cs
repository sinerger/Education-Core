using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Domain.Entities.Lessons;
using Domain.Interfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.Services;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class LessonService : ILessonService
    {
        private ILessonRepository _lessonRepository;

        public LessonService(IDBContext dbContext)
        {
            _lessonRepository = dbContext.LessonRepository;
        }

        public async Task<IServiceResponce<IEnumerable<Lesson>>> GetAllLessonsAsync()
        {
            var responce = new ServiceResponce<IEnumerable<Lesson>>();

            try
            {
                responce.SetValidResponce(await _lessonRepository.GetAllLessonsAsync());
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(LessonService) + nameof(GetAllLessonsAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<Lesson>> GetLessonByIDAsync(Guid id)
        {
            var responce = new ServiceResponce<Lesson>();

            try
            {
                responce.SetValidResponce(await _lessonRepository.GetLessonByIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(LessonService) + nameof(GetLessonByIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> CreateLessonWithinCourseAsync(Lesson lesson)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _lessonRepository.CreateLessonWithinCourseAsync(lesson);
                responce.SetValidResponce(true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(LessonService) + nameof(CreateLessonWithinCourseAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteLessonAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _lessonRepository.DeleteLessonAsync(id);
                responce.SetValidResponce(true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(LessonService) + nameof(DeleteLessonAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateLessonAsync(Lesson lesson)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _lessonRepository.UpdateLessonAsync(lesson);
                responce.SetValidResponce(true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(LessonService) + nameof(UpdateLessonAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
