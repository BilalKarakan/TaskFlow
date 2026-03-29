using MediatR;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Events;

public class TaskCompletedEvent : INotification
{
    public TaskItem Task { get; } = default!;
    public TaskCompletedEvent(TaskItem task)
    {
        Task = task;
    }
}
