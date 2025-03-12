using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Domain.Enums;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitectureTemplate.Application.Todo.Commands.UpdateTodo
{
    public record UpdateTodoCommand : IRequest<ErrorOr<Updated>>
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public TodoPriority? Priority { get; init; }
    }
    public class UpdateTodo(IApplicationDbContext context, IMapper mapper) : IRequestHandler<UpdateTodoCommand, ErrorOr<Updated>>
    {
        public async Task<ErrorOr<Updated>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var existingTodo = await context.Todos.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);

            if (existingTodo is null)
            {
                return Error.NotFound();
            }

            mapper.Map(request, existingTodo);

            await context.SaveChangesAsync(cancellationToken);
            return Result.Updated;
        }
    }
}
