using System;

namespace Backend.Domain;

public class Tasks
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Foreign key to Users
    public Guid CategoryId { get; set; } // Foreign key to Categories
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
   
}
