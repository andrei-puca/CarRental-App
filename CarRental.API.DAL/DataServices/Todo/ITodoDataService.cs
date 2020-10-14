using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.DAL.DataServices.Todo
{
    public interface ITodoDataService
    {
        Task<TodoItem> GetAsync(int id);
        
        Task<IEnumerable<TodoItem>> GetAllAsync();
    }
}
