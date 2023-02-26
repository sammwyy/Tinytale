public class ModDescriptor
{
    public string id;
    public string name;
    public string description;
    public string version;
    public string[] authors;
    public string gamemode = null;

    public static ModDescriptor DEFAULT
    {
        get
        {
            ModDescriptor def = new ModDescriptor();
            def.id = "unknown";
            def.name = "unknown";
            def.description = "unknown";
            def.version = "0.0.0";
            def.authors = new string[1] { "unknown" };
            return def;
        }
    }
}