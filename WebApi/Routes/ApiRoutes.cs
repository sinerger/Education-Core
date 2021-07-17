using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Routes
{
    public static class ApiRoutes
    {
        private const string _getByIDDefaultRoute = "{id}";
        private const string _getAllDefaultRoute = "";
        private const string _updateDefaultRoute = "";
        private const string _deleteDefaultRoute = "{id}";
        private const string _createDefaultRoute = "";

        public const string Api = "api";
        public const string Controller = "/[controller]";

        public static class UserWIthRole
        {
            public static string Route => "/" + nameof(UserWIthRole);

            public const string GetUserWithRoleByID = _getByIDDefaultRoute;
            public const string GetUserWithRoleByLoginAndPassword = "login";
            public const string UpdateUserWithRole = _updateDefaultRoute;
            public const string DeleteUserWithRoleByID = _deleteDefaultRoute;
            public const string CreateUserWithRole = _createDefaultRoute;

            public static string GetRouteForCreate()
            {
                var result = Api + Route + "/" + CreateUserWithRole;

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

        public static class Lesson
        {
            public static string Route => "/" + nameof(Lesson);

            public const string GetAllLessons = _getAllDefaultRoute;
            public const string GetLessonByID = _getByIDDefaultRoute;
            public const string UpdateLesson = _updateDefaultRoute;
            public const string DeleteLesson = _deleteDefaultRoute;
            public const string CreateLessonWithinCourse = _createDefaultRoute;

            public static string GetRouteForAllLessons()
            {
                return Api + Route + "/";
            }

            public static string GetRouteForGetByID(Guid id)
            {
                var getByid = GetLessonByID == "{id}" ? "" : GetLessonByID;
                var result = Api + Route + getByid + "/" + id.ToString();

                return result;
            }

            public static string GetRouteForCreate()
            {
                var result = Api + Route + "/";

                return result;
            }

            public static string GetRouteForUpdate()
            {
                var result = Api + Route + "/";

                return result;
            }

            public static string GetRouteForDelete(Guid id)
            {
                var result = Api + Route + "/" + id.ToString();

                return result;
            }
        }

        public static class Group
        {
            public static string Route => "/" + nameof(Group);

            public const string GetAllGroups = _getAllDefaultRoute;
            public const string CreateGroupWithinCourse = _createDefaultRoute;


            public static string GetRouteForCreate()
            {
                var result = Api + Route + CreateGroupWithinCourse;

                return result;
            }

            public static string GetRouteForGetByID(Guid id)
            {
                var result = Api + Route + "/" + id.ToString();

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
            public static string GetRouteForGetAllGroups()
            {
                var result = Api + Route + GetAllGroups;

                return result;
            }
        }

        public static class UserDetail
        {
            public static string Route => "/" + nameof(UserDetail);

            public const string GetUserDetailByID = _getByIDDefaultRoute;
            public const string UpdateUserDetail = _updateDefaultRoute;

            public static string GetRouteForUpdate()
            {
                var result = Api + Route + "/";

                return result;
            }

            public static string GetRouteForGetByID(Guid id)
            {
                var getByID = GetUserDetailByID == "{id}" ? "" : GetUserDetailByID;
                var result = Api + Route + getByID + "/" + id.ToString();

                return result;
            }
        }

        public static class Course
        {
            public static string Route => "/" + nameof(Course);

            public const string GetAllCourses = _getAllDefaultRoute;
            public const string CreateCourse = _createDefaultRoute;
            public const string DeleteCourse = _deleteDefaultRoute;
            public const string UpdateCourse = _updateDefaultRoute;

            public static string GetRouteForGetAllCourses()
            {
                var result = Api + Route + "/";

                return result;
            }

            public static string GetRouteForCreate()
            {
                var result = Api + Route + "/";

                return result;
            }

            public static string GetRouteForDelete(Guid id)
            {
                var result = Api + Route + "/" + id.ToString();

                return result;
            }

            public static string GetRouteForUpdate()
            {
                var result = Api + Route + "/";

                return result;
            }
        }

        public static class Homework
        {
            public static string Route => "/" + nameof(Homework);

            public const string GetAllHomeworkByCourseID = "courseid";
            public const string GetHomeworkByLessonID = "lessonid";
            public const string AddHomeworkWithinLesson = "lessonid";
            public const string UpdateHomework = _updateDefaultRoute;
            public const string DeleteHomework = _deleteDefaultRoute;
            public const string CreateHomework = _createDefaultRoute;

            public static string GetRouteForCreate()
            {
                var result = Api + Route + "/";

                return result;
            }

            public static string GetRouteForGetByLessonID(Guid lessonID)
            {
                var getByID = GetHomeworkByLessonID == "{lessonid}" ? "/" : "/" + GetHomeworkByLessonID + "?lessonid=";
                var result = Api + Route + getByID + lessonID.ToString();

                return result;
            }

            public static string GetRouteForAddByLessonID(Guid lessonID)
            {
                var addByID = AddHomeworkWithinLesson == "{lessonid}" ? "/" : "/" + AddHomeworkWithinLesson + "?lessonid=";
                var result = Api + Route + addByID + lessonID.ToString();

                return result;
            }

            public static string GetRouteForGetAllByCourseID(Guid courseID)
            {
                var getAllByID = GetAllHomeworkByCourseID == "{courseid}" ? "/" : "/" + GetAllHomeworkByCourseID + "?courseid=";
                var result = Api + Route + getAllByID + courseID.ToString();

                return result;
            }

            public static string GetRouteForDelete(Guid homeworkID)
            {
                var delete = DeleteHomework == "{id}" ? "/" : "/" + DeleteHomework;
                var result = Api + Route + delete + homeworkID.ToString();

                return result;
            }

            public static string GetRouteForUpdate()
            {
                var update = UpdateHomework == "{id}" ? "/" : "/" + UpdateHomework;
                var result = Api + Route + update;

                return result;
            }
        }
    }
}
