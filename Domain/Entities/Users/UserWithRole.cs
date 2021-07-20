using Domain.Entities.Roles;

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
