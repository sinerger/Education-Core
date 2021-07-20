using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using Domain.Entities.Groups;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class TeacherTData
    {
        private static Teacher _teacher;
        private static readonly int _countTeas = 1;

        static TeacherTData()
        {
            _teacher = new Teacher()
            {
                ID = Guid.NewGuid(),
                FirstName = "Teacher",
                LastName = "LastNameTeacher",
                Login = "LoginTeacher",
                Password = "PasswordTeacher",
                Groups = new List<Group>()
            };
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            _teacher.Groups = new List<Group>();

            yield return new object[]
                {
                    _teacher,
                    _teacher
                };
        }

        public static IEnumerable<object[]> DataForUpdate()
        {

            _teacher.Groups = new List<Group>();
            yield return new object[]
            {
                _teacher
            };

        }

        public static IEnumerable<object[]> DataForAddTeacherToGroup()
        {
            _teacher.Groups = GroupInitData.Groups;

                yield return new object[]
                {
                    _teacher
                };
        }

        public static IEnumerable<object[]> DataForGetAll()
        {
            _teacher.Groups = new List<Group>();

            yield return new object[]
            {
                _teacher,
                _teacher
            };
        }
    }
}

