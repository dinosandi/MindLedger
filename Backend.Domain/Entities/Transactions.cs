using System;

namespace Backend.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public string Type { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; } = null!;
    public string? ImagePath { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; } = null!;
    public Category? Category { get; set; }
}
