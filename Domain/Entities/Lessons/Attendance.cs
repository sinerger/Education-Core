using Domain.Entities.Users;

namespace Domain.Entities.Lessons
{
    public class Attendance
    {
        public Student Student { get; set; }
        public bool IsVisited { get; set; }
    }
}
