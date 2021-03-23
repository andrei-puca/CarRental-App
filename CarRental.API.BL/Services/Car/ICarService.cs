using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Car;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarModel>> GetAllAsync();

        Task<IEnumerable<CarModel>> GetRentedCarsAsync();

        Task<IEnumerable<CarModel>> GetAvailableCarsAsync();

        Task<CarModel> GetAsync(Guid id);
        
        Task<CarItem> CreateAsync(CreateCarModel item);

        Task<IEnumerable<CarItem>> UpsertAsync(CarModel item);

        Task<IEnumerable<CarItem>> MarkCarAsAvailable (CarAvailabilityModel item);

        Task<CarItem> DeleteAsync(Guid id);
    }
}
