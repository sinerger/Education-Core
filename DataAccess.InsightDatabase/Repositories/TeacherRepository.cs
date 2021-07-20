using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly ITeacherRepository _teacherRepository;

        public TeacherRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _teacherRepository = DBConnection.As<ITeacherRepository>();
        }

        public async Task<bool> CreateTeacherAsync(Teacher teacher)
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


                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> AddTeacherToGroupAsync(Guid GroupID, Guid UserID)
        {
            try
            {
                    await DBConnection.QueryAsync(nameof(AddTeacherToGroupAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            GroupID,
                            UserID
                        });

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> AddTeacherToLessonAsync(Guid LessonID, Guid TeacherID)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(AddTeacherToLessonAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        TeacherID,
                        LessonID
                    });

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
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
