using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Users;

namespace WebApi.JWT
{
    public class ValidationResult
    {
        public bool IsSuccessful { get; set; }
        public  UserWithRole UserWithRole { get; set; }

        public ValidationResult(bool isSuccessful, UserWithRole userWithRole)
        {
            IsSuccessful = isSuccessful;
            UserWithRole = userWithRole;
        }
    }
}
