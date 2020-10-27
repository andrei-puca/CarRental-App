using CarRental.API.BL.Models.Clients;
using CarRental.API.BL.Models.Reservations;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.Reservation
{
    public interface IReservationService
    {

        Task<IEnumerable<ReservationModel>> GetAllAsync();

        Task<ReservationModel> GetAsync(Guid id);

        Task<IEnumerable<ReservationItem>> CreateAsync(CreateReservationModel item);

        Task<IEnumerable<ReservationItem>> CreateAsyncWithNewCustomer(CreateReservationWithNewClientModel item, CreateClientModel clients);

        Task<IEnumerable<ReservationItem>> UpsertAsync(UpdateReservationModel item);

        Task<ReservationItem> DeleteAsync(Guid id);
    }
}
