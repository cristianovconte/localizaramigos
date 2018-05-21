using System;
using System.Collections.Generic;
using Entities.CloseFriends;
using RepositoriesServices.CloseFriends;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Repositories.CloseFriends
{
    public class CloseFriendsRepository : ICloseFriendRepository
    {
        private IConfiguration _configuration;

        public CloseFriendsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<Friend> GetPositions()
        {
            using (SqlConnection connection = new SqlConnection(
                  _configuration.GetConnectionString("CloseFriendDB")))
            {
                const string sql = "SELECT Id, Name, X, Y FROM dbo.Friend";
                using (var multi = connection.QueryMultiple(sql))
                {
                    var friendsPositions = multi.Read<Friend>().AsList();

                    return friendsPositions;
                }
            }
        }
    }
}
