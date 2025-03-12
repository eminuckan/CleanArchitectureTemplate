using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Application.Todo
{
    public record TodoDto
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public bool IsCompleted { get; init; }
        public TodoPriority Priority { get; init; }
    }
}
