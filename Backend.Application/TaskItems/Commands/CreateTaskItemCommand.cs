using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.TaskItems.Commands;

public class CreateTaskItemCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = null!;
    public string Priority { get; set; } = null!;

    // Upload file
    public IFormFile? ImageFile { get; set; }
}
