using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public IDbConnection DBConnection { get; }

        public StudentRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }
        public async Task<bool> CreateStudentAsync(Student student)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(CreateStudentAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            student.ID,
                            student.FirstName,
                            student.LastName,
                            student.Email,
                            student.Phone,
                            student.City,
                            student.DateOfBirth,
                            student.Feedback,
                            student.AgreementNumber,
                            //TODO:
                            //student.Group,
                            //student.Solutions
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

        public async Task<bool> DeleteStudentByIDAsync(Guid id)
        {
            try
            {
                IStudentRepository studentRepository = DBConnection.As<IStudentRepository>();

                return await studentRepository.DeleteStudentByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            try
            {
                IStudentRepository studentRepository = DBConnection.As<IStudentRepository>();

                return await studentRepository.GetAllStudentsAsync();
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<Student> GetStudentByIDAsync(Guid id)
        {
            try
            {
                IStudentRepository studentRepository = DBConnection.As<IStudentRepository>();

                return await studentRepository.GetStudentByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(UpdateStudentAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        student.ID,
                        student.FirstName,
                        student.LastName,
                        student.Email,
                        student.Phone,
                        student.City,
                        student.DateOfBirth,
                        student.Feedback,
                        student.AgreementNumber,
                        //TODO:
                        //student.Group,
                        //student.Solutions
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
