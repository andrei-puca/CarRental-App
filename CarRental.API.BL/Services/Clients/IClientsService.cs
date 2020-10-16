using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services.Clients
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientsModel>> GetAllAsync();

        Task<ClientsModel> GetAsync(int id);

        Task<int> CreateAsync(ClientsModel item);

        Task<int> UpsertAsync(ClientsModel item);

        Task DeleteAsync(Guid id);

    }
}
