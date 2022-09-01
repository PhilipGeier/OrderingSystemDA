using OrderingSystem.Domain.Enums;

namespace OrderingSystem.Domain;

public record Table
{
    public string Id { get; init; }
    public string Label { get; init; } = "";
    public List<Guid> CurrentItems { get; init; } = new List<Guid>();
    public Locations Location { get; init; }
}