using Domain.Entities.Groups;
using Domain.Entities.Roles;
using Domain.Entities.Solutions;
using System.Collections.Generic;

namespace Domain.Entities.Users
{
    public class Student : UserWithRole
    {
        public string AgreementNumber { get; set; }
        public Group Group { get; set; }
        public List<Solution> Solutions { get; set; }

        public Student()
        {
            Role = TypeRole.Student;
        }
    }
}
