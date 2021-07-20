using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using WebApi.JWT;
using WebApi.JWT.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private IDBContext _dbContext;
        private AuthService _authenticationService;

        public AuthController(IDBContext dbContext, ISessionService sessionService)
        {
            _dbContext = dbContext;
            _sessionService = sessionService;
            _authenticationService = new AuthService(dbContext);
        }

        [AllowAnonymous]
        [HttpPost("{login}")]
        public async Task<string> Login(AuthenticationModel authenticationModel)
        {
           //TODO Шифровать пароль во время регистрации
           var validationResult = await _authenticationService.LoginAsync(authenticationModel);

           if (validationResult.IsSuccessful==false)
           {
               BadRequest("Uncorrect login or password");
           }

           var token = await _sessionService.CreateAuthTokenAsync(validationResult.UserWithRole);

           return token;
        }
    }
}
