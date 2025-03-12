using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Interfaces;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Application.Todo.Queries.GetAllTodos
{
    public class GetAllTodosQuery : IRequest<ErrorOr<List<TodoDto>>>;
    public class GetAllTodos(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAllTodosQuery, ErrorOr<List<TodoDto>>>
    {
        public async Task<ErrorOr<List<TodoDto>>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await context.Todos.ToListAsync(cancellationToken: cancellationToken);

            var mappedTodos = mapper.Map<List<TodoDto>>(todos);

            return mappedTodos;
        }
    }
}
