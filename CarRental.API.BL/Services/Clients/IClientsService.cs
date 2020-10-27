using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Clients;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.Clients
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientsModel>> GetAllAsync();

        Task<ClientsModel> GetAsync(Guid id);

        Task<ClientsItem> CreateAsync(CreateClientModel item);

        Task<ClientsItem> UpsertAsync(UpdateClientModel item);

        Task<ClientsItem> DeleteAsync(Guid id);

    }
}
