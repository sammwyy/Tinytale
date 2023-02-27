using Newtonsoft.Json;
using System.IO;

public class Map
{
    public string id;
    public int width;
    public int height;
    public MapLayer[] layers;

    public static Map LoadFromFile(string filepath)
    {
        string raw = File.ReadAllText(filepath);
        Map map = JsonConvert.DeserializeObject<Map>(raw);
        return map;
    }
}