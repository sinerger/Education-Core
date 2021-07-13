using System;
using Domain.Entities.Courses;
using Domain.Entities.Lessons;

namespace Domain.Entities.CoursePrograms
{
    public class CourseProgram
    {
        public Guid ID { get; set; }
        public Course Course { get; set; }
        public Lesson Lesson { get; set; }
    }
}

