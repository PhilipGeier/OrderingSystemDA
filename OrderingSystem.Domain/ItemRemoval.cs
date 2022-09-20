using OrderingSystem.Domain.Enums;

namespace OrderingSystem.Domain;

public class ItemRemoval
{
    public Guid Id { get; init; }
    public IDictionary<Guid, int> RemovedItems { get; init; }
    public DateTime Time { get; init; }
    public RemovalReason RemovalReason { get; init; }
    public Guid RegisterId { get; init; }
}