using TaskFlow.Domain.Common;
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
    public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime? DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Project Project { get; set; } = default!;

    private readonly List<Comment> _comments = [];
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

}
