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
    public class StudentRepository : IStudentRepository
    {
        private readonly IStudentRepository _studentRepository;
        public IDbConnection DBConnection { get; }

        public StudentRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _studentRepository = DBConnection.As<IStudentRepository>();
        }

        public async Task CreateStudentAsync(Student student)
        {
            try
            {
                student.ID = student.ID == Guid.Empty ? Guid.NewGuid() : student.ID;

                await DBConnection.QueryAsync(nameof(CreateStudentAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        student.ID,
                        student.FirstName,
                        student.LastName,
                        student.AgreementNumber
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddStudentToGroupAsync(Student student)
        {
            try
            {
                var GroupID = student.Group.ID;

                await DBConnection.QueryAsync(nameof(AddStudentToGroupAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            student.ID,
                            student.FirstName,
                            student.LastName,
                            student.AgreementNumber,
                            GroupID
                        });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            try
            {
                await _studentRepository.DeleteStudentAsync(id);
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

        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(UpdateStudentAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        student.ID,
                        student.FirstName,
                        student.LastName,
                        student.AgreementNumber
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
