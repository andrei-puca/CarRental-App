using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.API.DAL.Entities;

namespace CarRental.API.DAL.DataServices.Clients
{
    public interface IClientsDataService
    {
        Task<ClientsItem> GetAsync(Guid id);

        Task<IEnumerable<ClientsItem>> GetAllAsync();

        Task<ClientsItem> CreateAsync(ClientsItem car);

        Task<ClientsItem> DeleteAsync(Guid Id);

        Task<ClientsItem> UpsertAsync(ClientsItem car);

    }
}
