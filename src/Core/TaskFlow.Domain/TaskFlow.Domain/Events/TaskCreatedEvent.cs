using MediatR;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Events;

public class TaskCreatedEvent : INotification
{
    public TaskItem Task { get; } = default!;
	public TaskCreatedEvent(TaskItem task)
	{
		Task = task;
	}
}
