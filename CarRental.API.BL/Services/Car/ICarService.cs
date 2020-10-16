using CarRental.API.BL.Models;
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
        
        Task<CarModel> GetAsync(Guid id);
        
        Task<CarItem> CreateAsync(CarModel item);
        
        Task<CarItem> UpsertAsync(CarModel item);
        
        Task<CarItem> DeleteAsync(Guid id);
    }
}
