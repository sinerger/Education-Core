using Domain.Entities.Users;
using Insight.Database;
using System;

namespace Domain.Entities.Feedbacks
{
    public class Feedback
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
