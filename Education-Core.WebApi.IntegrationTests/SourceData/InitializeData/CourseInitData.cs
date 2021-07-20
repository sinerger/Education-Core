﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Courses;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class CourseInitData
    {
        public  static  List<Course> Courses { get; set; }

        static CourseInitData()
        {
            Courses = new List<Course>();

            for (int i = 0; i < 3; i++)
            {
                Courses.Add(new Course()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Integratio Test{i}",
                    Description = $"Description{i}"
                });
            }
        }
    }
}