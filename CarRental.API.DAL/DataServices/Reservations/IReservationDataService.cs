using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.Reservations
{
    public interface IReservationDataService
    {
        Task<ReservationItem> GetAsync(Guid id);

        Task<IEnumerable<ReservationItem>> GetAllAsync();

        Task<IEnumerable<ReservationItem>> CreateAsync (ReservationItem reservation);

        Task<IEnumerable<ReservationItem>> CreateAsyncWithNewClient(ReservationItem reservation, ClientsItem client);

        Task<ReservationItem> DeleteAsync(Guid Id);

        Task<IEnumerable<ReservationItem>> UpsertAsync(ReservationItem car);

    }
}
