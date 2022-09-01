using OrderingSystem.Domain.Enums;

namespace OrderingSystem.Domain;

public record Item
{
    public Guid Id { get; init; }
    public string Name { get; init; } = "";
    public float PriceInclTax { get; init; }
    public float PriceExclTax => PriceInclTax / 1.1f;
    public ItemCategories Category { get; set; }
}