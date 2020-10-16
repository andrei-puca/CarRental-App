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

namespace CarRental.API.DAL.DataServices.Car
{
    public class CarDataService : BaseDataService, ICarDataService
    {
        private const string SpReadAll = "dbo.GetMyCars";

        public CarDataService(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
        }

        /// <summary>
        /// Dapper.FastCrud example
        /// </summary>
        public async Task<CarItem> GetAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.GetAsync(new CarItem() { Id = id });
            }
        }

        /// <summary>
        /// Dapper with stored procedure
        /// </summary>
        public async Task<IEnumerable<CarItem>> GetAllAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<CarItem>(
                    sql: SpReadAll,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<CarItem> CreateAsync(CarItem car)
        {

            using (var conn = await GetOpenConnectionAsync())
            {
                car.Id = Guid.NewGuid();
                conn.Insert(car);
            }
            return car;
        }

        public async Task<CarItem> DeleteAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Delete<CarItem>(new CarItem { Id = id});
            }
            return null;
        }

        public async Task<CarItem> UpsertAsync(CarItem car)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Update<CarItem>(car);
            }
            return null;
        }


    }
}
