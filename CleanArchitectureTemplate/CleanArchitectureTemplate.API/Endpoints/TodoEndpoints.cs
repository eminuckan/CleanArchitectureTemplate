using Carter;
using CleanArchitectureTemplate.Application.Todo.Commands.CreateTodo;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureTemplate.API.Common;

namespace CleanArchitectureTemplate.API.Endpoints
{
    public class TodoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app) 
        {
            app.MapPost("/todos", AddTodo);
        }

        private async Task<IResult> AddTodo(ISender sender, CreateTodoCommand request)
        {
            ErrorOr<Created> response = await sender.Send(request);
            return response.ToMinimalApiResult();
            
        }
    }
}
