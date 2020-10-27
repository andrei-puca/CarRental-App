using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.Prices
{
    public interface IPriceDataService
    {
        Task<PriceItem> GetAsync(Guid id);

        Task<IEnumerable<PriceItem>> GetAllAsync();

        Task<IEnumerable<PriceItem>> GetCarPriceAsync(Guid id);

        Task<PriceItem> CreateAsync(PriceItem price);

        Task<PriceItem> DeleteAsync(Guid Id);

        Task<PriceItem> UpsertAsync(PriceItem price);

    }
}
