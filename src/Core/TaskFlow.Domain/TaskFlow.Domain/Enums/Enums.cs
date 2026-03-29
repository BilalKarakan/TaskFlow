namespace TaskFlow.Domain.Enums;

public class Enums
{
    public enum NotificationType
    {
        TaskAssgned = 0,
        TaskCompleted = 1,
        TaskCommented = 2,
        ProjectCreated = 3,
        ProjectStatusChanged = 4
    }

    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2,
        Critical = 3
    }

    public enum ProjectStatus 
    {
        Planning = 0,
        Active = 1,
        OnHold = 2,
        Completed = 3,
        Archived = 4
    }

    public enum TaskItemStatus
    {
        Todo = 0,
        InProgress = 1,
        InReview = 2,
        Done = 3,
        Cancelled = 4
    }
}
