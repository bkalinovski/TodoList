using AutoMapper;
using Todo.Contract.Models;
using Todo.Contract.Repository.Entities;

namespace Todo.Mapping
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoItem, TodoEntity>()
                .ForMember(t => t.Name, expression => expression.MapFrom(e => e.Description))
                .ReverseMap();
        }
    }
}