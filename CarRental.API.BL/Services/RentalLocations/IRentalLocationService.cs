using CarRental.API.BL.Models.RentalLocations;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.RentalLocations
{
    public interface IRentalLocationService
    {
        Task<IEnumerable<RentalLocationModel>> GetAllAsync();

        Task<RentalLocationModel> GetAsync(Guid id);

        Task<RentalLocationItem> CreateAsync(CreateRentalLocationModel item);

        Task<RentalLocationItem> UpsertAsync(RentalLocationModel item);

        Task<RentalLocationItem> DeleteAsync(Guid id);

    }
}
