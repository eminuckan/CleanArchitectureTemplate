using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureTemplate.Infrastructure.Data
{
    public static class InitializerExtensions
    {
        public static async Task InitialiseDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>();

            await initialiser.InitialiseAsync();
            await initialiser.SeedAsync();
        }
    }
    public class ApplicationDbInitializer
    {
        private readonly ILogger<ApplicationDbInitializer> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbInitializer(ILogger<ApplicationDbInitializer> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            if (!_context.Todos.Any())
            {
                var todos = new List<Todo>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Buy groceries",
                        Description = new TodoDescription("Milk, Bread, Eggs, Fruits"),
                        IsCompleted = false,
                        Priority = TodoPriority.High
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Finish project report",
                        Description = new TodoDescription("Complete and submit final report"),
                        IsCompleted = false,
                        Priority = TodoPriority.Medium
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Call mom",
                        Description = new TodoDescription("Check on her and ask about her health"),
                        IsCompleted = false,
                        Priority = TodoPriority.Low
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Workout",
                        Description = new TodoDescription("30 minutes of cardio and strength training"),
                        IsCompleted = false,
                        Priority = TodoPriority.Medium
                    }
                };

                _context.Todos.AddRange(todos);
                await _context.SaveChangesAsync();
            }
        }
    }
}
