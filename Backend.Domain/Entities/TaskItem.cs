using System;

namespace Backend.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = null!;
    public string Priority { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Path file image
    public string? ImagePath { get; set; }

    public User User { get; set; } = null!;
    public Category? Category { get; set; }
}
