using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Routes
{
    public static class ApiRoutes
    {
        private const string _getDefaultRoute = "{id}";
        private const string _updateDefaultRoute = "";
        private const string _deleteDefaultRoute = "{id}";
        private const string _createDefaultRoute = "";

        public const string Api = "api";
        public const string Controller = "/[controller]";

        public static class UserWIthRole
        {
            public static string Route => "/" + nameof(UserWIthRole);

            public const string GetUserWithRoleByID = _getDefaultRoute;
            public const string GetUserWithRoleByLoginAndPassword = "login";
            public const string UpdateUserWithRole = _updateDefaultRoute;
            public const string DeleteUserWithRoleByID = _deleteDefaultRoute;
            public const string CreateUserWithRole = _createDefaultRoute;

            public static string GetRouteForCreate()
            {
                var result = Api + Route + CreateUserWithRole;

                return result;
            }

            public static string GetRouteForGetByID(Guid id)
            {
                var result = Api + Route + "/" + id.ToString();

                return result;
            }

            public static string GetRouteForGetByLoginAndPassword(string login, string password)
            {
                var result = Api + Route + "/" + GetUserWithRoleByLoginAndPassword + "?login=" + login + "&password=" + password;

                return result;
            }

            public static string GetRouteForUpdate()
            {
                var result = Api + Route;

                return result;
            }

            public static string GetRouteForDelete(Guid id)
            {
                var result = Api + Route + "/" + id.ToString();

                return result;
            }
        }
    }
}
