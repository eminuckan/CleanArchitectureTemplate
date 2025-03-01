using CleanArchitectureTemplate.Application.Common.Interfaces;
using TodoEntity = CleanArchitectureTemplate.Domain.Entities.Todo;
using CleanArchitectureTemplate.Domain.Enums;
using ErrorOr;
using MediatR;
using CleanArchitectureTemplate.Domain.ValueObjects;

namespace CleanArchitectureTemplate.Application.Todo.Commands.CreateTodo
{
    public record CreateTodoCommand : IRequest<ErrorOr<Created>>
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public TodoPriority? Priority { get; init; }
        
    }
    public class CreateTodo(IApplicationDbContext context) : IRequestHandler<CreateTodoCommand, ErrorOr<Created>>
    {
        public async Task<ErrorOr<Created>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            TodoEntity todo = new TodoEntity()
            {
                Title = request.Title,
                Description = new TodoDescription(request.Description ?? ""),
                IsCompleted = false,
                Priority = request.Priority ?? TodoPriority.Medium
            };

            await context.Todos.AddAsync(todo, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return Result.Created;
        }
    }
}
