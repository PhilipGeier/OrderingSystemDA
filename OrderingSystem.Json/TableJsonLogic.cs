using System.Security.Cryptography.X509Certificates;
using OrderingSystem.Domain;

namespace OrderingSystem.Json;

public class TableJsonLogic
{
    private const string Filename = @"C:\OrderingSystem\tables.json";
    private JsonBaseLogic<Table> _jsonBaseLogic;

    public List<Table> Tables;
    
    public TableJsonLogic()
    {
        _jsonBaseLogic = new JsonBaseLogic<Table>();

        if (_jsonBaseLogic.GetFile(Filename) == null)
        {
            Tables = new List<Table>();
            _jsonBaseLogic.PutInFile(Filename, Tables);
        }
        else
        {
            Tables = _jsonBaseLogic.GetFile(Filename);
        }
    }
    
    public void AddTable(Table table)
    {
        Tables.Add(table);
        _jsonBaseLogic.PutInFile(Filename, Tables);
    }
    
    public void RemoveTable(string id)
    {
        Tables.RemoveAll(table => table.Id == id);
        _jsonBaseLogic.PutInFile(Filename, Tables);
    }

    public void EditTable(Table table)
    {
        var oldTable = Tables.Find(a => a.Id == table.Id);
        if (oldTable != null)
        {
            Tables.Remove(oldTable);
            Tables.Add(table);
        }
        _jsonBaseLogic.PutInFile(Filename, Tables);
    }

    public void AddItemToTable(string tableId, Guid itemId)
    {
        var table = Tables.Find(a => a.Id == tableId);

        table.CurrentItems.Add(itemId);
        _jsonBaseLogic.PutInFile(Filename, Tables);
    }
    
    public Table GetSingle(string id)
    {
        return Tables.Find(table => table.Id == id);
    }
}