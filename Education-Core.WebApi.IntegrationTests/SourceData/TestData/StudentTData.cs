using Domain.Entities.Roles;
using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class StudentTData
    {
        private static Student _students;

        static StudentTData()
        {
            _students = new Student()
            {
                ID = Guid.NewGuid(),
                FirstName = "integration test",
                LastName = "integration test",
                Role = TypeRole.Student,
                Login = "integration test  login",
                Password = "integration test password",
                AgreementNumber = "integration test"
            };
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            yield return new object[]
            {
                _students,
                _students
            };
        }
        
        public static IEnumerable<object[]> DataForUpdate()
        {
            yield return new object[]
            {
                _students,
                _students,
                _students
            };
        }

        public static IEnumerable<object[]> DataForDelete()
        {
            yield return new object[]
            {
                _students
            };
        }

        public static IEnumerable<object[]> DataForAddStudentToGroup()
        {
            yield return new object[]
            {
                _students,
                GroupInitData.Group
            };
        }
    }
}


