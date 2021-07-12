using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Feedback
    {
        public Guid ID { get; set; }
        public UserWithRole Author { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
