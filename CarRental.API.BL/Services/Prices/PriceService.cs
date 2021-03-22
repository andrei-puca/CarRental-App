
using AutoMapper;
using CarRental.API.BL.Models.Prices;
using CarRental.API.DAL.DataServices.Prices;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.Prices
{
    public class PriceService : IPriceService
    {
        private readonly IMapper _mapper;
        private readonly IPriceDataService _priceDataService;

        public PriceService(IMapper mapper, IPriceDataService priceDataService)
        {
            _mapper = mapper;
            _priceDataService = priceDataService;
        }

        public async Task<IEnumerable<PriceModel>> GetAllAsync()
        {
            var prices = await _priceDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<PriceModel>>(prices);
        }

        public async Task<IEnumerable<DetailedPrices>> GetDetailedPrices()
        {
            var prices = await _priceDataService.GetDetailedPrices();
            return _mapper.Map<IEnumerable<DetailedPrices>>(prices);
        }


        public async Task<PriceModel> GetAsync(Guid id)
        {
            var price = await _priceDataService.GetAsync(id);
            return _mapper.Map<PriceModel>(price);
            

        }

        public async Task<IEnumerable<CarPrice>> GetCarPriceAsync(Guid id)
        {
            var price = await _priceDataService.GetCarPriceAsync(id);
            return _mapper.Map<IEnumerable<CarPrice>>(price);
        }


        public async Task<PriceItem> CreateAsync(CreatePriceModel item)
        {
            var price = _mapper.Map<PriceItem>(item);
            return await _priceDataService.CreateAsync(price);
        }

        public async Task<PriceItem> UpsertAsync(PriceModel item)
        {
            var price = _mapper.Map<PriceItem>(item);
            return await _priceDataService.UpsertAsync(price);
        }

        public async Task<PriceItem> DeleteAsync(Guid id)
        {
            return await _priceDataService.DeleteAsync(id);
        }

    }
}
