using CarRental.API.BL.Models.Prices;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.Prices
{
    public interface IPriceService
    {
        Task<IEnumerable<PriceModel>> GetAllAsync();

        Task<IEnumerable<DetailedPrices>> GetDetailedPrices();

        Task<PriceModel> GetAsync(Guid id);

        Task<IEnumerable<CarPrice>> GetCarPriceAsync(Guid id);

        Task<PriceItem> CreateAsync(CreatePriceModel item);

        Task<PriceItem> UpsertAsync(PriceModel item);

        Task<PriceItem> DeleteAsync(Guid id);

    }
}
