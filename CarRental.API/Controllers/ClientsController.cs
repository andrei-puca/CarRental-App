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

namespace CarRental.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _todoService;

        public ClientsController(IClientsService todoService)
        {
            _todoService = todoService;
        }


        [HttpGet]
        [Route("GetAllClients")]
        /// <summary>
        /// Get a list of items
        /// </summary>
        /// <returns>List with TodoModels</returns>
        public virtual async Task<IEnumerable<ClientsModel>> GetAllClients()
        {
            return await _todoService.GetAllAsync();
        }

        /// <summary>
        /// Get an item by its id.
        /// </summary>
        /// <param name="id">id of the item you want to get</param>
        /// <returns>Item or StatusCode 404</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<ClientsModel>> GetOneClient(int id)
        {
            try
            {
                var item = await _todoService.GetAsync(id);
                if (item is null)
                {
                    return NotFound();
                }
                return item;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item">Model to add, id will be ignored</param>
        /// <returns>Id of created item</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<int>> CreateOneClient(ClientsModel item)
        {
            return await _todoService.CreateAsync(item);
        }

        /// <summary>
        /// Update or create an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<int>> UpdateClient(ClientsModel item)
        {
            var updateItemId = await _todoService.UpsertAsync(item);
            return Ok(updateItemId);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Id of the item to delete</param>
        /// <returns>StatusCode 200 or 404</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<bool>> DeleteClient(Guid id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
