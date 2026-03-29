using TaskFlow.Domain.Common;
using TaskFlow.Domain.Events;
using static TaskFlow.Domain.Enums.Enums;

namespace TaskFlow.Domain.Entities;

public class Project : Auditable, ISoftDeletable
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planning;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }

    private readonly List<TaskItem> _tasks = [];
    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    #region Domain Event Methods
    public void Activate()
    {
        if (Status == ProjectStatus.Active)
            throw new InvalidOperationException("Project is already active.");

        Status = ProjectStatus.Active;
        StartDate ??= DateTime.UtcNow;
    }

    public void Complete()
    {
        if (_tasks.Any(t => t.Status != TaskItemStatus.Done && t.Status != TaskItemStatus.Cancelled))
            throw new InvalidOperationException("All tasks must be completed or cancelled before completing the project.");

        Status = ProjectStatus.Completed;
        EndDate = DateTime.UtcNow;
    }

    public TaskItem AddTask(string title, string? description, Priority priority, string? assignedToUserId)
    {
        TaskItem task = new()
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            Description = description,
            Priority = priority,
            ProjectId = this.Id,
            AssignedToUserId = assignedToUserId,
            Status = TaskItemStatus.Todo,
        };

        _tasks.Add(task);

        task.AddDomainEvent(new TaskCreatedEvent(task));

        if (assignedToUserId != null)
            task.AddDomainEvent(new TaskAssignedEvent(task, assignedToUserId));

        return task;
    }
    #endregion
}
