using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using OrderingSystem.Domain;

namespace OrderingSystem.Json;

public class ItemJsonLogic
{
    private const string Filename = @"C:\OrderingSystem\items.json";
    private JsonBaseLogic<Item> _jsonBaseLogic;

    public List<Item> Items;

    public ItemJsonLogic()
    {
        _jsonBaseLogic = new JsonBaseLogic<Item>();

        if (_jsonBaseLogic.GetFile(Filename) == null)
        {
            Items = new List<Item>();
            _jsonBaseLogic.PutInFile(Filename, Items);
        }
        else
        {
            Items = _jsonBaseLogic.GetFile(Filename);
        }
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        _jsonBaseLogic.PutInFile(Filename, Items);
    }

    public void RemoveItem(Guid id)
    {
        Items.RemoveAll(item => item.Id == id);
        _jsonBaseLogic.PutInFile(Filename, Items);
    }

    public void EditItem(Item item)
    {
        var oldItem = Items.Find(a => a.Id == item.Id);
        if (oldItem != null)
        {
            Items.Remove(oldItem);
            Items.Add(item);
        }
        _jsonBaseLogic.PutInFile(Filename, Items);
    }

    public Item GetSingle(Guid id)
    {
        return Items.Find(item => item.Id == id);
    }
}