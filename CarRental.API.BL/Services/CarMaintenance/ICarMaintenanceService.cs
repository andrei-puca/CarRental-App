using CarRental.API.BL.Models.CarMaintenance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.CarMaintenance
{
    public interface ICarMaintenanceService
    {
        Task<IEnumerable<CarMaintenanceModel>> GetCarsForMaintenance();

    }
}
