using System;

namespace Domain.Entities.Homeworks
{
    public class Homework
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; } 
    }
}
