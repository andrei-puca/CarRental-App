using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Clients;
using CarRental.API.BL.Services.Clients;
using CarRental.API.DAL.DataServices.Car;
using CarRental.API.DAL.DataServices.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services
{
    public class ClientService : IClientsService
    {
        private readonly IMapper _mapper;
        private readonly IClientsDataService _todoDataService;

        public ClientService(IMapper mapper, IClientsDataService todoDataService)
        {
            _mapper = mapper;
            _todoDataService = todoDataService;
        }

        public async Task<IEnumerable<ClientsModel>> GetAllAsync()
        {
            var todos = await _todoDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientsModel>>(todos);
        }

        public async Task<ClientsModel> GetAsync(int id)
        {
            var todo = await _todoDataService.GetAsync(id);
            return _mapper.Map<ClientsModel>(todo);
        }

        public async Task<int> CreateAsync(ClientsModel item)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpsertAsync(ClientsModel item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
