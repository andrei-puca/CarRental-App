using CarRental.API.BL.Models.Prices;
using CarRental.API.BL.Services.Prices;
using CarRental.API.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }


        [HttpGet]
        [Route("GetAllPrices")]
        /// <summary>
        /// Get a list of items
        /// </summary>
        /// <returns>List with TodoModels</returns>
        public virtual async Task<IEnumerable<PriceModel>> GetAllPrices()
        {
          
            return await _priceService.GetAllAsync();
        }

        [HttpGet]
        [Route("GetDetailedPrices")]
        public virtual async Task<IEnumerable<DetailedPrices>> GetDetailedPrices()
        {
            return await _priceService.GetDetailedPrices();
        }



        /// <summary>
        /// Get an item by its id.
        /// </summary>
        /// <param name="id">id of the item you want to get</param>
        /// <returns>Item or StatusCode 404</returns>
        [HttpGet("GetPrice/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<PriceModel>> GetOnePrice(Guid id)
        {

            var item = await _priceService.GetAsync(id);
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
        [HttpPost("AddPrice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual async Task<PriceItem> CreateOnePrice(CreatePriceModel item)
        {
            return await _priceService.CreateAsync(item);
        }

        /// <summary>
        /// Update or create an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("UpdatePrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<int>> UpdatePrice(PriceModel item)
        {
            var updateItemId = await _priceService.UpsertAsync(item);
            return Ok(updateItemId);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Id of the item to delete</param>
        /// <returns>StatusCode 200 or 404</returns>
        [HttpDelete("DeletePrice/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<bool>> DeletePrice(Guid id)
        {
            await _priceService.DeleteAsync(id);
            return NoContent();
        }


    }
}
