using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.Entities;
using Dapper;
using Dapper.FastCrud;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.RentalLocations
{
    public class RentalLocationDataService : BaseDataService , IRentalLocationDataService
    {
        private const string SpReadAll = "dbo.GetRentalLocations";

        public RentalLocationDataService(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
        }

        /// <summary>
        /// Dapper.FastCrud example
        /// </summary>
        public async Task<RentalLocationItem> GetAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.GetAsync(new RentalLocationItem() { Id = id });
            }
        }

        /// <summary>
        /// Dapper with stored procedure
        /// </summary>
        public async Task<IEnumerable<RentalLocationItem>> GetAllAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<RentalLocationItem>(

                    sql: SpReadAll,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<RentalLocationItem> CreateAsync(RentalLocationItem rentalLocation)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                rentalLocation.Id = Guid.NewGuid();
                conn.Insert(rentalLocation);
            }
            return rentalLocation;
        }

        public async Task<RentalLocationItem> DeleteAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Delete<RentalLocationItem>(new RentalLocationItem { Id = id });
            }
            return null;
        }

        public async Task<RentalLocationItem> UpsertAsync(RentalLocationItem rentalLocation)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Update<RentalLocationItem>(rentalLocation);
            }
            return null;
        }
    }
}
