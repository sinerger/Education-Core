using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserWithRoleUnitOfWork
    {
        IDbConnection DBConnection { get; set; }
        IUserWithRoleRepository UserWithRoleRepository { get; set; }
    }
}
