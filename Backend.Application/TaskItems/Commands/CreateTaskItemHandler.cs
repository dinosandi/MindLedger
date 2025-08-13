using Backend.Application.Features.TaskItems.Commands;
using Backend.Domain.Entities;
using Backend.Infrastructure.FileStorage;
using MediatR;

namespace Backend.Application.Features.TaskItems.Handlers;

public class CreateTaskItemHandler : IRequestHandler<CreateTaskItemCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileStorageService _fileStorage;

    public CreateTaskItemHandler(IApplicationDbContext context, IFileStorageService fileStorage)
    {
        _context = context;
        _fileStorage = fileStorage;
    }

    public async Task<Guid> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
    {
        string? imagePath = null;
        if (request.ImageFile != null)
        {
            imagePath = await _fileStorage.SaveFileAsync(request.ImageFile, "task-images");
        }

        var entity = new TaskItem
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            Status = request.Status,
            Priority = request.Priority,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ImagePath = imagePath
        };

        _context.TaskItems.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
