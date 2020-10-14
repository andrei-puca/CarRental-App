using CarRental.API.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoModel>> GetAllAsync();
        
        Task<TodoModel> GetAsync(int id);
        
        Task<int> CreateAsync(TodoModel item);
        
        Task<int> UpsertAsync(TodoModel item);
        
        Task DeleteAsync(Guid id);
    }
}
