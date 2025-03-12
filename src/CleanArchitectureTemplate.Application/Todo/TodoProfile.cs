using AutoMapper;
using CleanArchitectureTemplate.Application.Todo.Commands.UpdateTodo;
using TodoEntity = CleanArchitectureTemplate.Domain.Entities.Todo;

namespace CleanArchitectureTemplate.Application.Todo
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<UpdateTodoCommand, TodoEntity>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TodoEntity, TodoDto>().ForMember(d => d.Description, opts => opts.MapFrom(s => s.Description.Value)).ReverseMap();
        }
    }
}
