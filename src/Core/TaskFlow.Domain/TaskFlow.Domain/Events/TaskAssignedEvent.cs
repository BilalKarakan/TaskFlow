using MediatR;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Events;

public class TaskAssignedEvent : INotification
{
    public TaskItem Task { get; } = default!;
    public string AssignedToUserId { get; } = default!;

    public TaskAssignedEvent(TaskItem task, string assignedToUserId)
    {
        Task = task;
        AssignedToUserId = assignedToUserId;
    }

}
