using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.Car
{
    public interface ICarDataService
    {
        Task<CarItem> GetAsync(Guid id);
        
        Task<IEnumerable<CarItem>> GetAllAsync();

        Task<CarItem> CreateAsync(CarItem car);

        Task<CarItem> DeleteAsync(Guid Id);

        Task<IEnumerable<CarItem>> UpsertAsync(CarItem car);

        Task<IEnumerable<CarItem>> MarkCarAsAvailable(CarItem car);
    }
}
