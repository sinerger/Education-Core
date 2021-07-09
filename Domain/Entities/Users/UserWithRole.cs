using System;
using System.Collections.Generic;
using System.Text;
using Insight.Database;
using Domain.Entities.Roles;

namespace Domain.Entities.Users
{
    public class UserWithRole : UserAbstract
    {
        public string Login { get; set; }
        public string Password { get; set; }

        [ChildRecords]
        public Role Role { get; set; }
    }
}
