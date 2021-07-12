using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Serilog;

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

        public async Task<bool> CreateTeacherAsync(Teacher teacher)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(CreateTeacherAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            teacher.ID,
                            teacher.FirstName,
                            teacher.LastName,
                            teacher.Email,
                            teacher.Phone,
                            teacher.City,
                            teacher.DateOfBirth,
                            teacher.Feedback
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

        public async Task<bool> AddTeacherToGroupAsync(Guid groupId, Teacher teacher)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(AddTeacherToGroupAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            teacher.ID,
                            teacher.FirstName,
                            teacher.LastName,
                            teacher.Email,
                            teacher.Phone,
                            teacher.City,
                            teacher.DateOfBirth,
                            teacher.Feedback,
                            groupId
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

        public async Task<bool> DeleteTeacherAsync(Guid id)
        {
            try
            {
                return await _teacherRepository.DeleteTeacherAsync(id);
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
                return await _teacherRepository.GetAllTeachersAsync();
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
                await DBConnection.QueryAsync(nameof(UpdateTeacherAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            teacher.ID,
                            teacher.FirstName,
                            teacher.LastName,
                            teacher.Email,
                            teacher.Phone,
                            teacher.City,
                            teacher.DateOfBirth,
                            teacher.Feedback
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
