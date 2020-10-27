using CarRental.API.BL.Services.RentalLocations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.API.BL.Models.RentalLocations;
using CarRental.API.DAL.Entities;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalLocationsController : ControllerBase
    {
        private readonly IRentalLocationService _rentalLocationService;

        public RentalLocationsController(IRentalLocationService rentalLocationService)
        {
            _rentalLocationService = rentalLocationService;
        }


        [HttpGet]
        [Route("GetAllRentalLocations")]
        /// <summary>
        /// Get a list of items
        /// </summary>
        /// <returns>List with TodoModels</returns>
        public virtual async Task<IEnumerable<RentalLocationModel>> GetAllRentalLocations()
        {
            return await _rentalLocationService.GetAllAsync();        
        }

        /// <summary>
        /// Get an item by its id.
        /// </summary>
        /// <param name="id">id of the item you want to get</param>
        /// <returns>Item or StatusCode 404</returns>
        [HttpGet("GetRentalLocation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<RentalLocationModel>> GetOneRentalLocation(Guid id)
        {

            var item = await _rentalLocationService.GetAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;

        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item">Model to add, id will be ignored</param>
        /// <returns>Id of created item</returns>
        [Route("CreateRentalLocation")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual async Task<RentalLocationItem> CreateOneRentalLocation(CreateRentalLocationModel item)
        {
            return await _rentalLocationService.CreateAsync(item);
        }

        /// <summary>
        /// Update or create an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("UpdateRentalLocation")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<int>> UpdateRentalLocation(RentalLocationModel item)
        {
            var updateItemId = await _rentalLocationService.UpsertAsync(item);
            return Ok(updateItemId);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Id of the item to delete</param>
        /// <returns>StatusCode 200 or 404</returns>
        [HttpDelete("DeleteRentalLocation/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<bool>> DeleteRentalLocation(Guid id)
        {
            var deletedItem = await _rentalLocationService.DeleteAsync(id);
            return Ok(deletedItem);
        }

    }
}
