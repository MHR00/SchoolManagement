using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.DbAccesss
{
    public class Connection : IConnection
    {

        private readonly IConfiguration _config;
        public Connection(IConfiguration config)
        {
            _config = config;

        }
        public async Task ConncetionToDB(string connectionId = "Default")
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        }

    }
}
