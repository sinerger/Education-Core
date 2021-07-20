using Domain.Entities.GroupWithStudents;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class GroupWithStudentsTData
    {
        private static GroupWithStudents _groupWithStudentses;

        static GroupWithStudentsTData()
        {
            _groupWithStudentses = new GroupWithStudents()
            {
                ID = Guid.NewGuid(),
                Course = CourseInitData.Course,
                Title = "Title",
                StartDate = new DateTime(2020, 08, 09),
                FinishDate = new DateTime(2021, 03, 15),
                Students = UserInitData.Students
            };
        }

        public static IEnumerable<object[]> GetDataForGetGroupWithStudent()
        {
            yield return new object[]
            {
                _groupWithStudentses
            };
        }
    }
}
