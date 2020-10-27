using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.RentalLocations
{
    public interface IRentalLocationDataService
    {
        Task<RentalLocationItem> GetAsync(Guid id);

        Task<IEnumerable<RentalLocationItem>> GetAllAsync();

        Task<RentalLocationItem> CreateAsync(RentalLocationItem car);

        Task<RentalLocationItem> DeleteAsync(Guid Id);

        Task<RentalLocationItem> UpsertAsync(RentalLocationItem car);

    }
}
