using TodoEntity = CleanArchitectureTemplate.Domain.Entities.Todo;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoEntity> Todos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
