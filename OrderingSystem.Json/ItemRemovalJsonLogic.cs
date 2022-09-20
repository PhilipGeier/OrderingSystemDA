using OrderingSystem.Domain;

namespace OrderingSystem.Json;

public class ItemRemovalJsonLogic
{
    private const string Filename = @"C:\OrderingSystem\itemRemovals.json";
    private JsonBaseLogic<ItemRemoval> _jsonBaseLogic;
    
    public List<ItemRemoval> ItemRemovals;

    public ItemRemovalJsonLogic()
    {
        _jsonBaseLogic = new JsonBaseLogic<ItemRemoval>();

        if (_jsonBaseLogic.GetFile(Filename) == null)
        {
            ItemRemovals = new List<ItemRemoval>();
            _jsonBaseLogic.PutInFile(Filename, ItemRemovals);
        }
        else
        {
            ItemRemovals = _jsonBaseLogic.GetFile(Filename);
        }
    }

    public void AddRemoval(ItemRemoval itemRemoval)
    {
        ItemRemovals.Add(itemRemoval);
        _jsonBaseLogic.PutInFile(Filename, ItemRemovals);
    }
}