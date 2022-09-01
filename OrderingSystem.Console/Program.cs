using OrderingSystem.Domain;
using OrderingSystem.Domain.Enums;
using OrderingSystem.Json;

var tableJsonLogic = new TableJsonLogic();
var itemJsonLogic = new ItemJsonLogic();

for (int i = 1; i < 10; i++)
{
    var table = new Table()
    {
        Id = $"table{i}",
        Label = i.ToString(),
        Location = Locations.Bar,
        CurrentItems = new List<Guid> { Guid.Parse("d6822a91-4319-4e5d-b9f1-a679d4e4e78a") }
    };
    tableJsonLogic.AddTable(table);
}
