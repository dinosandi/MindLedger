using System;
using Microsoft.AspNetCore.Identity;

namespace Backend.Domain.Entities;

public class User : IdentityUser<Guid>
{

    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}