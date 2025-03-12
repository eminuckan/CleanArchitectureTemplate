using FluentValidation;

namespace CleanArchitectureTemplate.Application.Todo.Commands.UpdateTodo
{
    public class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoValidator()
        {
            RuleFor(t => t.Title).MaximumLength(200);
        }
    }
}
