using Domain.Entities.Groups;
using Domain.Entities.Users;
using System.Collections.Generic;

namespace Domain.Entities.GroupWithStudents
{
    public class GroupWithStudent : Group
    {
        public List<Student> Students { get; set; }
    }
}
