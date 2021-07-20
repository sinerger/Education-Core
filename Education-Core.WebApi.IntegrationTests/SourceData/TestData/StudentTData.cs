using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Roles;
using Domain.Entities.Users;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class StudentTData
    {
        public static List<Student> students;
        private const int _countUsers = 1;

        static  StudentTData()
        {
            students = new List<Student>();

            for (int i = 0; i < _countUsers; i++)
            {
                students.Add(new Student()
                {
                    ID = Guid.NewGuid(),
                    FirstName = $"integration test {i}",
                    LastName = $"integration test {i}",
                    Role = TypeRole.Student,
                    Login = $"integration test  login{i}",
                    Password = $"integration test password{i}",
                    AgreementNumber = $"integrayion agrement number{i}"
                });
            }
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            foreach (var student in students)
            {
                yield return new object[]
                {
                    student,
                    student
                };
            }
        }
    }
}
