using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Lessons
{
    public class Attendance
    {
        public Student Student { get; set; }
        public bool IsVisited { get; set; }
    }
}
