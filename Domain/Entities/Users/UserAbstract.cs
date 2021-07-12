using System;
using Insight.Database;

namespace Domain.Entities.Users
{
    public abstract class UserAbstract
    {
        [RecordId]
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
