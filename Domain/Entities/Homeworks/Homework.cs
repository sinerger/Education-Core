using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Homeworks
{
    public class Homework
    {
        public Guid ID { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; } 
    }
}
