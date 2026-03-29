using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskFlow.Application.Common.IServices;
using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.IdentityModels;

namespace TaskFlow.Persistence;

public class TaskFlowDbContext : IdentityDbContext<AppUser, AppRole, string>, ITaskFlowDbContext
{
    private readonly IMediator _mediator;
    public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options, IMediator mediator) : base(options) => _mediator = mediator;
    public DbSet<Project> Projects => Set<Project>();

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
