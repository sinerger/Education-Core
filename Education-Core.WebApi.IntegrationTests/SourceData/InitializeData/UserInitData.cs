using Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public class UserInitData
    {
        public static Teacher Teacher { get; set; }
        public static List<Student> Students { get; set; }
        public static UserWithRole UserWithRole { get; set; }

        static UserInitData()
        {
            Teacher = new Teacher()
            {
                ID = Guid.NewGuid(),
                FirstName = "Teacher",
                LastName = "LastNameTeacher",
                Login = "LoginTeacher",
                Password = "PasswordTeacher"
            };

            Students = new List<Student>();

            for (int i = 0; i < 3; i++)
            {
                Students.Add(new Student()
                {
                    ID = Guid.NewGuid(),
                    FirstName = $"Student {i}",
                    LastName = $"LastNameStudent {i}",
                    Login = $"Login {i}",
                    Password = $"Password {i}"
                });
            }

            UserWithRole = new UserWithRole()
            {
                ID = Guid.NewGuid(),
                FirstName = "UserWithRole",
                LastName = "LastNameUserWithRole",
                Login = "LoginUserWithRole",
                Password = "PasswordUserWithRole"
            };
        }
    }
}
