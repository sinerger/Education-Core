using Domain.Entities.Groups;

namespace Domain.Entities.Users
{
    public class Teacher : UserWithRole
    {
        public Group Group { get; set; }
    }
}
