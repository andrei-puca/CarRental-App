﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.API.BL.Models.CarMaintenance;
using CarRental.API.BL.Services.CarMaintenance;
using CarRental.API.DAL.Entities;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [Route("LastServiceDate")]
        public virtual async Task<IEnumerable<CarServicesModel>> GetCarLastService(Guid id)
        {
            var item = await _carMaintenanceService.GetCarLastServiceAsync(id);
            return item;
        }

        [HttpPut]
        [Route("ServiceRecord")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual async Task<IEnumerable<ServiceItem>> AddNewServiceForCar(CarNewServiceModel item)
        {
            return await _carMaintenanceService.CreateServiceRecord(item);
        }

    }
}