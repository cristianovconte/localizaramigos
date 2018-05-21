using CrossCutting.Authentication;
using Dapper;
using Microsoft.Extensions.Configuration;
using RepositoriesServices.Authentication;
using System;
using System.Data.SqlClient;

namespace Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private IConfiguration _configuration;

        public AuthenticationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Login(User user)
        {
            using (SqlConnection conexao = new SqlConnection(
                 _configuration.GetConnectionString("AuthenticationDB")))
            {
                return conexao.QueryFirstOrDefault<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.Users " +
                    "WHERE UserID = @UserID AND AccessKey = @AccessKey", new { UserID = user.UserID, AccessKey = user.AccessKey });
            }
        }
    }
}
