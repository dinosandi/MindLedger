using System;

namespace Backend.Domain.Entities;

public class Categories 
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Foreign key to Users
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
