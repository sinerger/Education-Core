﻿using Domain.Entities.GroupWithStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class GroupWithStudentsTData
    {
        private static GroupWithStudents _groupWithStudentses;
        private const int _countUsers = 1;

        static GroupWithStudentsTData()
        {
            _groupWithStudentses = new GroupWithStudents()
            {
                ID = Guid.NewGuid(),
                Course = CourseInitData.Courses[0],
                Title = $"Title",
                StartDate = new DateTime(2020, 08, 09),
                FinishDate = new DateTime(2021, 03, 15),
                Students = UserInitData.Students
            };
        }

        public static IEnumerable<object[]>DataForGetGroupWithStudent()
        {
            yield return new object[]
            {
                _groupWithStudentses
            };
        }
    }
}