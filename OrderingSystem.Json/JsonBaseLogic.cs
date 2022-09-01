using Newtonsoft.Json;
using OrderingSystem.Domain;

namespace OrderingSystem.Json;

public class JsonBaseLogic<T>
{
    public List<T> GetFile(string filename)
    {
        try
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string json = sr.ReadToEnd();
                if (json.Length == 0)
                    return null;
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public void PutInFile(string filename, List<T> objToSerialize)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;
        using (StreamWriter sw = new StreamWriter(filename))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, objToSerialize);
        }
    }
}