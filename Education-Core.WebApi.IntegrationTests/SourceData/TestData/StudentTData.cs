using Domain.Entities.Roles;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class StudentTData
    {
        public static Student _student;

        static StudentTData()
        {
            _student = new Student()
            {
                ID = Guid.NewGuid(),
                FirstName = $"integration test",
                LastName = $"integration test",
                Role = TypeRole.Student,
                Login = $"integration test  login",
                Password = $"integration test password",
                AgreementNumber = $"integrayion agrement number"
            };

        }

        public static IEnumerable<object[]> GetDataForCreate()
        {
            yield return new object[]
            {
                _student,
                _student
            };

        }
    }
}
