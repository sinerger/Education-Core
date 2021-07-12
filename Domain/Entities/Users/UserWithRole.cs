﻿using Domain.Entities.Roles;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Users
{
    public class UserWithRole : UserAbstract
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public TypeRole Role { get; set; }

        public UserWithRole()
        {
            Role = TypeRole.Admin;
        }
    }
}
