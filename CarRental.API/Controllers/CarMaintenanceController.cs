using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.API.BL.Models.CarMaintenance;
using CarRental.API.BL.Services.CarMaintenance;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarMaintenanceController : ControllerBase
    {


        private readonly ICarMaintenanceService _carMaintenanceService;

    
        public CarMaintenanceController(ICarMaintenanceService carMaintenanceService)
        {
            _carMaintenanceService = carMaintenanceService;
        }


        [HttpGet]
        /// <summary>
        /// Get a list of items
        /// </summary>
        /// <returns>List with TodoModels</returns>
        public virtual async Task<IEnumerable<CarMaintenanceModel>> GetAll()
        {
            return await _carMaintenanceService.GetCarsForMaintenance();
        }
       
    }
}