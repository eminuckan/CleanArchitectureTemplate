

using FluentValidation;

namespace CleanArchitectureTemplate.Application.Todo.Commands.CreateTodo
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoValidator()
        {
            RuleFor(t => t.Title).NotEmpty().NotNull().MaximumLength(200);
        }
    }
}
