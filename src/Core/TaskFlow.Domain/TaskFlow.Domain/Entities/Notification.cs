using TaskFlow.Domain.Common;
using static TaskFlow.Domain.Enums.Enums;

namespace TaskFlow.Domain.Entities;

public class Notification : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; } = default!;
    public string RelatedProjectId { get; set; } = default!;
    public string RelatedTaskId { get; set; } = default!;
}
