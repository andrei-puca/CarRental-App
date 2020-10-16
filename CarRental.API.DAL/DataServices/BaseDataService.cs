using Microsoft.Extensions.Options;
using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.Infrastructure.DataProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices
{
    public abstract class BaseDataService : IBaseDataService
    {
        private readonly DatabaseOptions _options;

        public BaseDataService(IOptions<DatabaseOptions> databaseOptions)
        {
            _options = databaseOptions.Value;
        }

        protected SqlConnection GetOpenConnection()
        {

            return SqlConnectionProvider.GetConnection(_options.ConnectionString);
        }

        protected async Task<SqlConnection> GetOpenConnectionAsync()
        {
            
            return await SqlConnectionProvider.GetConnectionAsync(_options.ConnectionString);
        }
              
    }
}
