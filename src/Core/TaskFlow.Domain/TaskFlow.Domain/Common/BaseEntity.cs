using MediatR;

namespace TaskFlow.Domain.Common;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        this.Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }

    private readonly List<INotification> _domainEvent = [];

    #region Domain Events Methods
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvent.AsReadOnly();

    public void AddDomainEvent(INotification domainEvent)
    {
        _domainEvent.Add(domainEvent);
    }

    public void RemoveDomainEvent(INotification domainEvent)
    {
        _domainEvent.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvent.Clear();
    }
    #endregion
}
