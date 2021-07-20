using Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class UserWithRoleTData
    {
        private static UserWithRole _user;

        static UserWithRoleTData()
        {
            _user = new UserWithRole()
            {
                ID = Guid.NewGuid(),
                FirstName = $"Integration test ",
                LastName = $"Integration test ",
                Login = "Integration test  login",
                Password = $"Integration test password"
            };
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            yield return new object[]
            {
                _user,
                _user
            };
        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            yield return new object[]
            {
                _user
            };
        }
    }
}
