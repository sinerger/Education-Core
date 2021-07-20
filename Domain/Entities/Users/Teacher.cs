using System.Collections.Generic;
using Domain.Entities.Groups;
using Domain.Entities.Roles;

namespace Domain.Entities.Users
{
    public class Teacher : UserWithRole
    {
        public List<Group> Groups { get; set; }
        public Teacher()
        {
            Role = TypeRole.Teacher;
        }
    }
}
