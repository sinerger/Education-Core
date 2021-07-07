using Domain.Interfaces.UserRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IUserWithRoleRepository UserWithRoleRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }

        IDbConnection DBConnection { get; }

    }
}
