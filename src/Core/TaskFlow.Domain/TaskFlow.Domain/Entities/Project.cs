using TaskFlow.Domain.Common;
using static TaskFlow.Domain.Enums.Enums;

namespace TaskFlow.Domain.Entities;

public class Project : Auditable, ISoftDeletable
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planning;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime? DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private readonly List<TaskItem> _tasks = [];
    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();
}
