using Microsoft.AspNetCore.Http.Features;
using OrderingSystem.Domain;
using OrderingSystem.Json;

var builder = WebApplication.CreateBuilder(args);
var tableJsonLogic = new TableJsonLogic();
var itemJsonLogic = new ItemJsonLogic();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Tables Mapping
app.MapGet("/tables", () =>
{
    return tableJsonLogic.Tables;
});

app.MapGet("/table/{id}", (string id) =>
{
    return tableJsonLogic.GetSingle(id);
});

app.MapPost("/tables", (Table table) =>
{
    tableJsonLogic.AddTable(table);
});

app.MapPut("/table", (Table table) =>
{
    tableJsonLogic.EditTable(table);
});

app.MapDelete("/tables/{id}", (string id) =>
{
    tableJsonLogic.RemoveTable(id);
});

app.MapPut("/table/{tableId}/{itemId}", (string tableId, Guid itemId) => {
    tableJsonLogic.AddItemToTable(tableId, itemId);
});

// Items Mapping
app.MapGet("/items", () =>
{
    return itemJsonLogic.Items;
});

app.MapGet("/item/{id}", (Guid id) =>
{
    return itemJsonLogic.GetSingle(id);
});

app.MapPost("/items", (Item item) =>
{
    itemJsonLogic.AddItem(item);
});

app.MapPut("/item", (Item newItem) =>
{
    itemJsonLogic.EditItem(newItem);
});

app.MapDelete("/items/{id}", (Guid id) =>
{
    itemJsonLogic.RemoveItem(id);
});



app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

