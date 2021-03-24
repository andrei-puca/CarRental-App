using AutoMapper;
using CarRental.API.BL.Models.CarMaintenance;
using CarRental.API.DAL.CustomEntities;
using CarRental.API.DAL.DataServices.CarMaintenance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.CarMaintenance
{
    public class CarMaintenanceService : ICarMaintenanceService
    {

        private readonly IMapper _mapper;
        private readonly ICarMaintenanceDataService _carMaintenanceDataService;

     
        public CarMaintenanceService(IMapper mapper, ICarMaintenanceDataService carMaintenanceDataService)
        {
            _mapper = mapper;
            _carMaintenanceDataService = carMaintenanceDataService;
        }

        public async Task<IEnumerable<CarMaintenanceModel>> GetCarsForMaintenance()
        {
            var cars = await _carMaintenanceDataService.GetCarsForMaintenance();
            return _mapper.Map<IEnumerable<CarMaintenanceModel>>(cars);
        }

        public async Task<IEnumerable<CarServicesModel>> GetCarLastServiceAsync(Guid id)
        {
            var cars = await _carMaintenanceDataService.GetCarLastServiceAsync(id);
            return _mapper.Map<IEnumerable<CarServicesModel>>(cars);
        }

    }
}
