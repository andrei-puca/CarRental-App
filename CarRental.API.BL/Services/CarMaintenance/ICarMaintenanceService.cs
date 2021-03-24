using CarRental.API.BL.Models.CarMaintenance;
using CarRental.API.DAL.CustomEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.CarMaintenance
{
    public interface ICarMaintenanceService
    {
        Task<IEnumerable<CarMaintenanceModel>> GetCarsForMaintenance();

        Task<IEnumerable<CarServicesModel>> GetCarLastServiceAsync(Guid item);

    }
}
