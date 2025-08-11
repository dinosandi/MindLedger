using System;

namespace Backend.Domain.Entities;

public class Transactions
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Foreign key to Users
    public Guid CategoryId { get; set; } // Foreign key to Categories
}
