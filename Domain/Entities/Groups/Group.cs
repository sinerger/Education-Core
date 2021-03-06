using System;
using Domain.Entities.Courses;
using Domain.Entities.Users;

namespace Domain.Entities.Groups
{
    public class Group
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Course Course { get; set; }
    }
}
