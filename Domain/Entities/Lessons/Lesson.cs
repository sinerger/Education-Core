using System;
using System.Collections.Generic;
using Domain.Entities.Homeworks;
using Domain.Entities.Users;

namespace Domain.Entities.Lessons
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
