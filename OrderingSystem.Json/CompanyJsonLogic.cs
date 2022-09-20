using OrderingSystem.Domain;

namespace OrderingSystem.Json;

public class CompanyJsonLogic
{
    private const string Filename = @"C:\OrderingSystem\company.json";
    private JsonBaseLogic<Company> _jsonBaseLogic;

    public CompanyJsonLogic()
    {
        _jsonBaseLogic = new JsonBaseLogic<Company>();
    }

    public Company? GetCompany()
    {
        if (DoesCompanyExist())
        {
            var companyList = _jsonBaseLogic.GetFile(Filename);
            if (companyList.Count == 0)
                return null;
            return companyList[0];
        }

        return null;
    }

    public bool DoesCompanyExist()
    {
        if (_jsonBaseLogic.GetFile(Filename) == null)
        {
            _jsonBaseLogic.PutInFile(Filename, new List<Company>());
            return false;
        }
        return true;
    }

    public void PutCompany(Company company)
    {
        var list = new List<Company>();
        list.Add(company);

        _jsonBaseLogic.PutInFile(Filename, list);
    }
}