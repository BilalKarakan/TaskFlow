using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class Comment : Auditable
{
    public string Content { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string TaskItemId { get; set; } = default!;
    public TaskItem TaskItem { get; set; } = default!;
}
