using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Contract;
using Todo.Contract.Models;
using Todo.Contract.Repository;
using Todo.Contract.Repository.Entities;

namespace Todo.Services
{
    public class TodoDbService : ITodo
    {
        private readonly IRepository<TodoEntity> _todoList;
        private readonly IMapper _mapper;

        public TodoDbService(IRepository<TodoEntity> todoList, IMapper mapper)
        {
            _todoList = todoList;
            _mapper = mapper;
        }

        public async Task AddAsync(TodoItem item)
        {
            await _todoList.InsertAsync(_mapper.Map<TodoEntity>(item));
        }

        public async Task RemoveAsync(int id)
        {
            await _todoList.DeleteAsync(id);
        }

        public async Task RemoveAsync(TodoItem item)
        {
            await _todoList.DeleteAsync(_mapper.Map<TodoEntity>(item));
        }

        public async Task<List<TodoItem>> GetListAsync()
        {
            return await _todoList.Query()
                                  .Select(t => _mapper.Map<TodoItem>(t))
                                  .ToListAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(int id)
        {
            var entity = await _todoList.FindAsync(id);
            return _mapper.Map<TodoItem>(entity);
        }
    }
}