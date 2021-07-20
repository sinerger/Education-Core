using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Users;
using Domain.Interfaces;

namespace WebApi.JWT.Services
{
    public class AuthService
    {
        private IDBContext _dbContext;

        public AuthService(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ValidationResult> LoginAsync(AuthenticationModel authenticationModel)
        {
            try
            {
                var user = await  _dbContext.UserWithRoleRepository.GetUserWithRoleByLoginAndPasswordAsync
                    (authenticationModel.Login, authenticationModel.Password);

                ValidationResult result=null;

                if (user != null)
                {
                    result = new ValidationResult(true, user);
                }
                else
                {
                    result = new ValidationResult(false, null);
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
