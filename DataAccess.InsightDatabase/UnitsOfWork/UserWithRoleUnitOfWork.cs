using DataAccess.InsightDatabase.Repositories;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.InsightDatabase.UnitsOfWork
{
    public class UserWithRoleUnitOfWork : IUserWithRoleUnitOfWork
    {
        public IDbConnection DBConnection { get ; set ; }
        public IUserWithRoleRepository UserWithRoleRepository { get; set; }

        public UserWithRoleUnitOfWork(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            UserWithRoleRepository = new UserWithRoleRepository(DBConnection);
        }

    }
}
