﻿using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class UserDetailData
    {
        private static List<UserWithRole> _usersWithRole;
        private static List<UserDetail> _usersDetail;
        private const int _countUsers = 1;

        static UserDetailData()
        {
            _usersWithRole = new List<UserWithRole>();

            for (int i = 0; i < _countUsers; i++)
            {
                _usersWithRole.Add(new UserWithRole()
                {
                    ID = Guid.NewGuid(),
                    FirstName = $"integration test {i}",
                    LastName = $"integration test {i}",
                    Login = $"integration test  login{i}",
                    Password = $"integration test password{i}",
                });
            }

            _usersDetail = new List<UserDetail>();

            for (int i = 0; i < _countUsers; i++)
            {
                _usersDetail.Add(new UserDetail()
                {
                    ID = _usersWithRole[i].ID,
                    FirstName = _usersWithRole[i].FirstName,
                    LastName = _usersWithRole[i].LastName,
                    City = $"Integration test City{i}",
                    DateOfBirth = new DateTime(1995, 09, 05),
                    Email = "integrationTest@mail.com",
                    Phone = "0000000000",
                    Feedbacks = FeedbackData.Feedbacks
                });
            }
        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            for (int i = 0; i < _countUsers; i++)
            {
                yield return new object[]
                {
                    _usersWithRole[i],
                    _usersDetail[i],
                    _usersDetail[i]
                };
            }
        }
    }
}