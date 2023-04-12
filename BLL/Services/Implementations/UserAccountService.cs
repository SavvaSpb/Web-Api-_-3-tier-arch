using BLL.Models;
using BLL.Models.Exceptions;
using BLL.AuthHelpers;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace BLL.Services.Implementations
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository repo;

        private readonly JwtModel jwtModel;

        public UserAccountService(IUserAccountRepository repo, IOptions<JwtModel> jwtToken)
        {
            this.repo = repo;
            this.jwtModel = jwtToken.Value;
        }

        public LoginResponseModel Login(UserAccountModel model)
        {

            var userAccount = repo.GetByLoginParameters(model.Email, model.Password);

            //if nt found user, code: 401        
            if (userAccount is null)
            {
                throw new ValidationException("User not found");
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userAccount.Email) };

            // create JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: jwtModel.Issuer,
                    audience: jwtModel.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(jwtModel.ExpirationTime)), // take from app settings
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(jwtModel.Key), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // create response
            var response = new LoginResponseModel
            {
                AccessToken = encodedJwt,
                Email = model.Email
            };

            return response;

        }

        public List<UserAccountModel> Get()
        {
            List<UserAccount> userAccountEntities = repo.Get();

            if (!userAccountEntities.Any())
            {
                throw new ValidationException("We have no any person");
            }

            var userAccount = new List<UserAccountModel>();

            foreach (var item in userAccountEntities)
            {
                userAccount.Add(new UserAccountModel
                {
                    Email = item.Email,
                    Password = item.Password,
                    Phone = item.Phone
                });
            }
            return userAccount;
        }

        List<UserAccountModel> IUserAccountService.Get()
        {
            throw new NotImplementedException();
        }

    }
}
