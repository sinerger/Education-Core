using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Roles
{
    public interface IRole
    {
        Guid ID { get; set; }
        TypeRole Type { get; set; }
    }
}
