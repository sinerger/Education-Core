using Domain.Entities.Homeworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Lesson1
{
    public class Lesson
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Dictionary<Student, bool> Attendance { get; set; }
        public Teacher Teacher { get; set; } 
        public Homework Homework { get; set; }
    }
}
