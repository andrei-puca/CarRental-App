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
using System.Globalization;

namespace CarRental.API.DAL.DataServices.Car
{
    public class CarDataService : BaseDataService, ICarDataService
    {
        private const string SpReadAll = "dbo.GetMyCars";
        private const string SpUpdate = "UpdateCar";
        private const string SpReadRentedCars = "GetRentedCars";
        private const string SpReadAvailableCars = "GetAvailableCars";
        private const string SpMarkAvailability = "MarkCarAsReceived";

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

        public async Task<IEnumerable<CarItem>> GetRentedCarsAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<CarItem>(
                    sql: SpReadRentedCars,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CarItem>> GetAvailableCarsAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<CarItem>(
                    sql: SpReadAvailableCars,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<CarItem> CreateAsync(CarItem car)
        {

            using (var conn = await GetOpenConnectionAsync())
            {
                car.Id = Guid.NewGuid();
                car.CreatedOn = DateTime.Now;
                car.UpdatedOn = DateTime.Now;

                conn.Insert(car);
            }
            return car;
        }

        public async Task<CarItem> DeleteAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Delete<CarItem>(new CarItem { Id = id });
            }
            return null;
        }

        public async Task<IEnumerable<CarItem>> UpsertAsync(CarItem car)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<CarItem>(
                     param: new
                     {
                         Id = car.Id,
                         Brand = car.Brand,
                         Model = car.Model,
                     },
                    sql: SpUpdate,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<IEnumerable<CarItem>> MarkCarAsAvailable (CarItem car)
        {
            //var parameters = new DynamicParameters();
            //parameters.Add("MileageUntilService", dbType: DbType.Int64, direction: ParameterDirection.Output);

            using (var conn = await GetOpenConnectionAsync())
            {

                return await conn.QueryAsync<CarItem>(
                     param: new
                     {
                         Id = car.Id,
                         Mileage = car.Mileage,
                     },
                    sql: SpMarkAvailability,
                    commandType: CommandType.StoredProcedure);
            }

        }


    }
}
