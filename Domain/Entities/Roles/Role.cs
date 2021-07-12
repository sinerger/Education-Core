using System;

namespace Domain.Entities.Roles
{
    public class Role
    {
        public Guid ID { get; set; }
        public TypeRole Type { get; private set; }
    }
}
