﻿using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class UserInitData
    {
        public static Teacher Teacher { get; set; }
        public static List<Student> Students { get; set; }

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
                    FirstName = $"Student{i}",
                    LastName = $"LastNameTeacher{i}",
                    Login = $"Login{i}",
                    Password = $"Password{i}"
                });
            }
        }
    }
}