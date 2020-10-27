using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Clients;
using CarRental.API.BL.Services.Clients;
using CarRental.API.DAL.DataServices.Car;
using CarRental.API.DAL.DataServices.Clients;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services
{
    public class ClientService : IClientsService
    {
        private readonly IMapper _mapper;
        private readonly IClientsDataService _clientsDataService;

        public ClientService(IMapper mapper, IClientsDataService clientsDataService)
        {
            _mapper = mapper;
            _clientsDataService = clientsDataService;
        }

        public async Task<IEnumerable<ClientsModel>> GetAllAsync()
        {
            var clients = await _clientsDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientsModel>>(clients);
        }

        public async Task<ClientsModel> GetAsync(Guid id)
        {
            var client = await _clientsDataService.GetAsync(id);
            return _mapper.Map<ClientsModel>(client);
        }

        public async Task<ClientsItem> CreateAsync(CreateClientModel item)
        {
            var client = _mapper.Map<ClientsItem>(item);
            return await _clientsDataService.CreateAsync(client);

        }

        public async Task<ClientsItem> UpsertAsync(UpdateClientModel item)
        {
            var client = _mapper.Map<ClientsItem>(item);
            return await _clientsDataService.UpsertAsync(client);
        }

        public async Task<ClientsItem> DeleteAsync(Guid id)
        {
            return await _clientsDataService.DeleteAsync(id);
        }
    }
}
