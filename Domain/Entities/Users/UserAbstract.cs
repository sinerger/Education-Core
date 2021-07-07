using Insight.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Users
{
    public abstract class UserAbstract
    {
        [RecordId]
        //[Column("UserID")]
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
