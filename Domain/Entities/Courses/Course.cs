using System;

namespace Domain.Entities.Courses
{
    public class Course
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
