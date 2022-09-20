using OrderingSystem.Domain;

namespace OrderingSystem.Json;

public class BillJsonLogic
{
    private const string Filename = @"C:\OrderingSystem\bills.json";
    private JsonBaseLogic<Bill> _jsonBaseLogic;

    public List<Bill> Bills;
    
    public BillJsonLogic()
    {
        _jsonBaseLogic = new JsonBaseLogic<Bill>();

        if (_jsonBaseLogic.GetFile(Filename) == null)
        {
            Bills = new List<Bill>();
            _jsonBaseLogic.PutInFile(Filename, Bills);
        }
        else
        {
            Bills = _jsonBaseLogic.GetFile(Filename);
        }
    }

    public void CreateBill(Bill bill)
    {
        Bills.Add(bill);
        _jsonBaseLogic.PutInFile(Filename, Bills);
    }
    
}