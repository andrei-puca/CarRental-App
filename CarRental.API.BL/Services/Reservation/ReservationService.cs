using AutoMapper;
using CarRental.API.BL.Helper;
using CarRental.API.BL.Models.Clients;
using CarRental.API.BL.Models.Prices;
using CarRental.API.BL.Models.Reservations;
using CarRental.API.BL.Services.Prices;
using CarRental.API.Common.SettingsOptions;
using CarRental.API.DAL.DataServices.Prices;
using CarRental.API.DAL.DataServices.Reservations;
using CarRental.API.DAL.Entities;
using Microsoft.Extensions.Options;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CarRental.API.BL.Services.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationDataService _reservationDataService;

        private readonly ApiOptions _options;
        public ReservationService(IMapper mapper, IReservationDataService reservationDataService, IOptions<ApiOptions> apiOptions)
        {
            _mapper = mapper;
            _reservationDataService = reservationDataService;
            _options = apiOptions.Value;
        }

        public async Task<IEnumerable<ReservationItem>> CreateAsync(CreateReservationModel item)
        {

            item.RentalStartDate = item.RentalStartDate.ToLocalTime();
            item.RentalEndDate = item.RentalEndDate.ToLocalTime();

            var responseString = ApiCall.GetApi("https://localhost:44310/price/GetPriceByCarId/" + item.CarId + "/" + item.RentalStartDate + "/" + item.RentalEndDate);
            var rootobject = new JavaScriptSerializer().Deserialize<List<PriceItem>>(responseString);

            foreach (var price in rootobject)
            {
                if (price.CarId == item.CarId)
                    item.TotalPrice = price.Price;
            }
            var reservation = _mapper.Map<ReservationItem>(item);
            return await _reservationDataService.CreateAsync(reservation);
        }

        public async Task<IEnumerable<ReservationItem>> CreateAsyncWithNewCustomer(CreateReservationWithNewClientModel item, CreateClientModel clients)
        {
            var reservation = _mapper.Map<ReservationItem>(item);
            var client = _mapper.Map<ClientsItem>(clients);
            return await _reservationDataService.CreateAsyncWithNewClient(reservation, client);
        }

        public async Task<ReservationItem> DeleteAsync(Guid id)
        {
            return await _reservationDataService.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReservationModel>> GetAllAsync()
        {
            var reservations = await _reservationDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationModel>>(reservations);
        }

        public async Task<IEnumerable<DetailedReservationModel>> GetDetailedReservations()
        {
            var reservations = await _reservationDataService.GetDetailedReservations();
            return _mapper.Map<IEnumerable<DetailedReservationModel>>(reservations);
        }


        public async Task<ReservationModel> GetAsync(Guid id)
        {
            var reservation = await _reservationDataService.GetAsync(id);
            return _mapper.Map<ReservationModel>(reservation);
        }

        public async Task<IEnumerable<ReservationItem>> UpsertAsync(UpdateReservationModel item)
        {
            var reservation = _mapper.Map<ReservationItem>(item);
            return await _reservationDataService.UpsertAsync(reservation);
        }
    }
}
