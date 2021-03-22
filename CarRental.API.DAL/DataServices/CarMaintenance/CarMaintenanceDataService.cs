﻿using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.CustomEntities;
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

    }
}
