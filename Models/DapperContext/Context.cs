using System.Data;
using Microsoft.Data.SqlClient;

namespace Estate.Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public Context(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);



        
    }
}