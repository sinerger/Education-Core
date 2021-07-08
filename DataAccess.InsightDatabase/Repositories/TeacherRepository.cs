using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public IDbConnection DBConnection { get; }

        public TeacherRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
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
                            teacher.Feedback,
                            //TODO:
                            //teacher.Group
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

        public async Task<bool> DeleteTeacherByIDAsync(Guid id)
        {
            try
            {
                ITeacherRepository teacherRepository = DBConnection.As<ITeacherRepository>();

                return await teacherRepository.DeleteTeacherByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            try
            {
                ITeacherRepository teacherRepository = DBConnection.As<ITeacherRepository>();

                return await teacherRepository.GetAllTeachersAsync();
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<Teacher> GetTeacherByIDAsync(Guid id)
        {
            try
            {
                ITeacherRepository teacherRepository = DBConnection.As<ITeacherRepository>();

                return await teacherRepository.GetTeacherByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

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
                            teacher.Feedback,
                            //TODO:
                            //teacher.Group
                        });

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
