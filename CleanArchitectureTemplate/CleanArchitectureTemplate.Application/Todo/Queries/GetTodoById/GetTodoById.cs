using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Interfaces;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Application.Todo.Queries.GetTodoById
{
    public record GetTodoByIdQuery : IRequest<ErrorOr<TodoDto>>
    {
        public Guid Id { get; init; }
    }
    public class GetTodoById(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTodoByIdQuery, ErrorOr<TodoDto>>
    {
        public async Task<ErrorOr<TodoDto>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);

            if (todo is null)
            {
                return Error.NotFound();
            }

            return mapper.Map<TodoDto>(todo);
        }
    }
}
