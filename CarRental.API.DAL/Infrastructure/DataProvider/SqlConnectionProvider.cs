using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.Infrastructure.DataProvider
{
    internal static class SqlConnectionProvider
    {
        internal static SqlConnection GetConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }

        internal static async Task<SqlConnection> GetConnectionAsync(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            return conn;
        }
    }
}
