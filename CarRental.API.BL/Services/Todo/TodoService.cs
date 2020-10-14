using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.DAL.DataServices.Todo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Services
{
    public class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly ITodoDataService _todoDataService;

        public TodoService(IMapper mapper, ITodoDataService todoDataService)
        {
            _mapper = mapper;
            _todoDataService = todoDataService;
        }

        public async Task<IEnumerable<TodoModel>> GetAllAsync()
        {
            var todos = await _todoDataService.GetAllAsync();
            return _mapper.Map<IEnumerable<TodoModel>>(todos);
        }

        public async Task<TodoModel> GetAsync(int id)
        {
            var todo = await _todoDataService.GetAsync(id);
            return _mapper.Map<TodoModel>(todo);
        }

        public async Task<int> CreateAsync(TodoModel item)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpsertAsync(TodoModel item)
        {
            throw new NotImplementedException();
        }
        
        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
