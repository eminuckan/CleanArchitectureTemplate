using Carter;
using CleanArchitectureTemplate.Application.Todo.Commands.CreateTodo;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureTemplate.API.Common;
using CleanArchitectureTemplate.Application.Todo.Queries.GetAllTodos;
using CleanArchitectureTemplate.Application.Todo.Queries.GetTodoById;
using CleanArchitectureTemplate.Application.Todo.Commands.DeleteTodo;
using CleanArchitectureTemplate.Application.Todo.Commands.UpdateTodo;

namespace CleanArchitectureTemplate.API.Endpoints
{
    public class TodoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app) 
        {
            var group = app.MapGroup("/todos");
            group.MapPost("/", AddTodo);
            group.MapPut("/{id}", UpdateTodo);
            group.MapDelete("/{id}", DeleteTodo);
            group.MapGet("/{id}", GetTodoById);
            group.MapGet("/", GetAllTodos);
        }

        private async Task<IResult> GetAllTodos(ISender sender)
        {
            var query = new GetAllTodosQuery();
            var response = await sender.Send(query);

            return response.ToMinimalApiResult();
        }

        private async Task<IResult> GetTodoById(ISender sender, [FromRoute]Guid id)
        {
            var query = new GetTodoByIdQuery()
            {
                Id = id
            };

            var response = await sender.Send(query);
            return response.ToMinimalApiResult();
        }

        private async Task<IResult> DeleteTodo(ISender sender, [FromRoute] Guid id)
        {
            var command = new DeleteTodoCommand()
            {
                Id = id
            };

            var response = await sender.Send(command);
            return response.ToMinimalApiResult();
        }

        private async Task<IResult> UpdateTodo(ISender sender, [FromRoute] Guid id, UpdateTodoCommand commandBody)
        {
            var command = commandBody with { Id = id };
            var response = await sender.Send(command);
            return response.ToMinimalApiResult();
        }

        private async Task<IResult> AddTodo(ISender sender, CreateTodoCommand request)
        {
            ErrorOr<Created> response = await sender.Send(request);
            return response.ToMinimalApiResult();
            
        }
    }
}
