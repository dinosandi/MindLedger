using System;
using System.Collections.Generic;
using Backend.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Color { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
