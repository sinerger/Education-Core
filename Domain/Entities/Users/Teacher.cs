using Domain.Entities.Groups;

namespace Domain.Entities.Users
{
    public class Teacher : UserDetail
    {
        public Group Group { get; set; }
    }
}
