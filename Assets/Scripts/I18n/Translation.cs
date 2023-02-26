using System.Collections.Generic;
using System.IO;

public class Translation
{
    private string _id;
    private Dictionary<string, string> messages;

    public Translation(string id)
    {
        this._id = id;
        this.messages = new Dictionary<string, string>();
    }

    public void AddKey(string key, string message)
    {
        this.messages.Add(key, message);
    }

    public string ID
    {
        get
        {
            return this._id;
        }
    }

    public string Translate(string key)
    {
        string value;
        this.messages.TryGetValue(key, out value);
        return value != null ? value : "<missing_translation_key=" + key + ">";
    }


    static Translation LoadFromRaw(string id, string raw)
    {
        Translation translation = new Translation(id);

        string[] lines = raw.Split("\n");
        foreach (string line in lines)
        {
            if (!line.StartsWith("#") && line.Trim() != "" && line.Contains("="))
            {
                string[] kvPair = line.Split("=");
                string key = kvPair[0].Trim();
                string value = kvPair[1].Trim();

                translation.AddKey(key, value);
            }
        }

        return translation;
    }

    public static Translation LoadFromFile(string id, string filepath)
    {
        string content = File.ReadAllText(filepath);
        return LoadFromRaw(id, content);
    }

    public static Translation LoadFromFile(string filepath)
    {
        string id = Path.GetFileNameWithoutExtension(filepath);
        return LoadFromFile(id, filepath);
    }
}