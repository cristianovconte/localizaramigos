using RepositoriesService.CalcLog;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace Repositories.CalcLog
{
    public class CalcLogRepository : ICalcLogRepository
    {
        private IConfiguration _configuration;

        public CalcLogRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void Log(System.DateTime dtLog, int selfPositionX, int selfPositionY, int friendPositionX, int friendPositionY, double calcResult)
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuration.GetConnectionString("LogDB")))
            {
                string sql = "INSERT INTO dbo.CalculoHistoricoLog VALUES (@DateLog, @SelfPositionX, @SelfPositionY, @FriendPositionX, @FriendPositionY, @CalcResult)";

                await conexao.ExecuteAsync(
                    sql, new
                    {
                        DateLog = dtLog,
                        SelfPositionX = selfPositionX,
                        SelfPositionY = selfPositionY,
                        FriendPositionX = friendPositionX,
                        FriendPositionY = friendPositionY,
                        CalcResult = calcResult
                    });
            }
        }
    }
}
