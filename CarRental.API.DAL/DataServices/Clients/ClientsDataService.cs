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

namespace CarRental.API.DAL.DataServices.Clients
{
    public class ClientsDataService : BaseDataService , IClientsDataService
    {
        private const string SpReadAll = "dbo.GetClients";

        public ClientsDataService(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
        }

        /// <summary>
        /// Dapper.FastCrud example
        /// </summary>
        public async Task<ClientsItem> GetAsync(int id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.GetAsync(new ClientsItem() { Id = id });
            }
        }

        /// <summary>
        /// Dapper with stored procedure
        /// </summary>
        public async Task<IEnumerable<ClientsItem>> GetAllAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<ClientsItem>(
                    sql: SpReadAll,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
