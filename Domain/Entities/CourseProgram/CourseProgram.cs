using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.CourseProgram
{
    public class CourseProgram
    {
        public Guid ID { get; set; }
        public Course Course { get; set; }
        public Lesson Lesson { get; set; }

    }
}

