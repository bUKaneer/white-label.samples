using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gateway.SharedKernel;

public abstract class HasDomainEventsBase
{
  private List<DomainEventBase> _domainEvents = new();
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  internal void ClearDomainEvents() => _domainEvents.Clear();

}

