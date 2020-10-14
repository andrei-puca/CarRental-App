using Dapper;
using Dapper.FastCrud;
using Microsoft.Extensions.Options;
using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.Todo
{
    public class TodoDataService : BaseDataService, ITodoDataService
    {
        private const string SpReadAll = "dbo.GET_ALL";

        public TodoDataService(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
        }

        /// <summary>
        /// Dapper.FastCrud example
        /// </summary>
        public async Task<TodoItem> GetAsync(int id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.GetAsync(new TodoItem() { Id = id });
            }
        }

        /// <summary>
        /// Dapper with stored procedure
        /// </summary>
        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<TodoItem>(
                    sql: SpReadAll,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
