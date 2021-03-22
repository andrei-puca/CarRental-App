using CarRental.API.BL.Models.Clients;
using CarRental.API.BL.Models.Reservations;
using CarRental.API.BL.Services.Reservation;
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
    public class ReservationController : ControllerBase
    {

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        [Route("CreateReservation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual async Task<IEnumerable<ReservationItem>> CreateOneReservation(CreateReservationModel item)
        {
            return await _reservationService.CreateAsync(item);
        }

        //[HttpPost]
        //[Route("CreateReservationWithNewClient")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesDefaultResponseType]
        //public virtual async Task<IEnumerable<ReservationItem>> CreateOneReservationWithNewClient(CreateReservationWithNewClientModel item, CreateClientModel client)
        //{
        //    return await _reservationService.CreateAsyncWithNewCustomer(item, client);
        //}


        [HttpGet]
        [Route("GetAllReservations")]
        /// <summary>
        /// Get a list of items
        /// </summary>
        /// <returns>List with TodoModels</returns>
        public virtual async Task<IEnumerable<ReservationModel>> GetAllReservations()
        {
            return await _reservationService.GetAllAsync();
        }


        [HttpGet]
        [Route("GetReservationsDetailed")]
        public virtual async Task<IEnumerable<DetailedReservationModel>> GetDetailedreservations()
        {
            return await _reservationService.GetDetailedReservations();
        }

        /// <summary>
        /// Get an item by its id.
        /// </summary>
        /// <param name="id">id of the item you want to get</param>
        /// <returns>Item or StatusCode 404</returns>

        [HttpGet("GetReservation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<ReservationModel>> GetOneReservation(Guid id)
        {
            var item = await _reservationService.GetAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }


        /// <summary>
        /// Update or create an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("UpdateReservation")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<int>> UpdateReservation(UpdateReservationModel item)
        {
            var updateItemId = await _reservationService.UpsertAsync(item);
            return Ok(updateItemId);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Id of the item to delete</param>
        /// <returns>StatusCode 200 or 404</returns>

        [HttpDelete("DeleteReservation/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<bool>> DeleteReservation(Guid id)
        {
            var deletedItem = await _reservationService.DeleteAsync(id);
            return Ok(deletedItem);
        }




    }
}
