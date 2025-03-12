using CleanArchitectureTemplate.Application.Common.Interfaces;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Application.Todo.Commands.DeleteTodo
{
    public record DeleteTodoCommand : IRequest<ErrorOr<Deleted>>
    {
        public Guid Id { get; init; }
    }
    public class DeleteTodo(IApplicationDbContext context) : IRequestHandler<DeleteTodoCommand, ErrorOr<Deleted>>
    {
        public async Task<ErrorOr<Deleted>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);

            if (todo is null)
            {
                return Error.NotFound();
            }

            context.Todos.Remove(todo);
            await context.SaveChangesAsync(cancellationToken);

            return Result.Deleted;
        }
    }
}
