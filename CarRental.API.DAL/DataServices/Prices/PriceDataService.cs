using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.Entities;
using CarRental.API.DAL.CustomEntities;
using Dapper;
using Dapper.FastCrud;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.Prices
{
    class PriceDataService : BaseDataService , IPriceDataService
    {
        private const string SpReadAll = "dbo.GetAllPrices";
        private const string GetCarPrice = "dbo.GetPriceForSelectedCar";
        private const string ReadDetailedPrices = "dbo.GetDetailedPrices";

        public PriceDataService(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
        }

        /// <summary>
        /// Dapper.FastCrud example
        /// </summary>
        public async Task<PriceItem> GetAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.GetAsync(new PriceItem() { Id = id });
            }
        }

        /// <summary>
        /// Dapper with stored procedure
        /// </summary>
        public async Task<IEnumerable<PriceItem>> GetAllAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<PriceItem>(

                    sql: SpReadAll,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DetailedPriceItem>> GetDetailedPrices()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<DetailedPriceItem>(
                    sql: ReadDetailedPrices,
                    commandType: CommandType.StoredProcedure);
            }

        }
        
        public async Task<IEnumerable<PriceItem>> GetCarPriceAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<PriceItem>(
                    param: new { CarId = id },
                    sql: GetCarPrice,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<PriceItem> CreateAsync(PriceItem price)
        {

            using (var conn = await GetOpenConnectionAsync())
            {
                price.Id = Guid.NewGuid();
                conn.Insert(price);
            }
            return price;
        }

        public async Task<PriceItem> DeleteAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Delete<PriceItem>(new PriceItem { Id = id });
            }
            return null;
        }

        public async Task<PriceItem> UpsertAsync(PriceItem price)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Update<PriceItem>(price);
            }
            return null;
        }



    }
}
