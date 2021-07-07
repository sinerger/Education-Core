using DataAccess.InsightDatabase.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.InsightDatabase
{
    public class DBContext : IDBContext
    {
        public IDbConnection DBConnection { get; }
        public IUserWithRoleRepository UserWithRoleRepository => new UserWithRoleRepository(DBConnection);
        public IUserDetailRepository UserDetailRepository => new UserDetailRepository(DBConnection);


        public DBContext(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }
    }
}
