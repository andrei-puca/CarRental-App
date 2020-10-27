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

namespace CarRental.API.DAL.DataServices.Reservations
{
    public class ReservationDataService : BaseDataService , IReservationDataService
    {
        private const string SpCreate = "CreateReservation";
        private const string SpCreateWithNewClient = "CreateReservationWithNewClient";
        private const string SpReadAll = "GetReservations";
        private const string SpUpdate = "UpdateReservation";

        public ReservationDataService(IOptions<DatabaseOptions> databaseOptions)
           : base(databaseOptions)
        {
        }

        public async Task<IEnumerable<ReservationItem>> CreateAsync(ReservationItem reservation)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<ReservationItem>(
                     param: new { 
                         Id = reservation.Id,
                         ClientId = reservation.ClientId,
                         CarId = reservation.CarId,
                         RentalStartDate = reservation.RentalStartDate,
                         RentalEndDate = reservation.RentalEndDate,
                         PickUpLocation = reservation.PickUpLocation,
                         DropOffLocation = reservation.DropOffLocation,
                         TotalPrice = reservation.TotalPrice
                     },
                    sql: SpCreate,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<IEnumerable<ReservationItem>> CreateAsyncWithNewClient(ReservationItem reservation, ClientsItem client)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<ReservationItem>(
                     param: new
                     {
                         Id = reservation.Id,
                         FullName = client.FullName,
                         CarId = reservation.CarId,
                         RentalStartDate = reservation.RentalStartDate,
                         RentalEndDate = reservation.RentalEndDate,
                         PickUpLocation = reservation.PickUpLocation,
                         DropOffLocation = reservation.DropOffLocation,
                         TotalPrice = reservation.TotalPrice
                     },
                    sql: SpCreateWithNewClient,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ReservationItem> DeleteAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                conn.Delete<ReservationItem>(new ReservationItem { Id = id });
            }
            return null;
        }

        public async Task<IEnumerable<ReservationItem>> GetAllAsync()
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<ReservationItem>(
                    sql: SpReadAll,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ReservationItem> GetAsync(Guid id)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.GetAsync(new ReservationItem() { Id = id });
            }
        }

        public async Task<IEnumerable<ReservationItem>> UpsertAsync(ReservationItem reservation)
        {
            using (var conn = await GetOpenConnectionAsync())
            {
                return await conn.QueryAsync<ReservationItem>(
                     param: new
                     {
                         Id = reservation.Id,
                         ClientId = reservation.ClientId,
                         CarId = reservation.CarId,
                         RentalStartDate = reservation.RentalStartDate,
                         RentalEndDate = reservation.RentalEndDate,
                         PickUpLocation = reservation.PickUpLocation,
                         DropOffLocation = reservation.DropOffLocation,
                     },
                    sql: SpUpdate,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
