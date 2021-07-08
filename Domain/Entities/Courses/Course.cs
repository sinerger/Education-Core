using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Courses
{
    public class Course
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
