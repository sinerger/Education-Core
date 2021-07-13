using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Serilog;

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
                            student.AgreementNumber
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

        public async Task<bool> AddStudentToGroupAsync( Student student)
        {
            try
            {
                student.ID = student.ID == Guid.Empty ? Guid.NewGuid() : student.ID;
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
                

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

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
                        student.AgreementNumber
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
