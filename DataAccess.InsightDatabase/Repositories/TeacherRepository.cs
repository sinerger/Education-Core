using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ITeacherRepository _teacherRepository;
        public IDbConnection DBConnection { get; }

        public TeacherRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _teacherRepository = DBConnection.As<ITeacherRepository>();
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            try
            {
                var role = teacher.Role;
                teacher.ID = teacher.ID == Guid.Empty ? Guid.NewGuid() : teacher.ID;
                await DBConnection.QueryAsync(nameof(CreateTeacherAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        teacher.ID,
                        teacher.FirstName,
                        teacher.LastName,
                        teacher.Login,
                        teacher.Password,
                        role
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddTeacherToGroupAsync(Guid groupID, Guid userID)
        {
            try
            {
                    await DBConnection.QueryAsync(nameof(AddTeacherToGroupAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            groupID,
                            userID
                        });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddTeacherToLessonAsync(Guid LessonID, Guid TeacherID)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(AddTeacherToLessonAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        TeacherID,
                        LessonID
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteTeacherAsync(Guid id)
        {
            try
            {
                 await _teacherRepository.DeleteTeacherAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            try
            {
                var result = await _teacherRepository.GetAllTeachersAsync();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Teacher> GetTeacherByIDAsync(Guid id)
        {
            try
            {
                return await _teacherRepository.GetTeacherByIDAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                var role = teacher.Role;
                teacher.ID = teacher.ID == Guid.Empty ? Guid.NewGuid() : teacher.ID;

                await DBConnection.QueryAsync(nameof(UpdateTeacherAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        teacher.ID,
                        teacher.FirstName,
                        teacher.LastName,
                        teacher.Login,
                        teacher.Password,
                        role
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
