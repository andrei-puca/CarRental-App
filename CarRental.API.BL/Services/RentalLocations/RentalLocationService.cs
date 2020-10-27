

using AutoMapper;
using CarRental.API.BL.Models.RentalLocations;
using CarRental.API.DAL.DataServices.RentalLocations;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.RentalLocations
{
    public class RentalLocationService : IRentalLocationService
    {
        private readonly IMapper _mapper;
        private readonly IRentalLocationDataService _rentalLocationDataService;

        public RentalLocationService (IMapper mapper, IRentalLocationDataService rentalLocationDataService)
        {
            _mapper = mapper;
            _rentalLocationDataService = rentalLocationDataService;
        }

        public async Task<IEnumerable<RentalLocationModel>> GetAllAsync()
        {
            var rentalLocations = await _rentalLocationDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<RentalLocationModel>>(rentalLocations);
        }

        public async Task<RentalLocationModel> GetAsync(Guid id)
        {
            var rentalLocation = await _rentalLocationDataService.GetAsync(id);
            return _mapper.Map<RentalLocationModel>(rentalLocation);
        }


        public async Task<RentalLocationItem> CreateAsync(CreateRentalLocationModel item)
        {
            var rentalLocation = _mapper.Map<RentalLocationItem>(item);
            return await _rentalLocationDataService.CreateAsync(rentalLocation);
        }

        public async Task<RentalLocationItem> DeleteAsync(Guid id)
        {
            return await _rentalLocationDataService.DeleteAsync(id);
        }

        public async Task<RentalLocationItem> UpsertAsync(RentalLocationModel item)
        {
            var rentalLocation = _mapper.Map<RentalLocationItem>(item);
            return await _rentalLocationDataService.UpsertAsync(rentalLocation);
        }
    }
}
