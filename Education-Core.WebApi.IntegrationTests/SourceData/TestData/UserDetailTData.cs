using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class UserDetailTData
    {
        private static UserWithRole _userWithRole;
        private static UserDetail _userDetail;

        static UserDetailTData()
        {
            _userWithRole = new UserWithRole()
            {
                ID = Guid.NewGuid(),
                FirstName = $"integration test ",
                LastName = $"integration test ",
                Login = $"integration test  login",
                Password = $"integration test password",
            };

            _userDetail = new UserDetail()
            {
                ID = _userWithRole.ID,
                FirstName = _userWithRole.FirstName,
                LastName = _userWithRole.LastName,
                City = $"Integration test City",
                DateOfBirth = new DateTime(1995, 09, 05),
                Email = "integrationTest@mail.com",
                Phone = "0000000000",
                Feedbacks = FeedbackInitData.Feedbacks
            };
        }

        public static IEnumerable<object[]> GetDataForUpdate()
        {
            yield return new object[]
            {
                    _userWithRole,
                    _userDetail,
                    _userDetail
            };
        }
    }
}