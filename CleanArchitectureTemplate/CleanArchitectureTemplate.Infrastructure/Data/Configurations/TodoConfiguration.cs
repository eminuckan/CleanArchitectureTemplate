using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Infrastructure.Data.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.IsCompleted)
                .IsRequired();

            builder.Property(t => t.Priority)
                .HasConversion<int>()
                .IsRequired();

            builder.OwnsOne(t => t.Description, descBuilder =>
            {
                descBuilder.Property(d => d.Value)
                    .HasColumnName("Description")
                    .HasMaxLength(500)
                    .IsRequired();
            });
        }
    }
}
