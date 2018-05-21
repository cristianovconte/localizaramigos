using ApplicationServices.Authentication;
using CrossCutting.Authentication;
using Microsoft.IdentityModel.Tokens;
using RepositoriesServices.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository _authenticationRepository;
        SigningConfigurations _signingConfigurations;
        TokenConfigurations _tokenConfigurations;

        public AuthenticationService(IAuthenticationRepository authenticationRepository,
                                     SigningConfigurations signingConfigurations,
                                     TokenConfigurations tokenConfigurations)
        {
            _authenticationRepository = authenticationRepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public object Login(User user)
        {
            var userAuthenticated = _authenticationRepository.Login(user);

            if (userAuthenticated == null)
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.UserID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserID)
                    }
                );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao.AddSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
