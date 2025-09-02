using System;
using Microsoft.AspNetCore.Identity;

namespace Backend.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string GoogleId { get; set; } = string.Empty; // payload.Subject
    public string Name { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
