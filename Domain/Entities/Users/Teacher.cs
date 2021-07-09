using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Groups;

namespace Domain.Entities.Users
{
    public class Teacher : UserDetail
    {
        public Group Group { get; set; }
    }
}
