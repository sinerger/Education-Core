using Domain.Entities.Courses;
using Domain.Entities.Lessons;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Courses
{
    public class CourseWithLessons : Course
    {
        public List<Lesson> Lessons { get; set; }
    }
}
