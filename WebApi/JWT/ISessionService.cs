using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Users;

namespace WebApi.JWT
{
    public interface ISessionService
    {
        Task<string> CreateAuthTokenAsync(UserWithRole user);
    }
}
