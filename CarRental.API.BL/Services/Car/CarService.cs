using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Car;
using CarRental.API.DAL.DataServices.Car;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarDataService _carDataService;

        public CarService(IMapper mapper, ICarDataService carDataService)
        {
            _mapper = mapper;
            _carDataService = carDataService;
        }

        public async Task<IEnumerable<CarModel>> GetAllAsync()
        {
            var cars = await _carDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<CarModel>>(cars);
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            var car = await _carDataService.GetAsync(id);
            return _mapper.Map<CarModel>(car);
        }

        public async Task<CarItem> CreateAsync(CreateCarModel item)
        {
            var car = _mapper.Map<CarItem>(item);
            return await _carDataService.CreateAsync(car);
          
        }

        public async Task<IEnumerable<CarItem>> UpsertAsync(CarModel item)
        {
            var car = _mapper.Map<CarItem>(item);
            return await _carDataService.UpsertAsync(car);
        }
        

        public async Task<CarItem> DeleteAsync(Guid id)
        {
            return await _carDataService.DeleteAsync(id);
        }
    
        public async Task<IEnumerable<CarItem>> MarkCarAsAvailable(CarAvailabilityModel item)
        {
            var car = _mapper.Map<CarItem>(item);
            return await _carDataService.MarkCarAsAvailable(car);
        }
    
    }
}
