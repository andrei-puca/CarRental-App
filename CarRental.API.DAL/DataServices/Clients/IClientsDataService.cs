using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.API.DAL.Entities;

namespace CarRental.API.DAL.DataServices.Clients
{
    public interface IClientsDataService
    {
        Task<ClientsItem> GetAsync(int id);
        Task<IEnumerable<ClientsItem>> GetAllAsync();

    }
}
