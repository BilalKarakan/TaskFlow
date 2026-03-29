using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Common.IServices;

public interface ITaskFlowDbContext
{
    DbSet<Project> Projects { get; }
    DbSet<TaskItem> TaskItems { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Notification> Notifications { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
