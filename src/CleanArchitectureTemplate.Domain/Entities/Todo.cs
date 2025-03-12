using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.ValueObjects;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Todo : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [NotMapped]
        public TodoDescription Description { get; set; } = new(string.Empty);

        public bool IsCompleted { get; set; } = false;

        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
    }
}
