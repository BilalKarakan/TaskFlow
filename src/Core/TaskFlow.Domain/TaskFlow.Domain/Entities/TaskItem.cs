using TaskFlow.Domain.Common;
using TaskFlow.Domain.Events;
using static TaskFlow.Domain.Enums.Enums;

namespace TaskFlow.Domain.Entities;

public class TaskItem : Auditable, ISoftDeletable
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public TaskItemStatus Status { get; set; } = TaskItemStatus.Todo;
    public Priority Priority { get; set; } = Priority.Medium;
    public DateTime? DueDate { get; set; }
    public string ProjectId { get; set; } = default!;
    public string? AssignedToUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
    public Project Project { get; set; } = default!;

    private readonly List<Comment> _comments = [];
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    #region Domain Event Methods
    public void AssignTo(string userId)
    {
        AssignedToUserId = userId;
        AddDomainEvent(new TaskAssignedEvent(this, userId));
    }

    public void ChangeStatus(TaskItemStatus newStatus)
    {
        var oldStatus = Status;
        Status = newStatus;

        if (newStatus == TaskItemStatus.Done)
            AddDomainEvent(new TaskCompletedEvent(this));

    }

    public Comment AddComment(string content, string userId)
    {
        Comment comment = new()
        {
            Id = Guid.NewGuid().ToString(),
            Content = content,
            UserId = userId,
            TaskItemId = Id
        };

        _comments.Add(comment);
        return comment;
    }
    #endregion

}
