using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.CustomEntities;
using CarRental.API.DAL.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.CarMaintenance
{
    public class CarMaintenanceDataService : BaseDataService, ICarMaintenanceDataService
    {

        private const string GetNextCarsToBeMaintained = "GetCarServiceDueDate";
        private const string SpGetCarLastServiceDate = "GetCarLastServiceDate";
        private const string SpCreateServiceRecord = "CreateServiceRecord";

        public CarMaintenanceDataService(IOptions<DatabaseOptions> databaseOptions)
           : base(databaseOptions)
        {
        }

        public async Task<IEnumerable<CarsToBeMaintained>> GetCarsForMaintenance()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<CarsToBeMaintained>(
                    sql: GetNextCarsToBeMaintained,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CarsServiceHistory>> GetCarLastServiceAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<CarsServiceHistory>(
                     param: new
                     {
                         CarId = id,
                     },
                    sql: SpGetCarLastServiceDate,
                    commandType: CommandType.StoredProcedure);
            }

        }


        public async Task<IEnumerable<ServiceItem>> CreateServiceRecord(ServiceItem item)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<ServiceItem>(
                     param: new
                     {
                         CarId = item.CarId,
                         LastServiceDate = item.LastServiceDate,
                         LastServiceMileage = item.LastServiceMileage,
                         ServiceIntervalKm = item.ServiceIntervalKm,
                         ServiceIntervalDate = item.ServiceIntervalDate,
                     },
                    sql: SpCreateServiceRecord,
                    commandType: CommandType.StoredProcedure);
            }

        }



        }
    }
