﻿using Domain.Entities.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class UserWithRoleTData
    {
        private static List<UserWithRole> _users;
        private const int _countUsers = 1;

        public static void InitializeData()
        {
            _users = new List<UserWithRole>();

            for (int i = 0; i < _countUsers; i++)
            {
                _users.Add(new UserWithRole()
                {
                    ID = Guid.NewGuid(),
                    FirstName = $"integration test {i}",
                    LastName = $"integration test {i}",
                    Login = $"integration test  login{i}",
                    Password = $"integration test password{i}"
                });
            }
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            InitializeData();
            foreach (var user in _users)
            {
                yield return new object[]
                {
                    user,
                    user
                };
            }
        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            InitializeData();
            foreach (var user in _users)
            {
                yield return new object[]
                {
                    user
                };
            }
        }
    }
}
