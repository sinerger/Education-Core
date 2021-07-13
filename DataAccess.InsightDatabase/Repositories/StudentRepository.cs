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
    public class StudentRepository : IStudentRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly IStudentRepository _studentRepository;

        public StudentRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _studentRepository = DBConnection.As<IStudentRepository>();
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
                            student.AgreementNumber
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AddStudentToGroupAsync(Guid groupId, Student student)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(AddStudentToGroupAsync).GetStoredProcedureName(),
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
                            groupId
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            try
            {
                return await _studentRepository.DeleteStudentAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            try
            {
                return await _studentRepository.GetAllStudentsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Student> GetStudentByIDAsync(Guid id)
        {
            try
            {
                return await _studentRepository.GetStudentByIDAsync(id);
            }
            catch (Exception e)
            {
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
                        student.AgreementNumber
                    });

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
