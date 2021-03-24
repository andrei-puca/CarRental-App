using CarRental.API.DAL.CustomEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.CarMaintenance
{
    public interface ICarMaintenanceDataService
    {
        Task<IEnumerable<CarsToBeMaintained>> GetCarsForMaintenance();

        Task<IEnumerable<CarsServiceHistory>> GetCarLastServiceAsync(Guid id);
    }
}
