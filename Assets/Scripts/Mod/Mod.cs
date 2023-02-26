using System.IO;
using Newtonsoft.Json;

public class Mod
{
    private string _dir;
    private ModDescriptor _descriptor;
    private ModGamemode _gamemode;

    public Mod(string dir)
    {
        this._dir = dir;
        this._descriptor = ModDescriptor.DEFAULT;
    }

    public string Directory
    {
        get
        {
            return this._dir;
        }
    }

    public ModDescriptor Descriptor
    {
        get
        {
            return this._descriptor;
        }
    }

    public ModGamemode Gamemode
    {
        get
        {
            return this._gamemode;
        }
    }

    public void Load()
    {
        string descriptorFile = Path.Combine(this._dir, "mod.json");
        if (!File.Exists(descriptorFile))
        {
            throw new ModLoadException(ModLoadExceptionKind.NO_MOD_DESCRIPTOR, this);
        }

        string raw_desc = File.ReadAllText(descriptorFile);
        this._descriptor = JsonConvert.DeserializeObject<ModDescriptor>(raw_desc);

        if (this._descriptor != null)
        {
            this._gamemode = new ModGamemode(
                this._descriptor.gamemode,
                Path.Combine(this._dir, "scripts")
            );
        }
    }
}