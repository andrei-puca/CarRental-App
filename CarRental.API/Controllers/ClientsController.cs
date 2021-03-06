﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.API.BL.Models;
using CarRental.API.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.API.BL.Services.Clients;
using CarRental.API.BL.Models.Clients;
using CarRental.API.DAL.Entities;

namespace CarRental.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientService;

        public ClientsController(IClientsService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        [Route("GetAllClients")]
        /// <summary>
        /// Get a list of items
        /// </summary>
        /// <returns>List with TodoModels</returns>
        public virtual async Task<IEnumerable<ClientsModel>> GetAllClients()
        {
            return await _clientService.GetAllAsync();
        }

        /// <summary>
        /// Get an item by its id.
        /// </summary>
        /// <param name="id">id of the item you want to get</param>
        /// <returns>Item or StatusCode 404</returns>
        [HttpGet("GetClient/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<ClientsModel>> GetOneClient(Guid id)
        {

            var item = await _clientService.GetAsync(id);
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
        [Route("CreateClient")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual async Task<ClientsItem> CreateOneClient(CreateClientModel item)
        {
            return await _clientService.CreateAsync(item);
        }

        /// <summary>
        /// Update or create an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("UpdateClient")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<int>> Update(UpdateClientModel item)
        {
            var updateItemId = await _clientService.UpsertAsync(item);
            return Ok(updateItemId);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Id of the item to delete</param>
        /// <returns>StatusCode 200 or 404</returns>
        [HttpDelete("DeleteClient/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<bool>> Delete(Guid id)
        {
            var deletedItem = await _clientService.DeleteAsync(id);
            return Ok(deletedItem);
        }
    }
}
